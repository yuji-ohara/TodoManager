﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlDataAdapter : IDataProvider<Todo>
    {
        public IConfiguration _configuration;
        public string ConnectionString => _configuration.GetConnectionString("SQL");

        public SqlDataAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Create(Todo model)
        {
            int id;

            await using(var connection = new SqlConnection(ConnectionString))
            {
                var parameters = new
                {
                    parentId = model.ParentId,
                    title = model.Title,
                    extendedDescription = model.ExtendedDescription,
                    dueDate = model.DueDate,
                    done = model.Done
                };

                id = await connection.ExecuteScalarAsync<int>("tm.Create_Todo", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return id;
        }

        public async Task<bool> Delete(int id)
        {
            int operationSuccess;

            await using (var connection = new SqlConnection(ConnectionString))
            {
                var parameters = new
                {
                    id = id
                };

                operationSuccess = await connection.ExecuteAsync("tm.Delete_Todo", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return operationSuccess > 0;
        }

        public async Task<List<Todo>> Fetch(Dictionary<string, string> filter)
        {
            IEnumerable<Todo> queryResult;

            var parameters = new
            {
                id = filter.ContainsKey("Id") ? filter["Id"] : null,
                parentId = filter.ContainsKey("ParentId") ? filter["ParentId"] : null,
                title = filter.ContainsKey("Title") ? filter["Title"] : null,
                freetext = filter.ContainsKey("FreeText") ? filter["FreeText"] : null,
                done = filter.ContainsKey("Done") ? filter["Done"] : null
            };

            await using(var connection = new SqlConnection(ConnectionString))
            {
                queryResult = await connection.QueryAsync<Todo>("tm.Get_Todo", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return queryResult.ToList();
        }

        public async Task<bool> Update(Todo model)
        {
            int id;

            await using (var connection = new SqlConnection(ConnectionString))
            {
                var parameters = new
                {
                    id = model.Id,
                    parentId = model.ParentId,
                    title = model.Title,
                    extendedDescription = model.ExtendedDescription,
                    dueDate = model.DueDate,
                    done = model.Done
                };

                id = await connection.ExecuteScalarAsync<int>("tm.Update_Todo", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return id > 0;
        }
    }
}
