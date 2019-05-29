//using Banking;
//using System;
//using Xunit;

//namespace BankingTests
//{
//    public class BankingMenuHandlerTests
//    {
//        [Fact]
//        public void TestGetDecimalInputWithValid()
//        {
//            decimal expected = 10m;
//            decimal actual = BankingMenuHandler.GetDecimalInput(expected.ToString());

//            Assert.Equal(expected, actual);
//        }

//        [Fact]
//        public void TestGetDecimalInputWithValidNegative()
//        {
//            decimal expected = -10m;
//            decimal actual = BankingMenuHandler.GetDecimalInput(expected.ToString());

//            Assert.Equal(expected, actual);
//        }

//        [Fact]
//        public void TestGetDecimalInputThrowsWithInvalidInput()
//        {
//            Assert.Throws<FormatException>(() => BankingMenuHandler.GetDecimalInput("failing input"));
//        }

//        [Fact]
//        public void TestGetDecimalInputThrowsWithOverflowInput()
//        {
//            string hugeNumber = Double.MaxValue.ToString();

//            Assert.Throws<OverflowException>(() => BankingMenuHandler.GetDecimalInput(hugeNumber));
//        }
//    }
//}