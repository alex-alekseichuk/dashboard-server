using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Sota.Dashboard.Common.Constants;
using Sota.Dashboard.DataAccess.Utils;
using Sota.Dashboard.DataAccess.Mappers;
using Sota.Dashboard.DataAccess.Models;
using Sota.Dashboard.DataAccess.Models.Raw;

namespace Sota.Dashboard.DataAccess
{
	public interface IFilterRepository
	{
		List<Filter> GetFilters(List<long> selectedTransTypes = null);
	}

	public class FilterRepository : RepositoryBase, IFilterRepository
	{
		private readonly IMemoryCache _cache;

		public FilterRepository(IMemoryCache cache)
		{
			_cache = cache;
		}

		public List<Filter> GetFilters(List<long> selectedTransTypes = null)
		{
			var fnName = "filter_semiflat_pck.filter";
			var res = new List<Filter>();
			Dictionary<string, List<DbFilter>> map;
			WithConnection(db =>
			{
				var value = new
				{
					id = selectedTransTypes
				};
				byte[] newvalue = System.Text.Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(value));
				var clob = new OracleClob((OracleConnection)db);
				clob.Write(newvalue, 0, newvalue.Length);

				var p = new OracleDynamicParameters();
				p.Add("p_id_col", clob, OracleDbType.Clob, ParameterDirection.Input);
				p.Add("rv", dbType: OracleDbType.RefCursor, direction: ParameterDirection.ReturnValue);
				var dbFilters = db.Query<DbFilter>(fnName, param: p, commandType: CommandType.StoredProcedure);

				map = dbFilters.Where(x => x.IsActualFilter)
							   .GroupBy(x => x.FilterCode)
							   .ToDictionary(x => x.Key,
											 x => x.ToList());
				foreach (var pair in map)
				{
					var f = pair.Value.Map();
					res.Add(f);
				}
			});
			return res;
		}

		public void CallSp()
		{
			WithConnection(db =>
			{
				var p = new OracleDynamicParameters();
				p.Add("oRefCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
				var myRefcurs = db.Query<dynamic>("filter_pck_v2.test_filter", param: p, commandType: CommandType.StoredProcedure);

				foreach (var row in myRefcurs)
				{
					var dataRow = row as IDictionary<string, object>;
				}

			});
		}
	}
}
