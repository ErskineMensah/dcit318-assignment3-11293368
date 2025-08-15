using System;

namespace Finance_Management_System
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[Crypto Wallet] Processed GHC {transaction.Amount:N2} for {transaction.Category}");
        }
    }
}
