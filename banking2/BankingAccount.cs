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

        private const decimal defaultInitialAccountBalance = Decimal.Zero;

        private decimal _accountBalance;
        private readonly int _accountType;

        public int AccountType => _accountType;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="initialBalance">Initial balance for the account.</param>
        /// <param name="accountType">Type of the account</param>
        public BankingAccount(int accountType, decimal initialBalance = defaultInitialAccountBalance)
        {
            // Account type is invalid.
            // NOTE: These should currently never occur.
            if (!Enum.IsDefined(typeof(ValidAccountTypes), accountType))
            {
                throw new Exception($"{accountType} is not a valid account type");
            }

            this._accountBalance = initialBalance;
            this._accountType = accountType;
        }

        /// <summary>
        /// Returns the current account value.
        /// </summary>
        /// <returns>A decimal value representing the account's current value.</returns>
        public decimal ViewBalance()
        {
            return _accountBalance;
        }

        /// <summary>
        /// Deposits funds to the account.
        /// <param name="fundsToBeDeposited">The amount of money to be withdrawn.</param>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void DepositFunds(decimal fundsToBeDeposited)
        {
            if (fundsToBeDeposited > decimal.Zero)
            {
                _accountBalance += fundsToBeDeposited;
                Console.WriteLine($"{fundsToBeDeposited:c} were successfully deposited to the account");
            }
            else
            {
                throw new ArgumentException("Cannot deposit a non-positive amount");
            }
        }

        /// <summary>
        /// Withdraws funds from the account.
        /// <param name="fundsToBeWithdrawn">The amount of money to be withdrawn.</param>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>"
        public void WithdrawFunds(decimal fundsToBeWithdrawn)
        {
            if (fundsToBeWithdrawn < decimal.Zero)
            {
                throw new ArgumentException("Cannot withdraw a negative amount");
            }
            else if (fundsToBeWithdrawn < _accountBalance)
            {
                _accountBalance -= fundsToBeWithdrawn;
                Console.WriteLine($"{fundsToBeWithdrawn:c} were successfully withdrawn from the account.");
            }
            else
            {
                throw new ArgumentException("The amount to be withdrawn cannot exceed the account balance.");
            }
        }
    }
}