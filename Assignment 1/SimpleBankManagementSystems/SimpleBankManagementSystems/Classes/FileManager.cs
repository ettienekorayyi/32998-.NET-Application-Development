using SimpleBankManagementSystems.Common;
using SimpleBankManagementSystems.Interfaces;
using SimpleBankManagementSystems.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleBankManagementSystems.Classes
{
    class FileManager : IFileManager
    {
        private int pathLength = Directory.GetCurrentDirectory().Length;
        private string fileName;
        private string userName;
        private string passWord;
        private string errorMessage = "Invalid credentials!";

        /// <summary>
        /// Opens the login.txt file located in the Assets directory.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] OpenFile()
        {
            fileName = @"login.txt";
            string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9)+ @"Common\Assets\" }{fileName}";
            
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    return temp.GetString(b).Replace("\0", String.Empty).Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            return Array.Empty<string>();
        }

        public bool isDuplicate(string[] credentials)
        {
            int duplicateCount = 0;

            for (int iterator = 0; iterator < credentials.Length; iterator++)
            {
                int findIndex = credentials[iterator].IndexOf('|');
                if (userName == credentials[iterator].Substring(0, findIndex))
                {
                    duplicateCount += 1;
                }
            }
            
            return duplicateCount >=2 ? true : false;
        }

        public bool CheckCredentials(string[] usernameAndPassword)
        {
            if (userName == usernameAndPassword[0] && passWord == usernameAndPassword[1])
            {
                Console.SetCursorPosition(15, Console.CursorTop = 18); 
                Console.WriteLine($"Login Successful..");
                
                return true;
            }
            return false;
        }

        public void Retry()
        {
            Console.SetCursorPosition(20, Console.CursorTop = 8);
            for (int i = 0; i < userName.Length; i++) Console.Write(" ");

            Console.SetCursorPosition(20, Console.CursorTop = 9);
            for (int i = 0; i < passWord.Length; i++) Console.Write(" ");

            Console.SetCursorPosition(0, Console.CursorTop = 14);
            Console.Write(errorMessage);
            Console.ReadKey(true);
            Console.SetCursorPosition(0, Console.CursorTop = 14);

            for (int i = 0; i < errorMessage.Length; i++) Console.Write(" "); 

            GetUserNameInput();
            GetPassWordInput();
        }

        public void GetUserNameInput()
        {
            string paragraph = $"Duplicate usernames are not allowed. Please consider updating your username.";
            bool checkIfDuplicateUser = false;
            do
            {
                Console.SetCursorPosition(20, Console.CursorTop = 8);
                if (userName != String.Empty && userName != null)
                {
                    for (int i = 0; i < userName.Length; i++) Console.Write(" ");
                    Console.SetCursorPosition(20, Console.CursorTop = 8);
                }
                userName = Console.ReadLine();

                string[] credential = this.OpenFile();
                checkIfDuplicateUser = this.isDuplicate(credential);
                if (checkIfDuplicateUser == false)
                {
                    Console.SetCursorPosition(0, Console.CursorTop = 12);
                    for (int i = 0; i < paragraph.Length; i++) Console.Write(" ");
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop = 12);//
                    Console.Write(paragraph);
                }

            } while (checkIfDuplicateUser == true);
        }

        public void GetPassWordInput()
        {
            ConsoleKeyInfo key;
            passWord = String.Empty;

            Console.SetCursorPosition(20, Console.CursorTop = 9);

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    passWord += key.KeyChar;
                    Console.Write("*");
                }
                if (key.Key == ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    passWord += key.KeyChar;
                    Utility.Clear(passWord, 20, 9);
                    passWord = String.Empty;
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
        }

        /// <summary>
        /// Finds the existing account files
        /// </summary>
        /// <returns>int</returns>
        public int GetAccountNumberFromFileName()
        {
            string[] accountFiles = Directory.GetFiles(Directory.GetCurrentDirectory().Substring(0, pathLength-9) + @"Common\Accounts\");
            List<int> currentAccounts = new List<int>();
            
            for (int i = 0; i < accountFiles.Length; i++)
            {
                string file = accountFiles[i].Substring(0, accountFiles[0].Length - 4) ;
                string getAccountNumber = file.Substring(121);
                if (getAccountNumber.Length > 5 && getAccountNumber.Length < 11) currentAccounts.Add(Int32.Parse(getAccountNumber));
            }

            return currentAccounts.LastOrDefault() == 0 ? 100001 : currentAccounts.LastOrDefault() + 1;
        }

        /// <summary>
        /// Creates a new account file with the account number as its filename.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="accountNumber"></param>
        public bool CreateFile(User user)
        {
            fileName = $"{user.AccountNumber}.txt";
            bool fileCreationSuccessful = false;
            string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9) + @"Common\Accounts\" }{fileName}";

            try
            {
                using (FileStream fs = File.Create(path))
                {
                    String unicodeString = $"First Name|{user.FirstName}\nLast Name|{user.LastName}\nBalance|{user.Balance}\n" +
                          $"Address|{user.Address}\nPhone|{user.Phone}\nEmail|{user.Email}\nAccount Number|{user.AccountNumber}";

                    byte[] info = new UTF8Encoding(true).GetBytes(unicodeString);
                    fs.Write(info, 0, info.Length);
                    fileCreationSuccessful = true;
                }
                Console.SetCursorPosition(0, Console.CursorTop = 15);
                Console.WriteLine("Account Created. Check your email for more details.");
                Console.WriteLine($"Account number is: {user.AccountNumber}");
                
                return fileCreationSuccessful;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return fileCreationSuccessful;
        }

        public bool CheckFileExists(int accountNumber)
        {
            fileName = $"{accountNumber}.txt";
            string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9) + @"Common\Accounts\" }{fileName}";

            return File.Exists(path);
        }

        /// <summary>
        /// Finds the account number in the Accounts directory and returns the user profile
        /// once it successfully locates the account.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user</returns>
        public User FindAccount(User user)
        {
            fileName = $"{user.AccountNumber}.txt";
            string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9) + @"Common\Accounts\" }{fileName}";
            
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    string[] profile = temp.GetString(b).Replace("\0", String.Empty)
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    user.FirstName = profile[0].Substring(profile[0].IndexOf('|')).Replace("|", String.Empty);
                    user.LastName = profile[1].Substring(profile[1].IndexOf('|')).Replace("|", String.Empty);
                    
                    if (profile[2].Substring(0, profile[2].IndexOf('|')).Replace("|", String.Empty) == "Balance")
                    {
                        user.Balance = decimal.Parse(profile[2].Substring(profile[2].IndexOf('|')).Replace("|", String.Empty));
                        user.Address = profile[3].Substring(profile[3].IndexOf('|')).Replace("|", String.Empty);
                        user.Phone = profile[4].Substring(profile[4].IndexOf('|')).Replace("|", String.Empty);
                        user.Email = profile[5].Substring(profile[5].IndexOf('|')).Replace("|", String.Empty);

                        int len = profile.Count() - 7;
                        
                        var statements = profile.Skip(7).Take(len);

                        foreach (var st in statements)
                        {
                            if (st.Contains('|'))
                            {
                                var statement = st.Split('|');
                                user.AccountStatements.Add(new AccountStatement
                                {
                                    Date = statement[0],
                                    Transaction = statement[1],
                                    TransactionAmount = statement[2],
                                    Balance = statement[3]
                                });
                            }
                            continue;
                        }
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// This function retrieves the lists of statements associated with the given account and assigns it
        /// model classes. String manipulations were used to extract the relevant information needed to get the
        /// account statements.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetAccountStatement(User user)
        {
            fileName = $"{user.AccountNumber}.txt";
            string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9) + @"Common\Accounts\" }{fileName}";
           
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    string[] profile = temp.GetString(b).Replace("\0", String.Empty)
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    user.FirstName = profile[0].Substring(profile[0].IndexOf('|')).Replace("|", String.Empty);
                    user.LastName = profile[1].Substring(profile[1].IndexOf('|')).Replace("|", String.Empty);

                    if (profile[2].Substring(0, profile[2].IndexOf('|')).Replace("|", String.Empty) == "Balance")
                    {
                        user.Balance = decimal.Parse(profile[2].Substring(profile[2].IndexOf('|')).Replace("|", String.Empty));
                        user.Address = profile[3].Substring(profile[3].IndexOf('|')).Replace("|", String.Empty);
                        user.Phone = profile[4].Substring(profile[4].IndexOf('|')).Replace("|", String.Empty);
                        user.Email = profile[5].Substring(profile[5].IndexOf('|')).Replace("|", String.Empty);
                    }
                    if (profile[6].Substring(0, profile[6].IndexOf('|')).Replace("|", String.Empty) == "Account Number")
                    {
                        var statements = profile.Skip(7);

                        foreach (var st in statements)
                        {
                            var statement = st.Split('|');
                            user.AccountStatements.Add(new AccountStatement 
                            { 
                                Date = statement[0],
                                Transaction = statement[1],
                                TransactionAmount = statement[2],
                                Balance = statement[3]
                            });
                        }
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// The UpdateAccount function is responsible for updating the balance property
        /// of the user profile. It first try to find the account file in the Accounts directory
        /// and overwrites the existing file with the updated value of the balance along with the statements.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user</returns>
        public User UpdateAccount(User user, string operation)
        {
            decimal amount = User.GetAmountFromUser();
            string message = String.Empty;
            User current = this.FindAccount(user);
            string statements = String.Empty;
            string today = DateTime.Today.ToString("MM.dd.yyyy");
            try
            {
                current.Balance = Utility.Calculate(current.Balance, out message, amount, operation);
                fileName = $"{user.AccountNumber}.txt";
                current.AccountStatements.Add(new AccountStatement 
                {
                    Date = today,
                    Transaction = operation,
                    TransactionAmount = $"{amount}",
                    Balance = $"{current.Balance}"
                });

                foreach (var st in current.AccountStatements)
                {
                    statements += $"{st.Date}|{st.Transaction}|{st.TransactionAmount}|{st.Balance}\n";
                }

                string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9) + @"Common\Accounts\" }{fileName}";

                using (FileStream fs = File.Create(path))
                {
                    String unicodeString = $"First Name|{user.FirstName}\nLast Name|{user.LastName}\n" + $"Balance|{user.Balance}\n" +
                        $"Address|{user.Address}\nPhone|{user.Phone}\nEmail|{user.Email}\n" + $"Account Number|{user.AccountNumber}\n" +
                        $"{statements}";

                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    byte[] info = new UTF8Encoding(true).GetBytes(unicodeString);
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("\n\n");
                Console.WriteLine($"{message} Successful.");
                Console.WriteLine($"Your balance is now {current.Balance}");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine(e.Message);
            }
            
            return user;
        }

        /// <summary>
        /// This function is responsible for the file deletion of the account.
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user)
        {
            fileName = $"{user.AccountNumber}.txt";
            string path = $"{Directory.GetCurrentDirectory().Substring(0, pathLength - 9) + @"Common\Accounts\" }{fileName}";

            try
            {
                File.Delete(path);
                Console.WriteLine("Account deleted successfully.");
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
