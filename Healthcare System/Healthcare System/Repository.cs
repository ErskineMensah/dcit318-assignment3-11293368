using System;
using System.Collections.Generic;
using System.Linq;

namespace Healthcare_System
{
    public class Repository<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item) => _items.Add(item);

        public List<T> GetAll() => new List<T>(_items);

        public T? GetById(Func<T, bool> predicate) => _items.FirstOrDefault(predicate);

        public bool Remove(Func<T, bool> predicate)
        {
            var toRemove = _items.Where(predicate).ToList();
            foreach (var item in toRemove)
                _items.Remove(item);

            return toRemove.Count > 0;
        }
    }
}
