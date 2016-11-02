using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestAPI.Models
{
    public class BooksRepository : IBooksRepository
    {
        private static ConcurrentDictionary<string, Books> _books =
              new ConcurrentDictionary<string, Books>();

        public BooksRepository()
        {
            Add(new Books {Key= Guid.NewGuid().ToString(), Name = "Some Book", Author="Someone" });
        }
        public IEnumerable<Books> GetAll()
        {
            return _books.Values;
        }
        public void Add(Books item)
        {
            item.Key = Guid.NewGuid().ToString();
            _books[item.Key] = item;
        }

        public Books Find(string key)
        {
            Books item;
            _books.TryGetValue(key, out item);
            return item;
        }

        

        public Books Remove(string key)
        {
            Books item;
            _books.TryRemove(key, out item);
            return item;
        }

        public void Update(Books item)
        {
            _books[item.Key] = item;
        }


    }
}
