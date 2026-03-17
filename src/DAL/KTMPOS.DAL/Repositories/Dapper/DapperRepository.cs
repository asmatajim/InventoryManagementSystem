using Dapper;

using Microsoft.Data.SqlClient;

using System.Data;

namespace KTMPOS.DAL.Repositories.Dapper
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> ExecuteScalarAsync(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using(var con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = ConvertToDynamicParameters(parameters);
                var res = await con.ExecuteScalarAsync(query, dynamicParameters, commandType: commandType);
                int result = (int)res;
                return result;
            }
        }

        public async Task<int> ExecuteAsync(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using(var con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = ConvertToDynamicParameters(parameters);
                int rows = await con.ExecuteAsync(query, dynamicParameters, commandType: commandType);
                return rows;
            }
        }

        public async Task<List<T>> QueryAsync<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure) where T : class
        {
            using(var con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = ConvertToDynamicParameters(parameters);
                var result = (await con.QueryAsync<T>(query, dynamicParameters, commandType: commandType)).ToList();
                return result;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure) where T : class
        {
            using(var con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = ConvertToDynamicParameters(parameters);
                var result = await con.QueryFirstOrDefaultAsync<T>(query, dynamicParameters, commandType: commandType);
                return result;
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.StoredProcedure) where T : class
        {
            using(var con = new SqlConnection(_connectionString))
            {
                var dynamicParameters = ConvertToDynamicParameters(parameters);
                var result = await con.QuerySingleOrDefaultAsync<T>(query, dynamicParameters, commandType: commandType);
                return result;
            }
        }

        private DynamicParameters ConvertToDynamicParameters(Dictionary<string, object> parameters)
        {
            //null coalscing operator
            parameters = parameters ?? [];
            var result = new DynamicParameters(parameters);
            return result;
        }
    }
}