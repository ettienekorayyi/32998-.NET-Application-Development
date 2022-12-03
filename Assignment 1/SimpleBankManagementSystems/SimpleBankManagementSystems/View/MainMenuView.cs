using SimpleBankManagementSystems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.View
{
    class MainMenuView : IView
    {
        private Guid accessToken;

        public void AccessMainMenu(Guid token)
        {
            accessToken = token;
            Console.Clear();
        }

        public void RenderView()
        {
            if (accessToken != Guid.Empty) {
                Console.Clear();
                Console.WriteLine(String.Format("======================================================================"));
                Console.WriteLine(String.Format("|                                                                    |"));
                Console.WriteLine(String.Format("|                  Welcome to Simple Banking System                  |"));
                Console.WriteLine(String.Format("|                                                                    |"));
                Console.WriteLine(String.Format("======================================================================"));
                Console.WriteLine(String.Format("|                                                                    |"));
                Console.WriteLine(String.Format("|   1. Create New Account                                            |"));
                Console.WriteLine(String.Format("|   2. Search Account                                                |"));
                Console.WriteLine(String.Format("|   3. Deposit                                                       |"));
                Console.WriteLine(String.Format("|   4. Withdraw                                                      |"));
                Console.WriteLine(String.Format("|   5. A/C Statement                                                 |"));
                Console.WriteLine(String.Format("|   6. Delete Account                                                |"));
                Console.WriteLine(String.Format("|   7. Exit                                                          |"));
                Console.WriteLine(String.Format("======================================================================"));
                Console.WriteLine(String.Format("|                                                                    |"));
                Console.WriteLine(String.Format("|                                                                    |"));
                Console.WriteLine(String.Format("|                                                                    |"));
                Console.WriteLine(String.Format("======================================================================"));
            }
        }
    }
}
