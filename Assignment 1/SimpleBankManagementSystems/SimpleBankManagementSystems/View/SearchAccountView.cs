using SimpleBankManagementSystems.Common;
using SimpleBankManagementSystems.Interfaces;
using SimpleBankManagementSystems.Model;
using System;
using SimpleBankManagementSystems.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.View
{
    class SearchAccountView : IView
    {
        public void RenderView()
        {
            Console.Clear();
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                        Search a New Account                        |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                         Enter the details                          |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|         Account Number:                                            |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
        }

        public void DisplayAccount(User user)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Account Found!");
            string accountNumber = user.AccountNumber.ToString() + "         ";
            
            // Adjusts the whitespace in the table
            string fnamespace   = "                                              ".Remove(0, user.FirstName.Length);
            string lnamespace   = "                                              ".Remove(0, user.LastName.Length);
            string addressspace = "                                              ".Remove(0, user.Address.Length);
            string actbalspace  = "                                        ".Remove(0, user.Balance.ToString().Length);
            string phonespace   = "                                              ".Remove(0, user.Phone.ToString().Length);
            string emailspace   = "                                              ".Remove(0, user.Email.Length);

            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                          Account Details                           |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
           Console.WriteLine(String.Format($"|         Account Number: {accountNumber}                            |"));
           Console.WriteLine(String.Format($"|         Account Balance:  {user.Balance}{actbalspace} |"));
           Console.WriteLine(String.Format($"|         First Name: {user.FirstName}{fnamespace} |"));
           Console.WriteLine(String.Format($"|         Last Name: {user.LastName}{lnamespace}  |"));
            Console.WriteLine(String.Format($"|         Address: {user.Address}{addressspace}    |"));                                                  
            Console.WriteLine(String.Format($"|         Phone: {user.Phone}{phonespace}      |"));
            Console.WriteLine(String.Format($"|         Email: {user.Email}{emailspace}      |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
        }

        
    }
}
