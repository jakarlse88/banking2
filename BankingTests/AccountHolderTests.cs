using System;
using Xunit;
using banking;

namespace BankingTests
{
    public class AccountHolderTests
    {
        [Fact]
        public void TestGetAccountTypeReturnsCheckingAccountWhenPassedChecking()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("checking");

            Assert.Equal("checking", currentAccount.AccountType);
        }

        [Fact]
        public void TestGetAccountTypeReturnsCheckingAccountWhenPassedCheckingCaps()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("CHECKING");

            Assert.Equal("checking", currentAccount.AccountType);
        }

        [Fact]
        public void TestGetAccountTypeReturnsCheckingAccountWhenPassedCheckingMixedCase()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("cHecKiNg");

            Assert.Equal("checking", currentAccount.AccountType);
        }

        [Fact]
        public void TestGetAccountTypeReturnsSavingsAccountWhenPassedSavings()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("savings");

            Assert.Equal("savings", currentAccount.AccountType);
        }

        [Fact]
        public void TestGetAccountTypeReturnsSavingsAccountWhenPassedSavingsCaps()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("SAVINGS");

            Assert.Equal("savings", currentAccount.AccountType);
        }

        [Fact]
        public void TestGetAccountTypeReturnsSavingsAccountWhenPassedSavingsMixedCase()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("SaViNgS");

            Assert.Equal("savings", currentAccount.AccountType);
        }

        [Fact]
        public void TestGetAccountTypeReturnsNullWhenPassedInvalidInput()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("lkasd");

            Assert.Null(currentAccount);
        }

        [Fact]
        public void TestGetAccountTypeReturnsNullWhenPassedInvalidInputNumeric()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("123123");

            Assert.Null(currentAccount);
        }

        [Fact]
        public void TestGetAccountTypeReturnsNullWhenPassedInvalidInputMixed()
        {
            AccountHolder currentUser = new AccountHolder(1234, "John", "Smith");

            BankingAccount currentAccount = currentUser.GetAccountByType("asd761267");

            Assert.Null(currentAccount);
        }
    }
}
