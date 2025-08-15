using System;
using System.Collections.Generic;

namespace Finance_Management_System
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            // i. Creating a new instance of a savings account.
            var account = new SavingsAccount("ACC001", 1000m);

            // ii. Creating three transactions records.
            var t1 = new Transaction(1, DateTime.Now, 100m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 250m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 600m, "Entertainment");

            // iii. Assigning processors to each transaction
            ITransactionProcessor mobile = new MobileMoneyProcessor();
            ITransactionProcessor bank = new BankTransferProcessor();
            ITransactionProcessor crypto = new CryptoWalletProcessor();

            mobile.Process(t1);  // Mobile Money → Transaction 1
            bank.Process(t2);    // Bank Transfer → Transaction 2
            crypto.Process(t3);  // Crypto Wallet → Transaction 3

            // iv. Applying each transaction to the account
            account.ApplyTransaction(t1);
            account.ApplyTransaction(t2);
            account.ApplyTransaction(t3);

            // v. Addition of all transactions to the list
            _transactions.AddRange(new[] { t1, t2, t3 });
        }
    }
}
