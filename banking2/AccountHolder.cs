using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking
{
    /// <summary>
    /// The AccountHolder class contains information about an account holder,
    /// including name, account number, and references to his/her savings and checking accounts.
    /// </summary>
    public class AccountHolder
    {
        private int _accountNumber;
        private string _firstName, _lastName;
        private BankingAccount _checkingAccount, _savingsAccount;

        /// <summary>
        /// Class constructor.
        /// <param name="accountNumber">Used to assign an account number.</param>
        /// <param name="firstName">Used to assign a first name.</param>
        /// <param name="lastName">Used to assign a last name.</param>
        /// <remarks>
        /// In the current implementation, the savings/checking accounts are accessed via
        /// objects instantiated from this
        /// </remarks>
        /// </summary>
        public AccountHolder(string firstName, string lastName)
        {
            this._accountNumber = ConstructAccountNumber() ??
                (int)BankingAccount.ValidAccountNumberConfig.defaultValue;
            this._firstName = firstName;
            this._lastName = lastName;
            this._checkingAccount = new BankingAccount(0, (int)BankingAccount.ValidAccountTypes.checking);
            this._savingsAccount = new BankingAccount(0, (int)BankingAccount.ValidAccountTypes.savings);
        }

        /// <summary>
        /// Constructs an account number.
        /// </summary>
        /// <returns></returns>
        private int? ConstructAccountNumber()
        {
            try
            {
                return _Utilities.GetRandomIntFromRange(
                    (int)BankingAccount.ValidAccountNumberConfig.lowerBound,
                    (int)BankingAccount.ValidAccountNumberConfig.upperBound);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Returns the BankingAccount corresponding to the type provided.
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public BankingAccount GetAccountByType(int accountType)
        {
            // Validate user input
            if (!Enum.IsDefined(typeof(BankingAccount.ValidAccountTypes), accountType))
            {
                return null;
            }

            BankingAccount returnAccount =
                accountType == (int)BankingAccount.ValidAccountTypes.checking ?
                this._checkingAccount :
                this._savingsAccount;

            return returnAccount;
        }

        public int AccountNumber
        {
            get { return _accountNumber; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public BankingAccount CheckingAccount
        {
            get { return _checkingAccount; }
        }

        public BankingAccount SavingsAccount
        {
            get { return _savingsAccount; }
        }
    }
}