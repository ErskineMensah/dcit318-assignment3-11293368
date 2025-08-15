using System;

namespace Finance_Management_System
{
    // Creation of record to represent financial data
    public record Transaction(
        int Id, 
        DateTime Date, 
        decimal Amount, 
        string Category
    );
}
