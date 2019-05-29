using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Banking
{
    public static class _Utilities
    {
        /// <summary>
        /// Specifies the filepath to which logs are written.
        /// </summary>
        private static readonly string logFile = "log.txt";

        /// <summary>
        /// Tries to parse a string value to a decimal.
        /// </summary>
        /// <param name="input">The string value to be parsed.</param>
        /// <returns></returns>
        /// <exception cref="OverflowException"></exception>"
        /// <exception cref="FormatException"></exception>"
        public static decimal GetDecimalInput(string input)
        {
            try
            {
                return decimal.Parse(input);
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validates string input as being alphanumeric.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A validated string.</returns>
        /// <exception cref="ArgumentException"></exception>"
        public static string ValidateNameInput(string input)
        {
            if (input.Length <= 0)
            {
                throw new ArgumentException("Name cannot be blank");
            }

            if (!input.All(char.IsLetter))
            {
                throw new ArgumentException("Name can only contain letters");
            }

            return input.ToLower();
        }

        /// <summary>
        /// Returns a random int that is within a specified range.
        /// </summary>
        /// <param name="lowerBound">Minimum value, inclusive.</param>
        /// <param name="upperBound">Maximum value, exclusive.</param>
        /// <returns>A random int in the specified range.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>"
        public static int GetRandomIntFromRange(int lowerBound, int upperBound)
        {
            Random r = new Random();

            try
            {
                return r.Next(lowerBound, upperBound);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Writes user and operation type to log file.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="operationType">The type of operation.</param>
        public static void WriteResultToFile(AccountHolder currentUser, string operationType)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"USER {currentUser.LastName}, {currentUser.FirstName}\t");
            sb.Append($"Account #{currentUser.AccountNumber}\t");
            sb.Append($"{operationType.ToUpper()}");

            string logMessage = sb.ToString();

            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }

        /// <summary>
        /// Writes user, account type, operation type, and transaction amount to log file.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="accountType">The account type.</param>
        /// <param name="operationType">The type of operation.</param>
        /// <param name="transactionAmount">The transaction amount.</param>
        public static void WriteResultToFile(AccountHolder currentUser, string operationType, int accountType, decimal transactionAmount)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"USER {currentUser.LastName}, {currentUser.FirstName}\t");
            sb.Append($"Account #{currentUser.AccountNumber}\t");
            sb.Append($"{Enum.GetName(typeof(BankingAccount.ValidAccountTypes), accountType).ToUpper()}\t");
            sb.Append($"{operationType.ToUpper()}\t");
            sb.Append($"Transaction amount: {transactionAmount:C}");

            string logMessage = sb.ToString();

            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText("log.txt"))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }
    }
}