using System.Collections.Generic;

namespace FFCG.G5.Storage
{
    public interface IStorage<T> where T : IStorable
    {
        void Store(T item);
        IEnumerable<T> All();
        void Delete(T item);
    }
}