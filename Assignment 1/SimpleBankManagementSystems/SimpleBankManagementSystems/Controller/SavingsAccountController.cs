
using SimpleBankManagementSystems.Classes;
using SimpleBankManagementSystems.Common;
using SimpleBankManagementSystems.Interfaces;
using SimpleBankManagementSystems.Model;
using SimpleBankManagementSystems.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.Controller
{
    class SavingsAccountController :  IAccounts
    {
        private IFileManager _fileManager;
        private IEmail _gmail;
        private int _accountNumber = 0;
        private string _operation = String.Empty;

        /// <summary>
        /// I've tried using the Poor man's dependency injection to 
        /// make the constructor loosely coupled.
        /// </summary>
        public SavingsAccountController(IFileManager fileManager, IEmail gmail)
        {
            _fileManager = fileManager;
            _accountNumber = _fileManager.GetAccountNumberFromFileName(); 
            _gmail = gmail;
            
        }

        /// <summary>
        /// Responsible for handling account creation. When the account has been 
        /// successfully created, it should generate an email.
        /// </summary>
        /// <param name="user"></param>
        public void CreateAccount(User user)
        {
            string subject = "Your bank account has been created successfully.";
            user.AccountNumber = _accountNumber;
            if (_fileManager.CreateFile(user) == true)
            {
                _gmail.SendEmail(user, _accountNumber, subject);
            }
            Console.Write("Press any key to go back to main menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// The doesFileExists variable on line 102 forces
        /// </summary>
        /// <param name="user"></param>
        /// <param name="view"></param>
        public void SearchAccount(User user, SearchAccountView view)
        { 
            bool doesFileExists;
            string findAgain = String.Empty;
            do
            {
                do
                {
                    if (findAgain == "y")
                    {
                        view.RenderView();
                        findAgain = "n";
                    }

                    user.AccountNumber = User.GetAccountNumberOfUser();
                    doesFileExists = _fileManager.CheckFileExists(user.AccountNumber);

                    if (doesFileExists == true)
                    {
                        var result = _fileManager.FindAccount(user);

                        view.DisplayAccount(result);
                        Console.SetCursorPosition(0, Console.CursorTop = 12);
                        Console.Write("Check another account(y/n)?");
                        findAgain = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        string paragraph = "Account not found!\nWhat do you want to do?:\n1. Try again\n2. Go back to main menu\nEnter your choice: (1-2): ";
                        Console.SetCursorPosition(0, Console.CursorTop = 12);
                        Console.Write(paragraph);

                        int selectedOption = User.GetUserSelectedOption();
                        if (selectedOption == 1) 
                        {
                            paragraph += selectedOption;
                            var arr = paragraph.Split('\n');
                            for (int iterator = 0; iterator < arr.Length; iterator++) Utility.Clear(arr[iterator], 0, 12+ iterator);

                            Utility.Clear(user.AccountNumber.ToString(), 26, 8);

                            continue;
                        }
                        else
                        {
                            findAgain = "n";
                            doesFileExists = true; 
                        }
                    }
                } while (findAgain == "y");
            } while (!doesFileExists);
        }

        /// <summary>
        /// The DepositAccount initiates the deposit process.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="view"></param>
        public void DepositAccount(User user, DepositAccountView view)
        {
            bool doesFileExists;
            string findAgain = String.Empty;
            do
            {
                do
                {
                    if (findAgain == "y")
                    {
                        view.RenderView();
                        findAgain = "n";
                        user.AccountNumber = 0;
                        user.FirstName = String.Empty;
                        user.LastName = String.Empty;
                        user.Address = String.Empty;
                        user.Balance = 0;
                        user.Phone = String.Empty;
                        user.Email = String.Empty;
                        user.AccountStatements.Clear();
                    }

                    user.AccountNumber = User.GetAccountNumberOfUser();
                    
                    doesFileExists = _fileManager.CheckFileExists(user.AccountNumber);

                    if (doesFileExists == true)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Account Found! Please enter the amount.");
                        
                       _fileManager.UpdateAccount(user, _operation = "deposit");

                        Console.Write("Check another account(y/n)?");
                        findAgain = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        string paragraph = "Account not found!\nWhat do you want to do?:\n1. Try again\n2. Go back to main menu\nEnter your choice: (1-2): ";
                        Console.SetCursorPosition(0, Console.CursorTop = 12);
                        Console.Write(paragraph);

                        int selectedOption = User.GetUserSelectedOption();
                        if (selectedOption == 1)
                        {
                            paragraph += selectedOption;
                            var arr = paragraph.Split('\n');
                            for (int iterator = 0; iterator < arr.Length; iterator++) Utility.Clear(arr[iterator], 0, 12 + iterator);

                            Utility.Clear(user.AccountNumber.ToString(), 26, 8);

                            continue;
                        }
                        else
                        {
                            findAgain = "n";
                            doesFileExists = true; 
                        }
                    }
                } while (findAgain == "y");
            } while (!doesFileExists);
        }

        /// <summary>
        /// The WithdrawAccount function Initiates the withdrawal process.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="view"></param>
        public void WithdrawAccount(User user, WithdrawAccountView view)
        {
            bool doesFileExists;
            string findAgain = String.Empty;
            do
            {
                do
                {
                    if (findAgain == "y")
                    {
                        view.RenderView();
                        findAgain = "n";
                        user.AccountNumber = 0;
                        user.FirstName = String.Empty;
                        user.LastName = String.Empty;
                        user.Address = String.Empty;
                        user.Balance = 0;
                        user.Phone = String.Empty;
                        user.Email = String.Empty;
                        user.AccountStatements.Clear();
                    }

                    user.AccountNumber = User.GetAccountNumberOfUser();

                    doesFileExists = _fileManager.CheckFileExists(user.AccountNumber);

                    if (doesFileExists == true)
                    {
                        Console.WriteLine("\n\n\nAccount Found! Please enter the amount.");
                        
                        _fileManager.UpdateAccount(user, _operation = "withdraw");

                        Console.Write("Check another account(y/n)?");
                        findAgain = Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        string paragraph = "Account not found!\nWhat do you want to do?:\n1. Try again\n2. Go back to main menu\nEnter your choice: (1-2): ";
                        Console.SetCursorPosition(0, Console.CursorTop = 12);
                        Console.Write(paragraph);

                        int selectedOption = User.GetUserSelectedOption();
                        if (selectedOption == 1)
                        {
                            paragraph += selectedOption;
                            var arr = paragraph.Split('\n');
                            for (int iterator = 0; iterator < arr.Length; iterator++) Utility.Clear(arr[iterator], 0, 12 + iterator);

                            Utility.Clear(user.AccountNumber.ToString(), 26, 8);

                            continue;
                        }
                        else
                        {
                            findAgain = "n";
                            doesFileExists = true; 
                        }
                    }

                } while (findAgain == "y");
            } while (!doesFileExists);
        }

        /// <summary>
        /// The Statement function displays the top 3 most recent transaction made
        /// on a given account. The comprehensive list of transactions can be viewed
        ///  by choosing to send the email.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="view"></param>
        public void Statement(User user, StatementAccountView view)
        {
            string subject = "Your Account Statement.";
            bool doesFileExists;
            string findAccount = String.Empty;
            do
            {
                do
                {
                    if (findAccount == "y")
                    {
                        view.RenderView();
                        findAccount = "n";
                    }

                    user.AccountNumber = User.GetAccountNumberOfUser();

                    doesFileExists = _fileManager.CheckFileExists(user.AccountNumber);

                    if (doesFileExists == true)
                    {
                        var result = _fileManager.GetAccountStatement(user);

                        view.DisplayAccount(result);
                        
                        Console.Write("Email statement (y/n)?");
                        string sendEmail = Console.ReadLine();

                        if (sendEmail.ToLower() == "y") _gmail.SendEmail(user, user.AccountNumber, subject);

                        Console.Write("Press any key to go back to main menu:");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        string paragraph = "Account not found!\nWhat do you want to do?:\n1. Try again\n2. Go back to main menu\nEnter your choice: (1-2): ";
                        Console.SetCursorPosition(0, Console.CursorTop = 12);
                        Console.Write(paragraph);

                        int selectedOption = User.GetUserSelectedOption();
                        if (selectedOption == 1)
                        {
                            paragraph += selectedOption;
                            var arr = paragraph.Split('\n');
                            for (int iterator = 0; iterator < arr.Length; iterator++) Utility.Clear(arr[iterator], 0, 12 + iterator);

                            Utility.Clear(user.AccountNumber.ToString(), 26, 8);

                            continue;
                        }
                        else
                        {
                            findAccount = "n";
                            doesFileExists = true; 
                        }
                    }
                } while (findAccount == "y");
            } while (!doesFileExists);
        }

        // DeleteAccount: void
        public void DeleteAccount(User user, DeleteAccountView view)
        {
            bool doesFileExists;
            string findAccount = String.Empty;
            do
            {
                do
                {
                    if (findAccount == "y")
                    {
                        view.RenderView();
                        findAccount = "n";
                    }

                    user.AccountNumber = User.GetAccountNumberOfUser();

                    doesFileExists = _fileManager.CheckFileExists(user.AccountNumber);

                    if (doesFileExists == true)
                    {
                        var result = _fileManager.FindAccount(user);

                        view.DisplayAccount(result);

                        Console.Write("Delete this account (y/n)?");
                        string deleteAccount = Console.ReadLine();

                        if (deleteAccount.ToLower() == "y") _fileManager.Delete(user);

                        Console.Write("Press any key to go back to main menu:");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        string userInput = "Account not found!\nWhat do you want to do?:\n1. Try again\n2. Go back to main menu\nEnter your choice: (1-2): ";
                        Console.SetCursorPosition(0, Console.CursorTop = 12);
                        Console.Write(userInput);

                        string option = Console.ReadLine();

                        if (int.Parse(option) == 1)
                        {
                            var arr = userInput.Split('\n');
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Utility.Clear(arr[i], 0, 12 + i);
                            }
                            continue;
                        }
                        else
                        {
                            findAccount = "n";
                            doesFileExists = true; // forces the page to go back to main menu
                        }

                        Utility.Clear(userInput, 0, 12);
                    }
                } while (findAccount == "y");
            } while (!doesFileExists);
        }
    }
}
