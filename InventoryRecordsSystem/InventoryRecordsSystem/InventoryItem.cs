using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRecordsSystem
{
    public record InventoryItem(
        int Id, 
        string Name, 
        int Quantity, 
        DateTime DateAdded
    ) : IInventoryEntity;
}
