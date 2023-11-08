using Dapper;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TKC_MDS.Data
{
	public  class Dapper_Context
	{
		private readonly IConfiguration _config;
        public Dapper_Context(IConfiguration config)
        {
            _config = config;
        }
        //private const string SQl_CONNECTION = "Server=DESKTOP-H37A9L8\\SQLEXPRESS;Database=SalesDev;User Id=sa;Password=admin;Trusted_Connection=True;";
		public  async Task<IEnumerable<TResult>> QueryTableAsync<TResult>(string command)
		{
			using (var connection = new SqlConnection(_config.GetConnectionString("TkcMDSConnection")))
			{
				using (var multi = await connection.QueryMultipleAsync(command))
				{
					//var invoice = await multi.FirstAsync<TResault>();
					return await multi.ReadAsync<TResult>();
				}
			}
		}

		public  async Task<int> Insert<T>(string sqlCommand,T param)
		{
			using (var connection = new SqlConnection(_config.GetConnectionString("TkcMDSConnection")))
			{
				return await connection.ExecuteAsync(sqlCommand, param);
			}
		}

		public async Task<int> Update<T>(string sqlCommand, T param)
		{
			using (var connection = new SqlConnection(_config.GetConnectionString("TkcMDSConnection")))
			{
				return await connection.ExecuteAsync(sqlCommand, param);
			}
		}
	}
}
