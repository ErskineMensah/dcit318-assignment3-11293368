using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRecordsSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "inventory_data.json"; 

            Console.WriteLine("=== INVENTORY MANAGEMENT SYSTEM ===");

            // First session: Seed and save data
            InventoryApp app1 = new InventoryApp(filePath);
            app1.SeedSampleData();
            app1.SaveData();

            Console.WriteLine("\n--- Data saved. Simulating new session... ---\n");

            // Second session: Load and display data
            InventoryApp app2 = new InventoryApp(filePath);
            app2.LoadData();
            app2.PrintAllItems();

            Console.WriteLine("\nProgram finished. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
