using System;
using Banking;
using Xunit;
using Xunit.Abstractions;

namespace BankingTests
{
    public class BankingAccountConstructorTests
    {
        [Fact(DisplayName = "BankingAccount ctor throws when passed invalid acc type arg")]
        public void TestBankingAccountConstructorThrowsWhenPassedInvalidAccountTypeArg()
        {
            // Arrange
            int invalidAccountType = 3;

            // Act / assert
            Assert.Throws<Exception>(() => new BankingAccount(invalidAccountType));
        }

        [Fact(DisplayName = "BankingAccount ctor works as expected with valid acc type arg checking")]
        public void TestBankingAccountConstructorWorksAsExpectedWithValidAccTypeArgChecking()
        {
            // Arrange
            int validAccTypeChecking = (int)BankingAccount.ValidAccountTypes.checking;
            string expectedAccType = "checking",
                actualAccType;

            // Act
            BankingAccount bankingAccount = new BankingAccount(validAccTypeChecking);
            actualAccType = Enum.GetName(typeof(BankingAccount.ValidAccountTypes),
                                    bankingAccount.AccountType);

            // Assert
            Assert.Equal(expectedAccType, actualAccType);
        }

        [Fact(DisplayName = "BankingAccount ctor works as expected with valid acc type arg savings")]
        public void TestBankingAccountConstructorWorksAsExpectedWithValidAccTypeArgSavings()
        {
            // Arrange
            int validAccTypeSavings = (int)BankingAccount.ValidAccountTypes.savings;
            string expectedAccType = "savings",
                actualAccType;

            // Act
            BankingAccount bankingAccount = new BankingAccount(validAccTypeSavings);

            actualAccType = Enum.GetName(typeof(BankingAccount.ValidAccountTypes),
                                    bankingAccount.AccountType);

            // Assert
            Assert.Equal(expectedAccType, actualAccType);
        }

        [Fact(DisplayName = "BankingAccount ctor works as expected without optional initialBalance arg")]
        public void TestBankingAccountConstructorWorksAsExpectedWithoutOptionalInitialBalanceArg()
        {
            // Arrange
            int validAccTypeSavings = (int)BankingAccount.ValidAccountTypes.savings;
            decimal expectedAccountBalance = Decimal.Zero,
                actualAccountBalance;

            // Act
            BankingAccount bankingAccount = new BankingAccount(validAccTypeSavings);
            actualAccountBalance = bankingAccount.ViewBalance();

            // Assert
            Assert.Equal(expectedAccountBalance, actualAccountBalance);
        }

        [Fact(DisplayName = "BankingAccount ctor works as expected with optional initialBalance arg")]
        public void TestBankingAccountConstructorWorksAsExpectedWithOptionalInitialBalanceArg()
        {
            // Arrange
            int validAccTypeSavings = (int)BankingAccount.ValidAccountTypes.savings;
            decimal validInitialBalance = 10000,
                expectedAccountBalance = 10000,
                actualAccountBalance;

            // Act
            BankingAccount bankingAccount =
                new BankingAccount(validAccTypeSavings, initialBalance: validInitialBalance);

            actualAccountBalance = bankingAccount.ViewBalance();

            // Assert
            Assert.Equal(expectedAccountBalance, actualAccountBalance);
        }
    }

    public class BankingAccountDepositFundsTests
    {
        private readonly ITestOutputHelper output;

        private readonly int validAccountTypeSavings = (int)BankingAccount.ValidAccountTypes.savings;

        public BankingAccountDepositFundsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "DepositFunds works as expected when passed a positive decimal arg")]
        public void TestDepositFundsWorksAsExpectedPositiveDecimalArg()
        {
            // Arrange
            decimal amountToDepositValid = 1000,
                expectedBalance = 1000,
                actualBalance;

            BankingAccount bankingAccount = new BankingAccount(validAccountTypeSavings);

            // Act
            bankingAccount.DepositFunds(amountToDepositValid);
            actualBalance = bankingAccount.ViewBalance();

            // Assert
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact(DisplayName = "DepositFunds throws ArgumentException when passed a non-positive decimal arg")]
        public void TestDepositFundsThrowsArgumentExceptionNonPositiveDecimalArg()
        {
            // Arrange
            decimal amountToDepositInvalid = -1000;

            BankingAccount bankingAccount = new BankingAccount(validAccountTypeSavings);

            // Act / assert
            Assert.Throws<ArgumentException>(() => bankingAccount.DepositFunds(amountToDepositInvalid));
        }

        [Fact(DisplayName = "WithdrawFunds works as expected when passed a positive decimal arg that is lower than current account balance")]
        public void TestWithdrawFundsWorksAsExpectedPositiveDecimalArgLowerThanCurrentBalance()
        {
            // Arrange
            decimal initialAccountBalance = 10000,
                amountToWithdraw = 1000,
                expectedBalance = initialAccountBalance - amountToWithdraw,
                actualBalance;

            BankingAccount bankingAccount =
                new BankingAccount(validAccountTypeSavings, initialBalance: initialAccountBalance);

            // Act
            bankingAccount.WithdrawFunds(amountToWithdraw);
            actualBalance = bankingAccount.ViewBalance();

            // Assert
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact(DisplayName = "WithdrawFunds throws ArgumentException when passed a negative decimal arg")]
        public void TestWithdrawFundsThrowsNegativeDecimalArg()
        {
            // Arrange
            decimal initialAccountBalance = 10000,
            amountToWithdrawInvalid = -1000;

            BankingAccount bankingAccount =
                new BankingAccount(validAccountTypeSavings, initialBalance: initialAccountBalance);

            // Act / assert
            Assert.Throws<ArgumentException>(() => bankingAccount.WithdrawFunds(amountToWithdrawInvalid));
        }

        [Fact(DisplayName = "WithdrawFunds throws ArgumentException when passed a positive decimal arg that exceeds account balance")]
        public void TestWithdrawFundsThrowsPositiveDecimalArgExceedsBalance()
        {
            // Arrange
            decimal initialAccountBalance = 500,
            amountToWithdraw = 1000;

            BankingAccount bankingAccount =
                new BankingAccount(validAccountTypeSavings, initialBalance: initialAccountBalance);

            // Act / assert
            Assert.Throws<ArgumentException>(() => bankingAccount.WithdrawFunds(amountToWithdraw));
        }
    }
}