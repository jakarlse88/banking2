﻿using System;
using System.Collections.Generic;
using System.IO;

namespace banking
{
    /// <summary>
    /// Utility class for banking menu operations.
    /// </summary>
    static class BankingMenuHandler
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

        // Maps banking options to relevant case handlers
        static readonly Dictionary<string, Action<AccountHolder>> caseHandlerDictionary = new Dictionary<string, Action<AccountHolder>>()
        {
            { "I", HandleCaseI },
            { "CB", HandleCaseCB },
            { "CD", HandleCaseCD },
            { "CW", HandleCaseCW },
            { "SB", HandleCaseSB },
            { "SD", HandleCaseSD },
            { "SW", HandleCaseSW },
        };

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
        /// Writes user, operation type, and transaction amount to log file.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="operationType">The type of operation.</param>
        /// <param name="transactionAmount">The transaction amount.</param>
        private static void WriteResultToFile(AccountHolder currentUser, string operationType, decimal transactionAmount)
        {
            string logMessage = $"{currentUser.LastName}, {currentUser.FirstName} - #{currentUser.AccountNumber}";
            logMessage += $"{operationType} - {bankingOptions[operationType]} ";
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

        private static void HandleCaseI(AccountHolder currentUser)
        {
            Console.WriteLine();
            Console.WriteLine($"Viewing the account of {currentUser.LastName}, {currentUser.FirstName} with account #{currentUser.AccountNumber}");
            Console.WriteLine();

            WriteResultToFile(currentUser, "I");
        }

        private static void HandleCaseCB(AccountHolder currentUser)
        {
            BankingAccount currentAccount = currentUser.CheckingAccount;

            Console.WriteLine("");
            Console.WriteLine($"{currentUser.LastName}, {currentUser.FirstName}'s checking account has a balance of {currentAccount.ViewBalance():c}");
            Console.WriteLine("");

            WriteResultToFile(currentUser, "CB");
        }

        private static void HandleCaseCD(AccountHolder currentUser)
        {
            BankingAccount currentAccount = currentUser.CheckingAccount;

            Console.WriteLine("");
            Console.WriteLine($"Depositing to {currentUser.LastName}, {currentUser.FirstName}'s checking account. Please specify an amount:");
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

            WriteResultToFile(currentUser, "CD", amountToDeposit);
        }

        private static void HandleCaseCW(AccountHolder currentUser)
        {
            BankingAccount currentAccount = currentUser.CheckingAccount;

            Console.WriteLine("");
            Console.WriteLine($"Withdrawing from {currentUser.LastName}, {currentUser.FirstName}'s checking account. Please specify an amount:");
            Console.Write("$");

            decimal amountToWithdraw = 0;

            try
            {
                amountToWithdraw = Decimal.Parse(Console.ReadLine());
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

            WriteResultToFile(currentUser, "CW", amountToWithdraw);
        }

        private static void HandleCaseSB(AccountHolder currentUser)
        {
            BankingAccount currentAccount = currentUser.SavingsAccount;

            Console.WriteLine("");
            Console.WriteLine($"{currentUser.LastName}, {currentUser.FirstName}'s savings account has a balance of {currentAccount.ViewBalance():c}");
            Console.WriteLine("");

            WriteResultToFile(currentUser, "SB");
        }

        private static void HandleCaseSD(AccountHolder currentUser)
        {
            BankingAccount currentAccount = currentUser.SavingsAccount;

            Console.WriteLine("");
            Console.WriteLine($"Depositing to {currentUser.LastName}, {currentUser.FirstName}'s savings account. Please specify an amount:");
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

            WriteResultToFile(currentUser, "SD", amountToDeposit);
        }

        private static void HandleCaseSW(AccountHolder currentUser)
        {
            BankingAccount currentAccount = currentUser.SavingsAccount;

            Console.WriteLine("");
            Console.WriteLine($"Withdrawing from {currentUser.LastName}, {currentUser.FirstName}'s savings account. Please specify an amount:");
            Console.Write("$");

            decimal amountToWithdraw = 0;

            try
            {
                amountToWithdraw = Decimal.Parse(Console.ReadLine());
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

            WriteResultToFile(currentUser, "SW", amountToWithdraw);
        }

        private static void HandleCaseX(ref bool displayMenu)
        {
            Console.WriteLine("Exiting banking menu.");
            displayMenu = false;
        }

        private static void HandleUserMenuChoice(AccountHolder currentUser, ref bool displayMenu)
        {
            string userInput = Console.ReadLine().ToUpper();

            if (bankingOptions.ContainsKey(userInput) && userInput != "X")
            {
                caseHandlerDictionary[userInput](currentUser);
            }
            else if (userInput == "X")
            {
                HandleCaseX(ref displayMenu);
            }
            else
            {
                System.Console.WriteLine("Invalid option.");
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
                System.Console.WriteLine("Hit [ENTER] to display banking menu.");
                if (Console.ReadKey(true).Key.ToString() == "Enter")
                {
                    DisplayBankingMenuOptions();
                    HandleUserMenuChoice(currentUser, ref displayMenu);
                }
            }

        }
    }
}
