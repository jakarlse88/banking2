using System;
using Xunit;
using Banking;

namespace BankingTests
{
    public class AccountHolderTests
    {
        [Fact]
        public void TestGetAccountTypeReturnsCheckingAccountWhenPassedChecking()
        {
            // Arrange
            AccountHolder currentUser = new AccountHolder("John", "Smith");

            string expectedAccountType =
                Enum.GetName(typeof(BankingAccount.ValidAccountTypes), (int)BankingAccount.ValidAccountTypes.checking);

            // Act
            BankingAccount currentAccount =
                currentUser.GetAccountByType((int)BankingAccount.ValidAccountTypes.checking);

            int actualAccountType = currentAccount.AccountType;
            string actualAccountTypeString = Enum.GetName(typeof(BankingAccount.ValidAccountTypes), actualAccountType);

            // Asert
            Assert.Equal(expectedAccountType, actualAccountTypeString);
        }

        [Fact]
        public void TestGetAccountTypeReturnsSavingsAccountWhenPassedSavings()
        {
            // Arrange
            AccountHolder currentUser = new AccountHolder("John", "Smith");

            string expectedAccountType =
                Enum.GetName(typeof(BankingAccount.ValidAccountTypes), (int)BankingAccount.ValidAccountTypes.savings);

            // Act
            BankingAccount currentAccount =
                currentUser.GetAccountByType((int)BankingAccount.ValidAccountTypes.savings);

            int actualAccountType = currentAccount.AccountType;
            string actualAccountTypeString = Enum.GetName(typeof(BankingAccount.ValidAccountTypes), actualAccountType);

            // Asert
            Assert.Equal(expectedAccountType, actualAccountTypeString);
        }

        [Fact]
        public void TestGetAccountTypeReturnsNullWhenPassedInvalidInput()
        {
            // Arrange
            AccountHolder currentUser = new AccountHolder("John", "Smith");
            int invalidAccountType = 666;

            // Act
            BankingAccount currentAccount = currentUser.GetAccountByType(invalidAccountType);

            // Assert
            Assert.Null(currentAccount);
        }
    }
}