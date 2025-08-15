using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message)
        {
        }
    }
}
