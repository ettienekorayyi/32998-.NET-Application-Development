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
    class WithdrawAccountView : IView
    {
        public void RenderView()
        {
            Console.Clear();
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                              Withdraw                              |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                         Enter the details                          |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|         Account Number:                                            |"));
            Console.WriteLine(String.Format("|         Amount: $                                                  |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
        }

    }
}
