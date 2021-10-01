using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorProject {
    struct User {
        const string UsersFileLoc = "Database//Users.txt";
        const string TimesFileLoc = "Database//Times.txt";

        public int Id;
        public string Name;
        public List<float>[] Times;

        public User(string name, int id = -1) {
            Name = name;
            Times = new List<float>[(int)Difficulty.Count];
            for (int i = 0; i < (int)Difficulty.Count; i++) {
                Times[i] = new List<float>();
            }
            //set id
            Id = id;
            if (id == -1) {
                string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc); //https://stackoverflow.com/a/6041505
                if (file.Length == 0) { Id = 0; }
                else {
                    Id = int.Parse(file[file.Length-1].Split(',')[0]); //id, name
                }
            }
        }

        private static string[] readFile(string address) { 
            string[] file = new string[0];
            try {
                file = File.ReadAllLines(address);
            } catch (Exception ex) {
                if (ex.GetType() == typeof(FileNotFoundException)) {
                    System.Windows.Forms.MessageBox.Show("File Not Found");
                }
            }
            return file;
        }

        public void GetTimesFromFile() {
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + TimesFileLoc); //https://stackoverflow.com/a/6041505
            
            foreach (string str in file) {
                string[] line = str.Split(','); //id, difficulty, time
                if (line[0] == Id.ToString()) {
                    Times[int.Parse(line[1])].Add(float.Parse(line[2]));
                }
            }

        }

        public static bool ReadUserFromFile(string name, out User user) {
            user = new User("");
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc); //https://stackoverflow.com/a/6041505
            if (file.Length == 0) { return false; }
            
            bool foundUser = false;
            foreach (string str in file) {
                string[] line = str.Split(','); //id, name
                if (line[1].ToUpper() == name.ToUpper()) {
                    foundUser = true;
                    user.Id = int.Parse(line[0]);
                    user.Name = line[1];

                    user.GetTimesFromFile();
                    break;
                }
            }
            return foundUser;
        }

        public static bool ReadUserFromFile(int id, out User user) {
            user = new User("");
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc); //https://stackoverflow.com/a/6041505
            if (file.Length == 0) { return false; }

            bool foundUser = false;
            foreach (string str in file) {
                string[] line = str.Split(','); //id, name
                if (line[0] == id.ToString()) {
                    foundUser = true;
                    user.Id = int.Parse(line[0]);
                    user.Name = line[1];

                    user.GetTimesFromFile();
                    break;
                }
            }
            return foundUser;
        }

        public void SaveToFile() {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-5.0
            //save to users.txt
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc)) {
                string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc); //https://stackoverflow.com/a/6041505
                bool foundUser = false;
                foreach (string str in file) {
                    string[] line = str.Split(','); //id, name
                    if (line[0] == Id.ToString()) {
                        foundUser = true;
                        break;
                    }
                }
                if (!foundUser) {
                    File.AppendAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc, Id.ToString()+Name+"\n");
                }
            } else { 
                File.AppendAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + UsersFileLoc, Id.ToString()+", "+Name+"\n");
            }

            //save to times.txt
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + TimesFileLoc)) {
                List<string> file = readFile(AppDomain.CurrentDomain.BaseDirectory + TimesFileLoc).ToList(); //https://stackoverflow.com/a/6041505
                for (int i = 0; i < (int)Difficulty.Count; i++) {
                    foreach (float time in Times[i]) {
                        file.Add(Id.ToString()+", "+i.ToString()+", "+time.ToString());
                    }
                }
                File.WriteAllLinesAsync(AppDomain.CurrentDomain.BaseDirectory + TimesFileLoc, file.Distinct());
            } else {
                List<string> lines = new List<string>();
                for (int i = 0; i < (int)Difficulty.Count; i++) {
                    foreach (float time in Times[i]) {
                        lines.Add(Id.ToString()+", "+i.ToString()+", "+time.ToString());
                    }
                }
                File.AppendAllLinesAsync(AppDomain.CurrentDomain.BaseDirectory + TimesFileLoc, lines);
            }

        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-5.0
        //https://stackoverflow.com/a/6041505

        //file formats:
        //Users.txt: userid, username
        //Times.txt: userid, difficulty, time
    }

}