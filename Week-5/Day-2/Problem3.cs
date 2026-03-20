using System;
using System.Collections.Generic;

namespace Oops_Concepts
{


    // 🔹 BankAccount Class
    class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                // Throw custom exception
                throw new ArgumentOutOfRangeException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine("Remaining Balance: " + balance);
        }
    }

    // 🔹 Main Program
    class Program
    {
        static void Main()
        {
            Console.Write("Enter initial balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            BankAccount account = new BankAccount(balance);

            Console.Write("Enter withdrawal amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            try
            {
                account.Withdraw(amount);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction completed.");
            }

            Console.WriteLine("Program continues safely...");
        }
    }
}
