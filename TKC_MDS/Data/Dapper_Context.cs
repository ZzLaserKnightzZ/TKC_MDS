using Dapper;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TKC_MDS.Data
{
	public static class Dapper_Context
	{
		private const string SQl_CONNECTION = "Server=DESKTOP-H37A9L8\\SQLEXPRESS;Database=SalesDev;User Id=sa;Password=admin;Trusted_Connection=True;";
		public static async Task<IEnumerable<TResult>> QueryTableAsync<TResult>(string command)
		{
			using (var connection = new SqlConnection(SQl_CONNECTION))
			{
				using (var multi = await connection.QueryMultipleAsync(command))
				{
					//var invoice = await multi.FirstAsync<TResault>();
					return await multi.ReadAsync<TResult>();
				}
			}
		}

		public static async Task<int> Insert<T>(string sqlCommand,T param)
		{
			using (var connection = new SqlConnection(SQl_CONNECTION))
			{
				return await connection.ExecuteAsync(sqlCommand, param);
			}
		}
	}
}
