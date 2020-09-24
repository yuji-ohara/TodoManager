using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataProvider<T>
    {
        public Task<List<T>> Fetch(Dictionary<string, string> filter = default(Dictionary<string, string>));

        public Task<int> Create(T model);

        public Task<bool> Update(T model);

        public Task<bool> Delete(int id);
    }
}
