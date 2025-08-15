using System;

namespace Finance_Management_System
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Mobile Money] Processed GHC {transaction.Amount:N2} for {transaction.Category}");
        }
    }
}
