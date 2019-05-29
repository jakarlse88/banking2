using System;
using System.Collections.Generic;

namespace Banking
{
    /// <summary>
    /// Utility class for banking menu operations.
    /// </summary>
    public static class BankingMenuHandler
    {
        /// <summary>
        /// Enumerates the available banking menu options.
        /// </summary>
        private enum BankingMenuOptions { information, bankingOperations, exit, invalid = -1 };

        /// <summary>
        /// Enumerates the valid banking operations.
        /// </summary>
        private enum ValidBankingOperations { viewBalance, depositFunds, withdrawFunds };

        /// <summary>
        /// Maps the valid banking menu options to descriptive strings.
        /// </summary>
        private static readonly Dictionary<int, string> bankingOptions = new Dictionary<int, string>()
        {
            { (int)BankingMenuOptions.information, "Account holder information" },
            { (int)BankingMenuOptions.bankingOperations, "Banking operations" },
            { (int)BankingMenuOptions.exit, "Exit" }
        };

        /// <summary>
        /// Maps the valid banking operations to descriptive strings.
        /// </summary>
        private static readonly Dictionary<int, string> operationTypeOptions = new Dictionary<int, string>()
        {
            { (int)ValidBankingOperations.viewBalance, "View balance" },
            { (int)ValidBankingOperations.depositFunds, "Deposit funds" },
            { (int)ValidBankingOperations.withdrawFunds, "Withdraw funds" }
        };

        /// <summary>
        /// Maps the valid account types to descriptive strings.
        /// </summary>
        private static readonly Dictionary<int, string> accountTypeOptions = new Dictionary<int, string>()
        {
            { (int)BankingAccount.ValidAccountTypes.checking, "Checking" },
            { (int)BankingAccount.ValidAccountTypes.savings, "Savings" }
        };

        /// <summary>
        /// Gets and validates integer input from user.
        /// </summary>
        /// <returns>A validated int.</returns>
        private static int GetIntInput()
        {
            int userInput;

            try
            {
                userInput = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                userInput = (int)BankingMenuOptions.invalid;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                userInput = (int)BankingMenuOptions.invalid;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                userInput = (int)BankingMenuOptions.invalid;
            }

            return userInput;
        }

        /// <summary>
        /// Manages the banking options sub-menu.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        private static void ManageBankingOptions(AccountHolder currentUser)
        {
            int? currentAccountType = null;
            int? currentOperationType = null;

            while (currentAccountType == null)
            {
                currentAccountType = SelectAccountType();
            }

            string currentAccountName = Enum.GetName(typeof(BankingAccount.ValidAccountTypes), currentAccountType);
            Console.WriteLine($"{currentAccountName} is selected.");

            while (currentOperationType == null)
            {
                currentOperationType = SelectOperationType();
            }

            string currentOperationTypeName = Enum.GetName(typeof(ValidBankingOperations), currentOperationType);
            Console.WriteLine($"{currentOperationTypeName} is selected.");

            switch (currentOperationType)
            {
                case ((int)ValidBankingOperations.viewBalance):
                    PrintAccountBalance(currentUser, (int)currentAccountType);
                    break;

                case ((int)ValidBankingOperations.depositFunds):
                    DepositToAccount(currentUser, (int)currentAccountType);
                    break;

                case ((int)ValidBankingOperations.withdrawFunds):
                    WithdrawFromAccount(currentUser, (int)currentAccountType);
                    break;
            }
        }

        /// <summary>
        /// Selects a valid account type.
        /// </summary>
        /// <returns>A nullable integer that corresponds to the chosen menu option.</returns>
        private static int? SelectAccountType()
        {
            Console.WriteLine();
            Console.WriteLine("Please select from the below options:");

            foreach (KeyValuePair<int, string> entry in accountTypeOptions)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            return HandleAccountTypeSelection();
        }

        /// <summary>
        /// Selects a valid operation type.
        /// </summary>
        /// <returns>A nullable integer that corresponds to the chosen menu option.</returns>
        private static int? SelectOperationType()
        {
            Console.WriteLine();
            Console.WriteLine("Please select from the below options:");

            foreach (KeyValuePair<int, string> entry in operationTypeOptions)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            return HandleOperationTypeSelection();
        }

        /// <summary>
        /// Handles the account type selection.
        /// </summary>
        /// <returns>A nullable integer that corresponds to the chosen menu option.</returns>
        private static int? HandleAccountTypeSelection()
        {
            int userInput = GetIntInput();

            if (Enum.IsDefined(typeof(BankingAccount.ValidAccountTypes), userInput))
            {
                return (userInput == (int)BankingAccount.ValidAccountTypes.checking) ?
                    (int)BankingAccount.ValidAccountTypes.checking :
                    (int)BankingAccount.ValidAccountTypes.savings;
            }
            else
            {
                Console.WriteLine("Invalid account type specified. Please try again.");
                return null;
            }
        }

        /// <summary>
        /// Handles the operation type selection.
        /// </summary>
        /// <returns>A nullable integer that corresponds to the chosen menu option.</returns>
        private static int? HandleOperationTypeSelection()
        {
            int userInput = GetIntInput();

            if (Enum.IsDefined(typeof(ValidBankingOperations), userInput))
            {
                switch (userInput)
                {
                    case ((int)ValidBankingOperations.viewBalance):
                        return (int)ValidBankingOperations.viewBalance;

                    case ((int)ValidBankingOperations.depositFunds):
                        return (int)ValidBankingOperations.depositFunds;

                    case ((int)ValidBankingOperations.withdrawFunds):
                        return (int)ValidBankingOperations.withdrawFunds;
                }
            }

            return null;
        }

        /// <summary>
        /// Displays the banking menu options.
        /// </summary>
        private static void DisplayBankingMenuOptions()
        {
            Console.WriteLine("Please select from the below options:");

            foreach (KeyValuePair<int, string> entry in bankingOptions)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        /// <summary>
        /// Handles case "I" -- view account holder information
        /// </summary>
        /// <param name="currentUser">The current user, whose information will be viewed.</param>
        private static void PrintInformation(AccountHolder currentUser)
        {
            Console.WriteLine();
            Console.WriteLine($"Viewing the account of {currentUser.LastName}, {currentUser.FirstName} with account #{currentUser.AccountNumber}");
            Console.WriteLine();

            _Utilities.WriteResultToFile(currentUser, "I");
        }

        /// <summary>
        /// Returns the balance of the current user's specified account.
        /// </summary>
        /// <param name="currentUser">The current user, whose information will be viewed.</param>
        /// <param name="accountType">The type of account of which to get the balance.</param>
        private static void PrintAccountBalance(AccountHolder currentUser, int accountType)
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

            _Utilities.WriteResultToFile(currentUser, "I");
        }

        /// <summary>
        /// Deposits a specified amount to the specified account type of the current user.
        /// </summary>
        /// <param name="currentUser">The current user, into whose account money will be deposited.</param>
        /// <param name="accountType">The type of account into which to deposit.</param>
        private static void DepositToAccount(AccountHolder currentUser, int accountType)
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

            decimal amountToDeposit = _Utilities.GetDecimalInput(Console.ReadLine());

            try
            {
                currentAccount.DepositFunds(amountToDeposit);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            _Utilities.WriteResultToFile(currentUser, "deposit", accountType, amountToDeposit);
        }

        /// <summary>
        /// Withdraws an amount from the specified account of the current user.
        /// </summary>
        /// <param name="currentUser">The current user, from whose account money will be withdrawn.</param>
        /// <param name="accountType">The type of account from which to withdraw.</param>
        private static void WithdrawFromAccount(AccountHolder currentUser, int accountType)
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

            decimal amountToWithdraw = _Utilities.GetDecimalInput(Console.ReadLine());

            try
            {
                currentAccount.WithdrawFunds(amountToWithdraw);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            _Utilities.WriteResultToFile(currentUser, "withdrawal", accountType, amountToWithdraw);
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
            int userInput = GetIntInput();

            if (userInput != (int)BankingMenuOptions.invalid)
            {
                switch (userInput)
                {
                    case ((int)BankingMenuOptions.information):
                        PrintInformation(currentUser);
                        break;

                    case ((int)BankingMenuOptions.bankingOperations):
                        ManageBankingOptions(currentUser);
                        break;

                    case ((int)BankingMenuOptions.exit):
                        ExitBankingMenu(ref displayMenu);
                        break;
                }
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

            do
            {
                Console.WriteLine("Hit [ENTER] to display banking menu.");
                if (Console.ReadKey(true).Key.ToString() == "Enter")
                {
                    DisplayBankingMenuOptions();
                    HandleUserMenuChoice(currentUser, ref displayMenu);
                }
            } while (displayMenu);
        }
    }
}