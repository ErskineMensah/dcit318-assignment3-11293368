using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Inventory_Management_System
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private Dictionary<int, T> _items = new Dictionary<int, T>();

        // Add item to inventory
        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new DuplicateItemException($"Item with ID {item.Id} already exists.");
            }
            _items[item.Id] = item;
        }

        // Get item by ID
        public T GetItemById(int id)
        {
            if (!_items.TryGetValue(id, out var item))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found.");
            }
            return item;
        }

        // Remove item by ID
        public void RemoveItem(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found.");
            }
            _items.Remove(id);
        }

        // Get all items
        public List<T> GetAllItems()
        {
            return new List<T>(_items.Values);
        }

        // Update item quantity
        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new InvalidQuantityException("Quantity cannot be negative.");
            }

            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found.");
            }

            _items[id].Quantity = newQuantity;
        }
    }
}
