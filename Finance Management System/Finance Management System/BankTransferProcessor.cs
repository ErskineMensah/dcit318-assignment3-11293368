using System;

namespace Finance_Management_System
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Bank Transfer] Processed GHC {transaction.Amount:N2} for {transaction.Category}");
        }
    }
}
