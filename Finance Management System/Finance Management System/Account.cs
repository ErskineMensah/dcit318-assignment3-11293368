using System;

namespace Finance_Management_System
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; protected set; } 

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public virtual void ApplyTransaction(Transaction transaction)
        {
            Balance -= transaction.Amount;
            Console.WriteLine($"Transaction is applied. Your New Balance Is: GHC {Balance:N2}");
        }
    }
}
