using System.Collections.Generic;

namespace MyRestAPI.Models
{
    public interface IBooksRepository
    {
        void Add(Books item);
        IEnumerable<Books> GetAll();
        Books Find(string key);
        Books Remove(string key);
        void Update(Books item);
    }
}
