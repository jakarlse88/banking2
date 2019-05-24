using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Banking;
using Xunit;

namespace BankingTests
{
    public class BankingAccountTests
    {
        [Fact]
        public void TestBankingAccountConstructorThrowsWhenPassedInvalidAccountType()
        {
            Assert.Throws<Exception>(() => new BankingAccount(0, "invalidType"));
        }

        [Fact]
        public void TestBankingAccountConstructorPassesWithMixedCaseAccountTypeArgChecking()
        {
            BankingAccount testAccount = new BankingAccount(0, "cHeCkIng");

            Assert.Equal("checking", testAccount.AccountType);
        }

        [Fact]
        public void TestBankingAccountConstructorPassesWithLowerCaseAccountTypeArgChecking()
        {
            BankingAccount testAccount = new BankingAccount(0, "checking");

            Assert.Equal("checking", testAccount.AccountType);
        }

        [Fact]
        public void TestBankingAccountConstructorPassesWithUpperCaseAccountTypeArgChecking()
        {
            BankingAccount testAccount = new BankingAccount(0, "CHECKING");

            Assert.Equal("checking", testAccount.AccountType);
        }

        [Fact]
        public void TestBankingAccountConstructorPassesWithMixedCaseAccountTypeArgSavings()
        {
            BankingAccount testAccount = new BankingAccount(0, "sAvInGs");

            Assert.Equal("savings", testAccount.AccountType);
        }

        [Fact]
        public void TestBankingAccountConstructorPassesWithLowerCaseAccountTypeArgSavings()
        {
            BankingAccount testAccount = new BankingAccount(0, "savings");

            Assert.Equal("savings", testAccount.AccountType);
        }

        [Fact]
        public void TestBankingAccountConstructorPassesWithUpperCaseAccountTypeArgSavings()
        {
            BankingAccount testAccount = new BankingAccount(0, "SAVINGS");

            Assert.Equal("savings", testAccount.AccountType);
        }
    }
}

