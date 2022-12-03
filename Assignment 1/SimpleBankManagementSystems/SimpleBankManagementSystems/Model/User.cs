using SimpleBankManagementSystems.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankManagementSystems.Model
{
    class User
    {
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public decimal Balance { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<AccountStatement> AccountStatements { get; set; }

        private static string _userInput;

        public User()
        {
            AccountStatements = new List<AccountStatement>();
        }

        /// <summary>
        /// The GetAccountNumberOfUser function allows the user to input the account number.
        /// If the user input is invalid, it clears the input and allows the user to
        /// reenter the account number.
        /// </summary>
        /// <returns></returns>
        public static int GetAccountNumberOfUser()
        {
            Console.SetCursorPosition(26, Console.CursorTop = 8);
            bool ctr = false;
            
            do
            {
                if (_userInput != String.Empty && _userInput != null)
                {
                    Utility.Clear(_userInput, 26, 8);
                    _userInput = String.Empty;
                }

                _userInput = Console.ReadLine();

                if (Utility.ValidateAccountNumber(_userInput) == true) ctr = true;
                else Utility.Clear(_userInput, 26, 8);

            } while (ctr == false);
            
            return Int32.Parse(_userInput);
        }

        public static int GetUserSelectedOption()
        {
            bool ctr = false;
            int selectedOption;
            string userInputForOption;
            do
            {
                userInputForOption = Console.ReadLine();

                if (int.TryParse(userInputForOption, out selectedOption) == true) ctr = true;
                else Utility.Clear(userInputForOption, 26, 16);

                Console.SetCursorPosition(26, Console.CursorTop = 16);
            } while (ctr == false);
            
            return selectedOption;
        }

        public static decimal GetAmountFromUser()
        {
            Console.SetCursorPosition(26, Console.CursorTop = 9);
            bool ctr = false;
            string userInput = String.Empty;
            do
            {
                if (userInput != String.Empty && userInput != null)
                {
                    Utility.Clear(userInput, 26, 9);
                    userInput = String.Empty;
                }

                userInput = Console.ReadLine();

                if (Utility.ValidateDigit(userInput) == true) ctr = true; 
                else Utility.Clear(userInput, 26, 9);

            } while (ctr == false);
            
            return decimal.Parse(userInput);
        }

        public static string GetFirstNameOfUser()
        {
            Console.SetCursorPosition(22, Console.CursorTop = 8);
            return Console.ReadLine();
        }

        public static string GetLastNameOfUser()
        {
            Console.SetCursorPosition(22, Console.CursorTop = 9);
            return Console.ReadLine();
        }

        public static string GetAddressOfUser()
        {
            Console.SetCursorPosition(22, Console.CursorTop = 10);
            return Console.ReadLine();
        }

        public static string GetPhoneOfUser()
        {
            Console.SetCursorPosition(22, Console.CursorTop = 11);
            bool ctr = false;
            string userInput;

            do
            {
                userInput = Console.ReadLine();

                if (Utility.ValidatePhoneNumber(userInput) == true) ctr = true;
                else Utility.Clear(userInput,22, 11);

            } while (ctr == false);

            return userInput;// Int32.Parse(userInput);
        }

        public static string GetEmailOfUser()
        {
            Console.SetCursorPosition(22, Console.CursorTop = 12);
            bool ctr = false;
            string userInput;

            do
            {
                userInput = Console.ReadLine();

                if (Utility.ValidateEmailAddress(userInput) == true) ctr = true;
                else Utility.Clear(userInput,22, 12);

            } while (ctr == false);

            return userInput;
        }
    }
}
