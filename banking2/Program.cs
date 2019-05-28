using System;

namespace Banking
{
    class Program
    {
        private static AccountHolder currentUser;

        /// <summary>
        /// Initialises the program's by constructing a new current user 
        /// from user's supplied name.
        /// </summary>
        private static void InitialiseProgram()
        {
            Console.WriteLine("Please create an user to proceed");
            while (currentUser == null)
            {
                string firstName, lastName;

                try
                {
                    Console.Write("Enter your first name: ");
                    firstName = _Utilities.ValidateNameInput(Console.ReadLine());

                    Console.Write("Enter your last name: ");
                    lastName = _Utilities.ValidateNameInput(Console.ReadLine());

                    currentUser = new AccountHolder(firstName, lastName);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }

            }

            Console.WriteLine("Great! Welcome to our banking service.");
            ExecuteProgram();
        }

        /// <summary>
        /// Executes the program.
        /// </summary>
        private static void ExecuteProgram()
        {
            if (currentUser != null)
                BankingMenuHandler.ExecuteBankingMenu(currentUser);

            else InitialiseProgram();
        }

        static void Main()
        {
            ExecuteProgram();
        }
    }
}