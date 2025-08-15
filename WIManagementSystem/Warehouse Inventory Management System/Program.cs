using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiating a warehouse manager
            WareHouseManager manager = new WareHouseManager();

            // Seed initial data
            manager.SeedData();

            Console.WriteLine("\n--- Grocery Items ---");
            manager.PrintAllItems(manager.Groceries);

            Console.WriteLine("\n--- Electronic Items ---");
            manager.PrintAllItems(manager.Electronics);

            Console.WriteLine("\n--- Testing Exceptions ---");

            // Try to add a duplicate item
            try
            {
                manager.Electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Duplicate Item Error: {ex.Message}");
            }

            // Try to remove a non-existent item
            manager.RemoveItemById(manager.Groceries, 999);

            // Try to update with an invalid quantity
            try
            {
                manager.Electronics.UpdateQuantity(2, -5);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Invalid Quantity Error: {ex.Message}");
            }

            Console.WriteLine("\n--- Final Electronic Items ---");
            manager.PrintAllItems(manager.Electronics);

            Console.WriteLine("\n--- Final Grocery Items ---");
            manager.PrintAllItems(manager.Groceries);

            Console.WriteLine("\nProgram finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
