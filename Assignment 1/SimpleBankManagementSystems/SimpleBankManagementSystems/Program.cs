using SimpleBankManagementSystems.Classes;
using SimpleBankManagementSystems.Common;
using SimpleBankManagementSystems.Controller;
using SimpleBankManagementSystems.Interfaces;
using SimpleBankManagementSystems.Model;
using SimpleBankManagementSystems.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems
{
    class Program
    {
        public static int menuSelected;

        static void Main(string[] args)
        {
            SessionView loginMenu = new SessionView();
            loginMenu.RenderView();

            SessionController session = new SessionController();
            session.Login();
            IView view;

            do
            {
                MainMenuView mainMenu = new MainMenuView();
                mainMenu.AccessMainMenu(session.TokenId);
                mainMenu.RenderView();

                menuSelected = Utility.GetUserInputFromMainMenu();
                
                view = Utility.ProcessInput(menuSelected);
                Program.Display(view);

            } while (view != null ); 
        }

        public static void Display(IView view)
        {
            IFileManager fileManager = new FileManager();
            IEmail gmail = new Gmail();
            SavingsAccountController savingsAccount = new SavingsAccountController(fileManager, gmail);
            if (view.GetType() == typeof(CreateAccountView))
            {
                view.RenderView();
                savingsAccount.CreateAccount(new User
                {
                    FirstName = User.GetFirstNameOfUser(),
                    LastName = User.GetLastNameOfUser(),
                    Address = User.GetAddressOfUser(),
                    Phone = User.GetPhoneOfUser(),
                    Email = User.GetEmailOfUser()
                });
            }
            else if (view.GetType() == typeof(SearchAccountView)) 
            {
                view.RenderView();
                savingsAccount.SearchAccount(new User (), view as SearchAccountView);
            }
            else if (view.GetType() == typeof(DepositAccountView)) 
            {
                view.RenderView();
                
                savingsAccount.DepositAccount(new User(), view as DepositAccountView);
            }
            else if (view.GetType() == typeof(WithdrawAccountView))
            {
                view.RenderView();

                savingsAccount.WithdrawAccount(new User(), view as WithdrawAccountView);
            }
            else if (view.GetType() == typeof(StatementAccountView))
            {
                view.RenderView();

                savingsAccount.Statement(new User(), view as StatementAccountView);
            }
            else if (view.GetType() == typeof(DeleteAccountView))
            {
                view.RenderView();

                savingsAccount.DeleteAccount(new User(), view as DeleteAccountView);
            }
        }
       
    }
}
