using DAL;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class PersonalManager
    {
        public IConfiguration Configuration { get; }
        public IDataProvider<Todo> DataProvider { get; }

        public PersonalManager(IConfiguration configuration, IDataProvider<Todo> dataProvider)
        {
            Configuration = configuration;
            DataProvider = dataProvider;
        }

        public async Task<List<Todo>> GetFiltered(Dictionary<string, string> filters)
        {
            return await DataProvider.Fetch(filters);
        }

        public async Task<List<Todo>> GetById(int id)
        {
            var filter = new Dictionary<string, string>();
            filter.Add("Id", id.ToString());
            return await DataProvider.Fetch(filter);
        }

        public async Task<int> Create(Todo todo)
        {
            return await DataProvider.Create(todo);
        }

        public async Task<bool> Update(Todo todo)
        {
            return await DataProvider.Update(todo);
        }

        public async Task<bool> Delete(int id)
        {
            return await DataProvider.Delete(id);
        }
    }
}
