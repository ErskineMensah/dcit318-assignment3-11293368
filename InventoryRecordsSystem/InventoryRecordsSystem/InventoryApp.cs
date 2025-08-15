using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRecordsSystem
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger;

        public InventoryApp(string filePath)
        {
            _logger = new InventoryLogger<InventoryItem>(filePath);
        }

        public void SeedSampleData()
        {
            Console.WriteLine("Seeding sample data...");

            _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now));
            _logger.Add(new InventoryItem(2, "Mouse", 20, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Keyboard", 10, DateTime.Now));
            _logger.Add(new InventoryItem(4, "Monitor", 7, DateTime.Now));
            _logger.Add(new InventoryItem(5, "Printer", 2, DateTime.Now));

            Console.WriteLine("Sample data added successfully.\n");
        }

        public void SaveData()
        {
            Console.WriteLine("Saving data to file...");
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            Console.WriteLine("Loading data from file...");
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            Console.WriteLine("\n--- Inventory Items ---");
            foreach (var item in _logger.GetAll())
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
            }
        }
    }
}
