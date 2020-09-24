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

        public async Task<List<Todo>> GetAll()
        {
            return await DataProvider.Fetch();
        }
    }
}
