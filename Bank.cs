using System;
using System.Collections.Generic;

namespace BankApplication
{
    class Bank
    {
        
        private readonly List<BankAccount> _accounts;
        private readonly List<Transaction> _transactions;
        public string Name { get; set; }

        public Bank(string name) {
            Name = name; 
            _accounts = new List<BankAccount>(); 
            _transactions = new List<Transaction>();
        }

        public void AddAccount(BankAccount account)
        {
            _accounts.Add(account);
        }
        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction); 
        }

        public void VerifyLargeTransactions(string verifier)
        {
            Random random = new Random();
            foreach (Transaction transaction in _transactions)
            {
                if (transaction.HumanVerificationNeeded)
                {
                    int num = random.Next(0,4);
                    transaction.Verification = new Verification(verifier, DateTime.Now, (VerificationResults)num, "dont like it");
                    transaction.Verified = true;
                    if (transaction.Verification.VerificationResult == VerificationResults.Denied) transaction.WriteOutDeniedTransaction(transaction.Verification);
                }

            }

        }

        public void WriteOutAllInformation()
        {
            foreach (BankAccount account in _accounts)
            {
                account.WriteOutInformation();
            }
            foreach (Transaction transaction in _transactions)
            {
                transaction.WriteOutInformation();
            }
        }
    }
}
