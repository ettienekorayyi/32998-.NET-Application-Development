using SimpleTextEditor.Assets;
using SimpleTextEditor.Interfaces;
using SimpleTextEditor.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Classes
{
    public class FileManager : IFileManager
    {
        private static IFileManager _fileManager;
        private static object locker = new object();
       
        private static string[] _result;

        public static IFileManager GetFileManagerInstance()
        {
            if (_fileManager == null)
            {
                lock (locker)
                {
                    if (_fileManager == null)
                    {
                        _fileManager = new FileManager();
                        
                    }
                }
            }

            return _fileManager;
        }
        
        public void OpenFile()
        {
            try
            {
                string path = $"{CONSTANTS.BASE_DIRECTORY}{CONSTANTS.FILE_PATH}";

                using (FileStream fs = File.Open($"{path}{CONSTANTS.LOGIN_FILE}", FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    char[] chars = new char[] { '\r', '\n' };

                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        _result = temp.GetString(b).Replace("\0", string.Empty)
                            .Split(chars, StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
            catch (DirectoryNotFoundException dnf)
            {
                Debug.WriteLine(dnf.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public List<IUserProfile> ReadFile()
        {
            List <IUserProfile> listOfUsers = new List<IUserProfile>();
            for (int iterator = 0; iterator < _result.Length; iterator++)
            {
                var user = _result[iterator].Split(',');
                
                listOfUsers.Add(new UserProfile()
                {
                    UserName = user[0],
                    Password = user[1],
                    UserType = user[2],
                    FirstName = user[3],
                    LastName = user[4],
                    DateOfBirth = DateTime.Parse(user[5])
                });
            }

            return listOfUsers;
        }

        public void SaveFile(IUserProfile user)
        {
            string path = $"{CONSTANTS.BASE_DIRECTORY}{CONSTANTS.FILE_PATH}";
            string unicodeString = this.Rewriter(user);
            using (FileStream fs = File.Open($"{path}{CONSTANTS.LOGIN_FILE}", FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                byte[] info = new UTF8Encoding(true).GetBytes(unicodeString);
                fs.Write(info, 0, info.Length);
            }
        }

        private string Rewriter(IUserProfile user)
        {
            string[] newList = new string[_result.Length + 1];
            string rewriteList = String.Empty;

            for (int iterator = 0; iterator < newList.Length; iterator++)
            {
                try
                {
                    if (iterator == newList.Length - 1)
                    {
                        rewriteList += $"{user.UserName},{user.Password}," +
                            $"{user.UserType},{user.FirstName},{user.LastName}" +
                            $",{user.DateOfBirth.ToString("yyyy-MM-dd")}\n";
                    }
                    else rewriteList += $"{_result[iterator]}\n";
                }
                catch (IndexOutOfRangeException rex)
                { 
                    Debug.WriteLine(rex.Message);
                }
            }
            return rewriteList;
        }
    }
}
