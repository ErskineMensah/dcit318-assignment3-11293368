using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryRecordsSystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log = new List<T>(); 
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, _log);
                }
                Console.WriteLine("Data saved successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to write to this file.");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O Error while saving: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("No file found to load data.");
                    return;
                }

                using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    var items = JsonSerializer.Deserialize<List<T>>(fs);
                    if (items != null)
                    {
                        _log = items;
                    }
                }
                Console.WriteLine("Data loaded successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The file was not found.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Error: The file contains invalid data format.");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O Error while loading: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error loading from file: {ex.Message}");
            }
        }
    }
}
