using System;

namespace BankApplication
{
    class Transaction
    {
        private readonly BankAccount _fromAccount;
        private readonly BankAccount _toAccount;
        private readonly DateTime _date;
        private readonly decimal _amount;
        public bool HumanVerificationNeeded { get; set; }
        public Verification Verification { get; set; }
        public bool Verified = false;
        public Transaction(BankAccount fromAccount, BankAccount toAccount, DateTime date, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _date = date;
            _amount = amount;
            this.Execute();

            if (amount > 100000) {
                HumanVerificationNeeded = true;
                return;
            }
            HumanVerificationNeeded = false;
        }

        private void Execute()
        {
            Console.WriteLine($"------------------------------------------\n");
            Console.WriteLine($"Transaction started {_date}\n");
            _fromAccount.Withdraw(_amount);
            _toAccount.Deposit(_amount);
            Console.WriteLine($"{_fromAccount.OwnerName} sent {_toAccount.OwnerName}, this Amount: {_amount}");
            Console.WriteLine($"------------------------------------------\n\n");
        }
        

        public void WriteOutDeniedTransaction(Verification verify)
        {
            
            {
                Console.WriteLine($"\nVerification Denied:\n From Account: {_fromAccount.AccountNumber}, {_fromAccount.OwnerName} \n To Account: {_toAccount.AccountNumber}, {_toAccount.OwnerName} \n Amount: {_amount} \n FurtherInfo: {verify.FurtherInfo} \n Verifier: {verify.Verifier}");
            }
        }


        public void WriteOutInformation()
        {
            Console.WriteLine($"\nTransaction: \n Date: {_date}\n FromAccount: {_fromAccount.AccountNumber}\n ToAccount: {_toAccount.AccountNumber} \n Amount: {_amount}");
        }
    }
}
