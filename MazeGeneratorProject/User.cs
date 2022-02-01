using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace MazeGeneratorProject {
    public struct User {
        //constants holding the locations of the files in the database relative to the execuitable file, they are relative so the program will work on computers other than the one I made it on.
        //the @ before the string means c# treats each character in it as that character instead of possibly a meta character ( / is treated as a metcharacter in normal strings)
        const string usersFileLoc = @"Database/Users.txt";
        const string timesFileLoc = @"Database/Times.txt";

        public int Id;
        public string Name;
        public List<float>[] Times;
        public Keys KeyUp;
        public Keys KeyLeft;
        public Keys KeyRight;
        public Keys KeyDown;

        public User(string name,int id = -1) { //here id is an optional parameter as it already has a value, this means an id doesn't need to be specified if it isn't known
            Name = name;
            Times = new List<float>[(int)Difficulty.Count];
            for(int i = 0; i < (int)Difficulty.Count; i++) {
                Times[i] = new List<float>();
            }
            
            //set id
            Id = id;
            if(id == -1) { //if the id is -1 that means it is unknown and needs to be searched for
                string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
                if(file.Length == 0) { Id = 0; } else {
                    Id = int.Parse(file[file.Length-1].Split(',')[0])+1; //id, name
                }
            }

            //set default preferences for movemnt keys
            KeyLeft = Keys.Left;
            KeyUp = Keys.Up;
            KeyRight = Keys.Right;
            KeyDown = Keys.Down;
        }

        private static string[] readFile(string address) { //a subroutine that checks if a file exists then reads all the lines in that file
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

        public void GetTimesFromFile() { //a function that reads all the times from the 'times' file and extracts all the times belonging to the user
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + timesFileLoc); //https://stackoverflow.com/a/6041505
            foreach(string str in file) {
                string[] line = str.Split(','); //id, difficulty, time
                if(line[0] == Id.ToString()) {
                    Times[int.Parse(line[1])].Add(float.Parse(line[2]));
                }
            }
        }
        public static bool ReadUserFromFile(string name,out User user) { //a function that searches for a user in the 'users' file for a user with the specified name, it returns a boll showing if the search was successfull
            user = new User("");
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
            if(file.Length == 0) { return false; }
            bool foundUser = false;
            foreach(string str in file) {
                string[] line = str.Split(','); //id, name, key left, key up, key right, key down
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
                    break; //leave the loop once the requested user has been found
                }
            }
            return foundUser; //return if the user was found, the user themselves is returned via the 'out' parameter
        }
        public static bool ReadUserFromFile(int id,out User user) { //a function that searches for a user in the 'users' file for a user with the specified id, it returns a boll showing if the search was successfull
            user = new User("");
            string[] file = readFile(AppDomain.CurrentDomain.BaseDirectory + usersFileLoc); //https://stackoverflow.com/a/6041505
            if(file.Length == 0) { return false; }
            bool foundUser = false;
            foreach(string str in file) {
                string[] line = str.Split(','); //id, name, key left, key up, key right, key down
                if (line[0] == id.ToString()) {
                    foundUser = true;
                    user.Id = int.Parse(line[0]);
                    user.Name = line[1];
                    user.GetTimesFromFile();
                    //https://stackoverflow.com/a/19077881
                    user.KeyLeft = (Keys)Enum.Parse(typeof(Keys),line[2]);
                    user.KeyUp = (Keys)Enum.Parse(typeof(Keys),line[3]);
                    user.KeyRight = (Keys)Enum.Parse(typeof(Keys),line[4]);
                    user.KeyDown = (Keys)Enum.Parse(typeof(Keys),line[5]);
                    break; //leave the loop once the requested user has been found
                }
            }
            return foundUser; //return if the user was found, the user themselves is returned via the 'out' parameter
        }
        public void SaveToFile() { //save the user to file
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