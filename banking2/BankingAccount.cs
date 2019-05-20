using banking.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace banking
{
    /// <summary>
    /// The BankingAccount class contains balance and account type state,
    /// and the operations that can be performed on these.
    /// </summary>
    public class BankingAccount : IBankingAccount
    {
        private decimal accountBalance;
        private readonly string accountType;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="initialBalance">Initial balance for the account.</param>
        /// <param name="accountType">Type of the account</param>
        public BankingAccount(decimal initialBalance, string accountType)
        {
            if (accountType != "checking" && accountType != "savings")
            {
                throw new Exception($"{accountType} is not a valid account type");
            }

            this.accountType = accountType;
            this.accountBalance = initialBalance;
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
            if (fundsToBeWithdrawn < accountBalance)
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
