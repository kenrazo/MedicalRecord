using MedicalRecord.Common.AppSettings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MedicalRecord.Common;

namespace MedicalRecord.DataAccess
{
    public class GenericBase<T> : IGenericBase<T> where T : class
    {
        private string _connectionString;

        public GenericBase(IOptions<DatabaseConnection> connectionString)
        {
            _connectionString = connectionString.Value.MainDatabase;
        }

        public async Task<IEnumerable<T>> All()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
                return await db.GetAllAsync<T>();
        }

        public async Task<T> ById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
                return await db.GetAsync<T>(id);
        }

        public async Task<Result> Insert(T data)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = await db.InsertAsync(data);
                return new Result { Id = result, IsSuccess = result > 0 };
            }
        }

        public async Task<Result> Update(T data)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = await db.UpdateAsync(data);
                return new Result { IsSuccess = result };
            }
        }

        public async Task<Result> Delete(T data)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = await db.DeleteAsync(data);
                return new Result { IsSuccess = result };
            }
        }
    }
}
