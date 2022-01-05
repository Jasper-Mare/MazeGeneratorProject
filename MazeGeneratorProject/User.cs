using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace MazeGeneratorProject {
    public struct User {
        const string usersFileLoc = @"Database/Users.txt";
        const string timesFileLoc = @"Database/Times.txt";
        public int Id;
        public string Name;
        public List<float>[] Times;
        public Keys KeyUp;
        public Keys KeyLeft;
        public Keys KeyRight;
        public Keys KeyDown;

        public User(string name,int id = -1) {
            Name = name;
            Times = new List<float>[(int)Difficulty.Count];
            for(int i = 0; i < (int)Difficulty.Count; i++) {
                Times[i] = new List<float>();
            }
            //set id
            Id = id;
            if(id == -1) {
                string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
                if(file.Length == 0) { Id = 0; } else {
                    Id = int.Parse(file[file.Length-1].Split(',')[0])+1; //id, name
                }
            }
            KeyLeft = Keys.Left;
            KeyUp = Keys.Up;
            KeyRight = Keys.Right;
            KeyDown = Keys.Down;
        }
        private static string[] readFile(string address) {
            string[] file = new string[0];
            try {
                file = File.ReadAllLines(address);
            } catch(Exception ex) {
                if(ex.GetType() == typeof(FileNotFoundException)) {
                    MessageBox.Show("File Not Found");
                }
            }
            return file;
        }
        public void GetTimesFromFile() {
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + timesFileLoc); //https://stackoverflow.com/a/6041505
            foreach(string str in file) {
                string[] line = str.Split(','); //id, difficulty, time
                if(line[0] == Id.ToString()) {
                    Times[int.Parse(line[1])].Add(float.Parse(line[2]));
                }
            }
        }
        public static bool ReadUserFromFile(string name,out User user) {
            user = new User("");
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
            if(file.Length == 0) { return false; }
            bool foundUser = false;
            foreach(string str in file) {
                string[] line = str.Split(','); //id, name, key ccw, key select, key cw
                if(line[1].ToUpper() == name.ToUpper()) {
                    foundUser = true;
                    user.Id = int.Parse(line[0]);
                    user.Name = line[1];
                    user.GetTimesFromFile();
                    //https://stackoverflow.com/a/19077881
                    user.KeyLeft = (Keys)Enum.Parse(typeof(Keys),line[2]);
                    user.KeyUp = (Keys)Enum.Parse(typeof(Keys),line[3]);
                    user.KeyRight = (Keys)Enum.Parse(typeof(Keys),line[4]);
                    user.KeyDown = (Keys)Enum.Parse(typeof(Keys),line[5]);
                    break;
                }
            }
            return foundUser;
        }
        public static bool ReadUserFromFile(int id,out User user) {
            user = new User("");
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
            if(file.Length == 0) { return false; }
            bool foundUser = false;
            foreach(string str in file) {
                string[] line = str.Split(','); //id, name, key ccw, key select, key cw
                if(line[0] == id.ToString()) {
                    foundUser = true;
                    user.Id = int.Parse(line[0]);
                    user.Name = line[1];
                    user.GetTimesFromFile();
                    //https://stackoverflow.com/a/19077881
                    user.KeyLeft = (Keys)Enum.Parse(typeof(Keys),line[2]);
                    user.KeyUp = (Keys)Enum.Parse(typeof(Keys),line[3]);
                    user.KeyRight = (Keys)Enum.Parse(typeof(Keys),line[4]);
                    user.KeyDown = (Keys)Enum.Parse(typeof(Keys),line[5]);
                    break;
                }
            }
            return foundUser;
        }
        public void SaveToFile() {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-5.0
            //save to users.txt
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc)) {
                string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
                bool foundUser = false;
                int i = 0;
                foreach(string str in file) {
                    string[] line = str.Split(','); //id, name
                    if(line[0] == Id.ToString()) {
                        foundUser = true;
                        file[i] = Id.ToString()+","+Name+","+KeyLeft+","+KeyUp+","+KeyRight+","+KeyDown; //overwrite user in case keys changed
                        break;
                    }
                    i++;
                }
                if(!foundUser) {
                    File.AppendAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc,"\n"+Id.ToString()+","+Name+","+KeyLeft+","+KeyUp+","+KeyRight+","+KeyDown);
                } else {
                    File.WriteAllLinesAsync(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc,file);
                }
            } else {
                File.AppendAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc,Id.ToString()+","+Name+","+KeyLeft+","+KeyUp+","+KeyRight+","+KeyDown);
            }
            //save to times.txt
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + timesFileLoc)) {
                List<string> file = readFile(AppDomain.CurrentDomain.BaseDirectory + timesFileLoc).ToList(); //https://stackoverflow.com/a/6041505
                for(int i = 0; i < (int)Difficulty.Count; i++) {
                    foreach(float time in Times[i]) {
                        file.Add(Id.ToString()+","+i.ToString()+","+time.ToString());
                    }
                }
                File.WriteAllLinesAsync(AppDomain.CurrentDomain.BaseDirectory + timesFileLoc,file.Distinct());
            } else {
                List<string> lines = new List<string>();
                for(int i = 0; i < (int)Difficulty.Count; i++) {
                    foreach(float time in Times[i]) {
                        lines.Add(Id.ToString()+","+i.ToString()+","+time.ToString());
                    }
                }
                File.AppendAllLinesAsync(AppDomain.CurrentDomain.BaseDirectory + timesFileLoc,lines);
            }
        }
        //https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-5.0
        //https://stackoverflow.com/a/6041505
    }
}