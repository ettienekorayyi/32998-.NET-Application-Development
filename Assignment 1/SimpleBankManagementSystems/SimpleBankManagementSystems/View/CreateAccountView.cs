using SimpleBankManagementSystems.Common;
using SimpleBankManagementSystems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.View
{
    class CreateAccountView : IView
    {
        public void RenderView()
        {
            Console.Clear();
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                        Create a New Account                        |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                         Enter the details                          |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|         First Name:                                                |"));
            Console.WriteLine(String.Format("|         Last Name:                                                 |"));
            Console.WriteLine(String.Format("|         Address:                                                   |"));
            Console.WriteLine(String.Format("|         Phone:                                                     |"));
            Console.WriteLine(String.Format("|         Email                                                      |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
        }

    }
}
