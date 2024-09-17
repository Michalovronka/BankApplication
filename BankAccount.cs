using System;
namespace BankApplication
{
    class BankAccount
    {
        private static int _accountIncrement = 1;
        public readonly string AccountNumber;
        private decimal _balance;
        public readonly string OwnerName;

        public BankAccount(decimal balance, string ownerName)
        {
            
            if (balance <= 0)
            {
                throw new ArgumentException();
            }
            if(string.IsNullOrEmpty(ownerName))
            {
                throw new ArgumentOutOfRangeException(ownerName,"No name provided");
            }

            AccountNumber = _accountIncrement.ToString();
            _accountIncrement++;

            _balance = balance;
            OwnerName = ownerName;
            
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            _balance += amount;
            
        }
        public decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_balance < amount)
            {
                throw new InvalidOperationException("Withdrawing more money than is on the account ");
            }
            _balance -= amount;
            return amount;
        }
        public void WriteOutInformation()
        {
            Console.WriteLine($"\nBankAccount: \n AccountNumber: {AccountNumber}\n OwnerName: {OwnerName}\n Balance: {_balance}");
        }

    }

}
