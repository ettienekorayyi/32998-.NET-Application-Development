using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.View
{
    class SessionView
    {
        public void RenderView()
        {
            Console.WriteLine(String.Format("======================================================================")); 
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                  Welcome to Simple Banking System                  |")); 
            Console.WriteLine(String.Format("|                                                                    |")); 
            Console.WriteLine(String.Format("======================================================================"));
            Console.WriteLine(String.Format("|                           Login to start                           |"));  
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("|         Username:                                                  |"));
            Console.WriteLine(String.Format("|         Password:                                                  |"));
            Console.WriteLine(String.Format("|                                                                    |"));
            Console.WriteLine(String.Format("======================================================================"));
        }

    }
}
