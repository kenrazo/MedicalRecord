using Dapper;
using MedicalRecord.Common;
using MedicalRecord.Common.AppSettings;
using MedicalRecord.DataAccess.Entities;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MedicalRecord.DataAccess.Repositories
{
    public class PatientRepository : GenericBase<Patient>, IPatientRepository
    {
        private string _connectionString;
        public PatientRepository(IOptions<DatabaseConnection> connectionString) : base(connectionString)
        {
            _connectionString = connectionString.Value.MainDatabase;
        }

        public async Task<bool> CheckIfExist(int id)
        {
            var data = await ById(id);
            if (data != null)
                return true;
            else
                return false;
        }

        public Result DeletePatient(int id)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                string query = $@"DELETE FROM PATIENT WHERE Id = @id";

                var result = db.Execute(query, parameters, commandTimeout: 90, transaction: null, commandType: CommandType.Text);
                if (result == 1)
                    return new Result { IsSuccess = true };
                else
                    return new Result { IsSuccess = false };
            }
        }
    }
}
