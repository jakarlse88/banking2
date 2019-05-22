using System;
using System.Collections.Generic;
using System.Text;

namespace banking
{
    /// <summary>
    /// The AccountHolder class contains information about an account holder,
    /// including name, account number, and references to his/her savings and checking accounts. 
    /// </summary>
    public class AccountHolder
    {
        private int accountNumber;
        private string firstName, lastName;
        private BankingAccount checkingAccount, savingsAccount;
        public static string[] validAccountTypes = new string[] { "checking", "savings" };

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
        public AccountHolder(int accountNumber, string firstName, string lastName)
        {
            this.accountNumber = accountNumber;
            this.firstName = firstName.ToUpper();
            this.lastName = lastName.ToUpper();
            this.checkingAccount = new BankingAccount(0, "checking");
            this.savingsAccount = new BankingAccount(0, "savings");
        }

        /// <summary>
        /// Returns the BankingAccount corresponding to the type provided.
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public BankingAccount GetAccountByType(string accountType)
        {
            // Validate user input
            if (Array.IndexOf(validAccountTypes, accountType.ToLower()) == -1)
            {
                return null;
            }

            BankingAccount returnAccount = 
                accountType.ToLower() == "checking" ? 
                this.checkingAccount : 
                this.savingsAccount;

            return returnAccount;
        }

        public int AccountNumber
        {
            get { return accountNumber; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public BankingAccount CheckingAccount
        {
            get { return checkingAccount; }
        }

        public BankingAccount SavingsAccount
        {
            get { return savingsAccount; }
        }
    }
}
