using Banking;
using System;
using Xunit;

namespace BankingTests
{
    public class _UtilitiesTests
    {
        [Fact]
        public void TestGetDecimalInputWithValid()
        {
            decimal expected = 10m;
            decimal actual = _Utilities.GetDecimalInput(expected.ToString());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetDecimalInputWithValidNegative()
        {
            decimal expected = -10m;
            decimal actual = _Utilities.GetDecimalInput(expected.ToString());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetDecimalInputThrowsWithInvalidInput()
        {
            Assert.Throws<FormatException>(() => _Utilities.GetDecimalInput("failing input"));
        }

        [Fact]
        public void TestGetDecimalInputThrowsWithOverflowInput()
        {
            //string hugeNumber = double.MaxValue.ToString();
            string hugeNumber = "8912737861278361892378912738917289371289127389712893712389893";

            Assert.Throws<OverflowException>(() => _Utilities.GetDecimalInput(hugeNumber));
        }
    }
}