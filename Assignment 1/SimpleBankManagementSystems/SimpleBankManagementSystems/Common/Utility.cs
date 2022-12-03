using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleBankManagementSystems.Common;
using SimpleBankManagementSystems.Interfaces;
using SimpleBankManagementSystems.View;

namespace SimpleBankManagementSystems.Common
{
    class Utility
    {
        public static int GetUserInputFromMainMenu()
        {
            Console.SetCursorPosition(4, Console.CursorTop = 15);
            Console.Write("Enter your choice (1-7): ");
            string userInput;
            int menuCode;
            bool success;

            try
            {
                do {
                    userInput = Console.ReadLine();
                    success = Int32.TryParse(userInput, out menuCode);
                    if (success == true)
                    {
                        Console.SetCursorPosition(4, Console.CursorTop = 18);
                        Console.WriteLine();

                        return menuCode;
                    }
                    else
                    {
                        Console.SetCursorPosition(29, Console.CursorTop = 15);
                        Utility.Clear(userInput,29, 15);
                        continue;
                    }
                } while (success == false);
            }
            catch (FormatException fe)
            {
                Console.SetCursorPosition(0, Console.CursorTop = 20);
                Console.WriteLine(fe.Message);

            }
            catch (Exception e)
            {
                Console.SetCursorPosition(0, Console.CursorTop = 20);
                Console.WriteLine(e.Message);
            }

            return 0;
        }

        /// <summary>
        /// A function that clears the user input and sets 
        /// the cursor to its starting point.
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="LeftCursor"></param>
        /// <param name="TopCursor"></param>
        public static void Clear(string userInput, int LeftCursor, int TopCursor = 11)
        {
            Console.SetCursorPosition(LeftCursor, Console.CursorTop = TopCursor);
            for (int i = 0; i < userInput.Length; i++)
                Console.Write(" ");

            Console.SetCursorPosition(LeftCursor, Console.CursorTop = TopCursor);
        }


        /// <summary>
        /// It validates the user input and checks if the input contains 
        /// only digits and it should be 10 digits only. 
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>bool</returns>
        public static bool ValidatePhoneNumber(string userInput)
        {
            string digitRegex = @"^\w{10}$";
            Regex rx = new Regex(digitRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(userInput) == true ? true : false;
        }

        /// <summary>
        /// The ValidateDigit uses Regex to ensure that the user won't be 
        /// able to input values like (2+5*3) + 5 when performing deposits
        /// and withdrawals.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static bool ValidateDigit(string userInput)
        {
            string digitRegex = @"^(?!\(\)\-.*\+)\d{1,5}$"; 
            Regex rx = new Regex(digitRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(userInput) == true ? true : false;
        }

        /// <summary>
        /// The ValidateAccountNumber uses Regex to perform pattern 
        /// matching based on the given search pattern. It basically
        /// checks if the parameter contains 6-8 digits and if its a 
        /// digit.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>bool</returns>
        public static bool ValidateAccountNumber(string userInput)
        {
            string digitRegex = @"^\w{6,8}$";
            Regex rx = new Regex(digitRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(userInput) == true ? true : false;
        }

        /// <summary>
        /// Validates user input and checks if the string 
        /// contains a valid email address
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>bool</returns>
        public static bool ValidateEmailAddress(string userInput)
        {
            string emailRegex = @"((^\w).+@.+\..+)";
            Regex rx = new Regex(emailRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return rx.IsMatch(userInput) == true ? true : false;
        }

        /// <summary>
        /// Responsible for calculating the deposit and account withrawal.
        /// The Calculate function accepts the current balance, the out message 
        /// to be displayed, amount to be deposited and the operation to perform.
        /// It returns the updated balance.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="output"></param>
        /// <param name="tempDeposit"></param>
        /// <param name="operation"></param>
        /// <returns>decimal</returns>
        public static decimal Calculate(decimal currentBalance, out string message, decimal amount, string operation = "")
        {
            string errorMessage = "Unexpected error. Please contact the developer.";

            switch (operation)
            {
                case "deposit":
                    message = "Deposit";
                    decimal sum = currentBalance + amount;
                    errorMessage = "You cannot deposit an amount with a negative value";
                    if (amount < 0 || sum < 0) throw new Exception(errorMessage);

                    return sum;
                case "withdraw":
                    message = "Withdraw";
                    decimal difference = currentBalance - amount;
                    errorMessage = "you cannot withdraw an amount exceeding with your current balance";
                    if (amount < 0 || difference < 0) throw new Exception(errorMessage);
                    
                    return difference;
                default:
                    throw new Exception(errorMessage);
            }
        }

        public static IView ProcessInput(int userInput)
        {
            switch (userInput)
            {
                case (int)Menu.CreateAccount:
                    return new CreateAccountView();
                case (int)Menu.SearchAccount:
                    return new SearchAccountView();
                case (int)Menu.Deposit:
                    return new DepositAccountView();
                case (int)Menu.Withdraw:
                    return new WithdrawAccountView();
                case (int)Menu.Statement:
                    return new StatementAccountView();
                case (int)Menu.DeleteAccount:
                    return new DeleteAccountView();
                case (int)Menu.Exit:
                    Environment.Exit(0);
                    return null;
                default:
                    return new MainMenuView();
            }
        }
        
    }
    public enum Menu : int
    {
        CreateAccount = 1,
        SearchAccount = 2,
        Deposit = 3,
        Withdraw = 4,
        Statement = 5,
        DeleteAccount = 6,
        Exit = 7,
        None = 8
    }
}
