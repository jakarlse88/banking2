using Banking.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    /// <summary>
    /// The BankingAccount class contains balance and account type state,
    /// and the operations that can be performed on these.
    /// </summary>
    public class BankingAccount : IBankingAccount
    {
        public enum ValidAccountTypes { checking, savings };

        public enum ValidAccountNumberConfig
        {
            lowerBound = 1000,
            upperBound = 10000,
            defaultValue = 666
        }

        private decimal accountBalance;
        private readonly int _accountType;

        public int AccountType => _accountType;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="initialBalance">Initial balance for the account.</param>
        /// <param name="accountType">Type of the account</param>
        public BankingAccount(decimal initialBalance, int accountType)
        {
            // Account type is invalid.
            // NOTE: These should currently never occur.
            if (!Enum.IsDefined(typeof(ValidAccountTypes), accountType))
            {
                throw new Exception($"{accountType} is not a valid account type");
            }

            this.accountBalance = initialBalance;
            this._accountType = accountType;
        }

        /// <summary>
        /// Returns the current account value.
        /// </summary>
        /// <returns>A decimal value representing the account's current value.</returns>
        public decimal ViewBalance()
        {
            return accountBalance;
        }

        /// <summary>
        /// Deposits funds to the account.
        /// <param name="fundsToBeDeposited">The amount of money to be withdrawn.</param>
        /// </summary>
        public void DepositFunds(decimal fundsToBeDeposited)
        {
            if (fundsToBeDeposited > 0)
            {
                accountBalance += fundsToBeDeposited;
                Console.WriteLine($"{fundsToBeDeposited:c} were successfully deposited to the account");
            }
            else
            {
                Console.WriteLine("Please specify an amount greater than 0");
            }
        }

        /// <summary>
        /// Withdraws funds from the account.
        /// <param name="fundsToBeWithdrawn">The amount of money to be withdrawn.</param>
        /// </summary>
        public void WithdrawFunds(decimal fundsToBeWithdrawn)
        {
            if (fundsToBeWithdrawn < 0)
            {
                Console.WriteLine("Please specify an amount greater than 0");
            }
            else if (fundsToBeWithdrawn < accountBalance)
            {
                accountBalance -= fundsToBeWithdrawn;
                Console.WriteLine($"{fundsToBeWithdrawn:c} were successfully withdrawn from the account.");
            }
            else
            {
                Console.WriteLine("The amount to be withdrawn cannot exceed the account balance.");
            }
        }
    }
}