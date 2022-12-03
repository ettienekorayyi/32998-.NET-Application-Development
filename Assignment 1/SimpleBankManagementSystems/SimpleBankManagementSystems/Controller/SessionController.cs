using SimpleBankManagementSystems.View;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankManagementSystems.Interfaces;
using System;
using SimpleBankManagementSystems.Classes;

namespace SimpleBankManagementSystems.Controller
{
    class SessionController
    {
        private FileManager userFile;
        private bool matchFound = false;

        private static Guid tokenId = Guid.Empty;

        public Guid TokenId
        {
            get { return tokenId; }
            set { tokenId = value; }
        }

        public SessionController()
        {
            userFile = new FileManager();
        }


        public void Login()
        {
            userFile.GetUserNameInput();
            userFile.GetPassWordInput();

            try
            {

                string[] credential = userFile.OpenFile();
                
                do
                {
                    for (int ctr = 0; ctr < credential.Length; ctr++)
                    {
                        string[] userAndPass = credential[ctr].Replace("\0", string.Empty).Split('|');
                        matchFound = userFile.CheckCredentials(userAndPass);
                        if (matchFound == true)
                        {
                            TokenId = Guid.NewGuid();
                            break;
                        }
                    }

                    if (matchFound == false) userFile.Retry();

                } while (matchFound == false);
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        
    }
}
