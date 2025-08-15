using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    public class WareHouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
        private InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

        // Seed data for testing
        public void SeedData()
        {
            try
            {
                // Add Electronics
                _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
                _electronics.AddItem(new ElectronicItem(2, "Smartphone", 15, "Samsung", 12));
                _electronics.AddItem(new ElectronicItem(3, "Headphones", 20, "Sony", 6));

                // Add Groceries
                _groceries.AddItem(new GroceryItem(101, "Milk", 50, DateTime.Now.AddDays(5)));
                _groceries.AddItem(new GroceryItem(102, "Bread", 30, DateTime.Now.AddDays(2)));
                _groceries.AddItem(new GroceryItem(103, "Apples", 40, DateTime.Now.AddDays(10)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding data: {ex.Message}");
            }
        }

        // Print all items from a given repository
        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            List<T> items = repo.GetAllItems();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
            }
        }

        // Increase stock with exception handling
        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Stock updated successfully for {item.Name}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
        }

        // Remove item by ID with exception handling
        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with ID {id} removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
        }

        // Public accessors for repositories
        public InventoryRepository<ElectronicItem> Electronics => _electronics;
        public InventoryRepository<GroceryItem> Groceries => _groceries;
    }
}
