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
    class StatementAccountView : IView
    {
        public void RenderView()
        {
            Console.Clear();
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                              Statement                             |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                         Enter the details                          |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|         Account Number:                                            |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
        }

        
        public void DisplayAccount(User user)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Account Found! The statement is listed below. ");
            string accountNumber = user.AccountNumber.ToString() + "         ";
            string fullnamespace = new string(' ', 46).Remove(0, user.LastName.Length + user.FirstName.Length);
            string addressspace = new string(' ', 46).Remove(0, user.Address.Length);
            string actbalspace = new string(' ', 40).Remove(0, user.Balance.ToString().Length);

            int current = user.AccountStatements.Count() - 3;
            int topThree = user.AccountStatements.Count() - current;
            user.AccountStatements.Reverse();
            var statements = user.AccountStatements.Take(topThree);

            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                          Account Details                           |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
             Console.WriteLine(String.Format("|         Account Statement                                          |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format($"|         Account Number: {accountNumber}                            |"));
            Console.WriteLine(String.Format($"|         Name: {user.LastName},{user.FirstName}{fullnamespace}      |"));
            Console.WriteLine(String.Format($"|         Address: {user.Address}{addressspace}    |"));
            Console.WriteLine(String.Format($"|         Account Balance:  {user.Balance}{actbalspace} |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|         Top 3 Statement Summary:                                   |"));

            foreach (var st in statements) 
            {
                int totalLength = st.Date.Length + st.Transaction.Length + st.TransactionAmount.Length + st.Balance.Length;
                string statementspace = new string(' ', 46).Remove(0, totalLength);
                Console.WriteLine(String.Format($"|         {st.Date}  {st.Transaction}  {st.TransactionAmount} {st.Balance} {statementspace}       |"));
            }
           
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));


        }
    }
}
