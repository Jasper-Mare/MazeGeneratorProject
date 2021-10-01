﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorProject {
    struct User {
        const string UserDBFileLoc = "Database//Users.txt";
        const string TimeDBFileLoc = "Database//Times.txt";

        public int Id;
        public String Name;
        public List<float> TimesEasy;
        public List<float> TimesMedium;
        public List<float> TimesHard;

        public User(string name, int id = -1) {
            Name = name;
            TimesEasy = new List<float>();
            TimesMedium = new List<float>();
            TimesHard = new List<float>();
            //set id
            Id = id;
            if (id == -1) { 
                
            }
        }

        public static bool ReadUserFromFile(string name, out User user) {
            user = new User();
            string[] file = new string[0];
            try {
                file = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + UserDBFileLoc); //https://stackoverflow.com/a/6041505
            } catch (Exception ex) {
                if (ex.GetType() == typeof(FileNotFoundException)) {
                    System.Windows.Forms.MessageBox.Show("File Not Found");
                }
                return false;
            }

            bool foundUser = false;
            foreach (string str in file) {
                string[] line = str.Split(',');
                if (line[1].ToUpper() == name.ToUpper()) {
                    foundUser = true;
                    user.Id = int.Parse(line[0]);
                    user.Name = line[1];
                    break;
                }
            }
            return foundUser;
        }

        public static User ReadUserFromFile(int id) {


            return new User("name");
        }

        public void SaveToFile() { 
            
        }

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
        //https://stackoverflow.com/a/6041505
    }


}