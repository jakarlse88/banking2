using System;
using System.Collections.Generic;
using System.IO;

namespace Banking
{
    /// <summary>
    /// Utility class for banking menu operations.
    /// </summary>
    public static class BankingMenuHandler
    {
        // Banking menu options
        static readonly Dictionary<string, string> bankingOptions = new Dictionary<string, string>()
            {
                { "I", "View account holder information" },
                { "CB", "Checking -- view balance" },
                { "CD", "Checking -- deposit funds" },
                { "CW", "Checking -- withdraw funds" },
                { "SB", "Savings -- view balance" },
                { "SD", "Savings -- deposit funds" },
                { "SW", "Savings -- withdraw funds" },
                { "X", "Exit banking menu" }
            };

        /// <summary>
        /// Maps banking options to relevant case handlers
        /// </summary>
        static readonly Dictionary<string, Action<AccountHolder, string>> caseHandlerDictionary = new Dictionary<string, Action<AccountHolder, string>>()
        {
            { "I", HandleCaseI },
            { "CB", GetAccountBalance },
            { "CD", DepositToAccount },
            { "CW", WithdrawFromAccount },
            { "SB", GetAccountBalance },
            { "SD", DepositToAccount },
            { "SW", WithdrawFromAccount },
        };

        static readonly Dictionary<string, string> optionsToAccountTypeDictionary = new Dictionary<string, string>
        {
            {"I", "information" },
            {"CB", "checking" },
            {"CD", "checking" },
            {"CW", "checking" },
            {"SB", "savings" },
            {"SD", "savings" },
            {"SW", "savings" },
        };

        /// <summary>
        /// Specifies the filepath to which logs are written.
        /// </summary>
        static readonly string logFile = "log.txt";

        /// <summary>
        /// Displays the banking menu options.
        /// </summary>
        private static void DisplayBankingMenuOptions()
        {
            Console.WriteLine("Please select from the below options:");

            foreach (KeyValuePair<string, string> entry in bankingOptions)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        /// <summary>
        /// Tries to parse a string value to a decimal.
        /// </summary>
        /// <param name="input">The string value to be parsed.</param>
        /// <returns></returns>
        public static decimal GetDecimalInput(string input)
        {
            try
            {
                return Decimal.Parse(input);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Writes user and operation type to log file.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="operationType">The type of operation.</param>
        private static void WriteResultToFile(AccountHolder currentUser, string operationType)
        {
            string logMessage = $"{currentUser.LastName}, {currentUser.FirstName} - #{currentUser.AccountNumber}";
            logMessage += $"{operationType} - {bankingOptions[operationType]}";

            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }

        /// <summary>
        /// Writes user, account type, operation type, and transaction amount to log file. 
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="accountType">The account type.</param>
        /// <param name="operationType">The type of operation.</param>
        /// <param name="transactionAmount">The transaction amount.</param>
        private static void WriteResultToFile(AccountHolder currentUser, string accountType, string operationType, decimal transactionAmount)
        {
            string logMessage = $"{currentUser.LastName}, {currentUser.FirstName} - #{currentUser.AccountNumber} ";
            logMessage += $"{accountType.ToUpper()} ";
            logMessage += $"{operationType} ";
            logMessage += $"Transaction amount: ${transactionAmount}";

            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }

        /// <summary>
        /// Handles case "I" -- view account holder information
        /// </summary>
        /// <param name="currentUser">The current user, whose information will be viewed.</param>
        private static void HandleCaseI(AccountHolder currentUser, string accountType)
        {
            Console.WriteLine();
            Console.WriteLine($"Viewing the account of {currentUser.LastName}, {currentUser.FirstName} with account #{currentUser.AccountNumber}");
            Console.WriteLine();

            WriteResultToFile(currentUser, "I");
        }

        /// <summary>
        /// Returns the balance of the current user's specified account.
        /// </summary>
        /// <param name="currentUser">The current user, whose information will be viewed.</param>
        /// <param name="accountType">The type of account of which to get the balance.</param>
        private static void GetAccountBalance(AccountHolder currentUser, string accountType)
        {
            BankingAccount currentAccount = currentUser.GetAccountByType(accountType);

            if (currentAccount == null)
            {
                Console.WriteLine("Error: invalid account type");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine($"{currentUser.LastName}, {currentUser.FirstName}'s {currentAccount.AccountType} account has a balance of {currentAccount.ViewBalance():c}");
            Console.WriteLine("");

            WriteResultToFile(currentUser, "I");
        }

        /// <summary>
        /// Deposits a specified amount to the specified account type of the current user.
        /// </summary>
        /// <param name="currentUser">The current user, into whose account money will be deposited.</param>
        /// <param name="accountType">The type of account into which to deposit.</param>
        private static void DepositToAccount(AccountHolder currentUser, string accountType)
        {
            BankingAccount currentAccount = currentUser.GetAccountByType(accountType);

            if (currentAccount == null)
            {
                Console.WriteLine("Error: invalid account type");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine($"Depositing to {currentUser.LastName}, {currentUser.FirstName}'s {currentAccount.AccountType} account. Please specify an amount:");
            Console.Write("$");

            decimal amountToDeposit = 0;

            try
            {
                amountToDeposit = Decimal.Parse(Console.ReadLine());
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Input must consist wholly of numbers.");
            }

            currentAccount.DepositFunds(amountToDeposit);

            WriteResultToFile(currentUser, accountType, "deposit", amountToDeposit);
        }

        /// <summary>
        /// Withdraws an amount from the specified account of the current user.
        /// </summary>
        /// <param name="currentUser">The current user, from whose account money will be withdrawn.</param>
        /// <param name="accountType">The type of account from which to withdraw.</param>
        private static void WithdrawFromAccount(AccountHolder currentUser, string accountType)
        {
            BankingAccount currentAccount = currentUser.GetAccountByType(accountType);

            if (currentAccount == null)
            {
                Console.WriteLine("Error: invalid account type");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine($"Withdrawing from {currentUser.LastName}, {currentUser.FirstName}'s {currentAccount.AccountType} account. Please specify an amount:");
            Console.Write("$");

            decimal amountToWithdraw = 0;

            try
            {
                amountToWithdraw = decimal.Parse(Console.ReadLine());
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Input must consist wholly of numbers.");
            }

            currentAccount.WithdrawFunds(amountToWithdraw);

            WriteResultToFile(currentUser, accountType, "withdrawal", amountToWithdraw);
        }

        /// <summary>
        /// Exits the banking menu.
        /// </summary>
        /// <param name="displayMenu">References a bool that decides whether to show the menu.</param>
        private static void ExitBankingMenu(ref bool displayMenu)
        {
            Console.WriteLine("Exiting banking menu.");
            displayMenu = false;
        }

        /// <summary>
        /// Handles user's menu choice.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="displayMenu">References a bool that decides whether to show the menu.</param>
        private static void HandleUserMenuChoice(AccountHolder currentUser, ref bool displayMenu)
        {
            string userInput = Console.ReadLine().ToUpper();

            if (bankingOptions.ContainsKey(userInput) && userInput != "X")
            {
                caseHandlerDictionary[userInput](currentUser, optionsToAccountTypeDictionary[userInput]);
            }
            else if (userInput == "X")
            {
                ExitBankingMenu(ref displayMenu);
            }
            else
            {
                Console.WriteLine("Invalid option.");
                DisplayBankingMenuOptions();
            }

        }

        /// <summary>
        /// Prints the banking menu to terminal, and handles user choice.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        public static void ExecuteBankingMenu(AccountHolder currentUser)
        {
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.WriteLine("Hit [ENTER] to display banking menu.");
                if (Console.ReadKey(true).Key.ToString() == "Enter")
                {
                    DisplayBankingMenuOptions();
                    HandleUserMenuChoice(currentUser, ref displayMenu);
                }
            }

        }
    }
}
