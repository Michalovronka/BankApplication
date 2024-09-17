using System;

namespace BankApplication
{
    internal class Program
    {
        static void Main()
        {

            Bank bank = new Bank("bank");

            BankAccount account1 = new BankAccount(100000000, "name1");
            bank.AddAccount(account1);
            
            BankAccount account2 = new BankAccount(300000000, "name2"); 
            bank.AddAccount(account2);

            Transaction transaction1 = new Transaction (account1,account2, DateTime.Now, 10000000);
            bank.AddTransaction(transaction1);
            Transaction transaction2 = new Transaction (account2,account1, DateTime.Now, 1099999);
            bank.AddTransaction(transaction2);
            Transaction transaction3 = new Transaction (account1,account2, DateTime.Now, 10000001);
            bank.AddTransaction(transaction3);

            bank.WriteOutAllInformation();

            bank.VerifyLargeTransactions("John The Verifier");

            Console.ReadLine();
        }
    }
}
