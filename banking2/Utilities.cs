﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking
{
    public static class _Utilities
    {
        /// <summary>
        /// Specifies the filepath to which logs are written.
        /// </summary>
        static readonly string logFile = "log.txt";

        /// <summary>
        /// Tries to parse a string value to a decimal.
        /// </summary>
        /// <param name="input">The string value to be parsed.</param>
        /// <returns></returns>
        public static decimal GetDecimalInput(string input)
        {
            try
            {
                return Decimal.Parse(input);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        /// <summary>
        /// Writes user and operation type to log file.
        /// </summary>
        /// <param name="currentUser">The current user, on whom operations will be executed.</param>
        /// <param name="operationType">The type of operation.</param>
        public static void WriteResultToFile(AccountHolder currentUser, string operationType)
        {
            string logMessage = $"{currentUser.LastName}, {currentUser.FirstName} - #{currentUser.AccountNumber}";
            logMessage += $"{operationType}";

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
        public static void WriteResultToFile(AccountHolder currentUser, string operationType, string accountType, decimal transactionAmount)
        {
            string logMessage = $"{currentUser.LastName}, {currentUser.FirstName} - #{currentUser.AccountNumber} ";
            logMessage += $"{accountType.ToUpper()} ";
            logMessage += $"{operationType} ";
            logMessage += $"Transaction amount: ${transactionAmount}";

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
