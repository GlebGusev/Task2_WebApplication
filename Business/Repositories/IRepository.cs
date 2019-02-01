using System.Collections.Generic;

namespace Business.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class 
    {
        IList<T> GetList(int max = 0);

        T Get(int? id);

        void Remove(int? id);

        bool Edit(T model);

        void Edit(int? id);

        bool AddRecord(T model);
    }
}