using Banking;
using System;
using Xunit;

namespace BankingTests
{
    public class _UtilitiesTests
    {
        public class GetDecimalInputTests
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

        public class ValidateNameInputTests
        {
            [Fact(DisplayName = "ValidateNameInput works as expected with valid input")]
            public void TestValidateNameInputWorksAsExpectedValidInput()
            {
                // Arrange
                string validInput = "Jon",
                    expectedResult = "jon",
                    actualResult;

                // Act
                actualResult = _Utilities.ValidateNameInput(validInput);

                // Assert
                Assert.Equal(expectedResult, actualResult);
            }

            [Fact(DisplayName = "ValidateNameInput throws when passed an empty string")]
            public void TestValidateNameInputThrowsEmptyString()
            {
                // Arrange
                string emptyString = "";

                // Act / assert
                Assert.Throws<ArgumentException>(() => _Utilities.ValidateNameInput(emptyString));
            }

            [Fact(DisplayName = "ValidateNameInput throws when passed a string containing numeric characters")]
            public void TestvalidateNameInputThrowsNumeric()
            {
                // Arrange
                string invalidCharactersString = "jo12";

                // Act / assert
                Assert.Throws<ArgumentException>(() => _Utilities.ValidateNameInput(invalidCharactersString));
            }

            [Fact(DisplayName = "ValidateNameInput throws when passed a string containing special characters")]
            public void TestvalidateNameInputThrowsSpecialCharacters()
            {
                // Arrange
                string invalidCharactersString = "jo%n";

                // Act / assert
                Assert.Throws<ArgumentException>(() => _Utilities.ValidateNameInput(invalidCharactersString));
            }
        }

        public class GetRandomIntFromRangeTests
        {
            [Fact(DisplayName = "GetRandomIntFromRange returns an int in the expected range")]
            public void TestGetRandomIntFromRangeReturnsIntInExpectedRange()
            {
                // Arrange
                int lowerBound = 1000,
                    upperBound = 2001,
                    result;

                // Act
                result = _Utilities.GetRandomIntFromRange(lowerBound, upperBound);

                // Assert
                Assert.InRange<int>(result, lowerBound, upperBound);
            }

            [Fact(DisplayName = "GetRandomIntFromRange throws when lower bound is greater than upper")]
            public void TestGetRandomIntFromRangeThrowsOutOfRangeArg()
            {
                // Arrange
                int lowerBound = 2000,
                    upperBound = 1000;

                // Act / assert
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => _Utilities.GetRandomIntFromRange(lowerBound, upperBound));
            }
        }
    }
}