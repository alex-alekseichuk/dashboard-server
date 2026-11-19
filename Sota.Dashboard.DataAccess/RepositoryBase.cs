using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Dapper;
//using MiniProfiler.Integrations;
using Oracle.ManagedDataAccess.Client;
//using Serilog;

namespace Sota.Dashboard.DataAccess
{
	public abstract class RepositoryBase
	{
		private DbConnection GetConnection()
		{
			return new OracleConnection("Data Source=localhost:1521/dev;User ID=test_user;Password=test_password");
		}

		protected T WithConnection<T>(Func<DbConnection, T> func)
		{
			using (var dbConn = GetConnection())
			{
				try
				{
					dbConn.Open();
					var res = func(dbConn);
					dbConn.Close();
					return res;
				}
				catch (Exception exc)
				{
					//Log.Error(exc.Message, exc);
					throw;
				}
			}
		}

		protected void WithConnection(Action<DbConnection> action)
		{
			WithConnection(dbConn =>
			{
				action(dbConn);
				return 0;
			});
		}

		public class DbParams : SqlMapper.IDynamicParameters, IEnumerable<IDbDataParameter>
		{
			private readonly List<IDbDataParameter> parameters = new List<IDbDataParameter>();

			void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
			{
				foreach (var parameter in parameters)
					command.Parameters.Add(parameter);
			}

			public IEnumerator<IDbDataParameter> GetEnumerator()
			{
				return parameters.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void Add(IDbDataParameter value)
			{
				parameters.Add(value);
			}
		}

    // TODO: check that IDbConnectionFactory
    private class OracleDbConnectionFactory
    //  : IDbConnectionFactory
		{
			private readonly string _connectionString;
			public OracleDbConnectionFactory(string connectionString)
			{
				_connectionString = connectionString;
			}
			public DbConnection CreateConnection()
			{
				return new OracleConnection(_connectionString);
			}
		}

	}
}
