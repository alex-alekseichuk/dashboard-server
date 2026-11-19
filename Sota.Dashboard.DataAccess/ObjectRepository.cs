using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Sota.Dashboard.DataAccess;
using Sota.Dashboard.DataAccess.Utils;
using Sota.Dashboard.DataAccess.Models.Raw;
using Sota.Dashboard.Common.Exceptions;

namespace Sota.Dashboard.DataAccess
{
	public interface IObjectRepository
	{
		List<DbObjectShortInfo> GetObjects(IEnumerable<long> filterIds);
		List<DbObjectProp> GetObject(long id, bool isFullInfo = false);
		List<DbObjectTabInfo> GetObjectForTab(IEnumerable<long> filterIds);
	}

	public class ObjectRepository : RepositoryBase, IObjectRepository
	{
		public ObjectRepository()
		{
		}

		public List<DbObjectShortInfo> GetObjects(IEnumerable<long> filterIds)
		{
			var fnName = "filter_semiflat_pck.get_filtered_map_objects";

			return WithConnection(db =>
			{
				var value = new
				{
					id = filterIds
				};
				var newvalue = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(value));
				var clob = new OracleClob((OracleConnection)db);
				clob.Write(newvalue, 0, newvalue.Length);

				var p = new OracleDynamicParameters();
				p.Add("p_id_col", clob, OracleDbType.Clob, ParameterDirection.Input);
				p.Add("rv", dbType: OracleDbType.RefCursor, direction: ParameterDirection.ReturnValue);
				var dbObjects = db.Query<DbObjectShortInfo>(fnName, p, commandType: CommandType.StoredProcedure).ToList();
				return dbObjects;
			});
		}

		public List<DbObjectProp> GetObject(long id, bool isFullInfo = false)
		{
			if (id <= 0) throw new CommonException("Неверный идентификатор объекта");

			var fnName = "filter_semiflat_pck.get_object_info";
			var fullInfo = isFullInfo ? 1 : 0;
			return WithConnection(db =>
			{
				var p = new OracleDynamicParameters();
				p.Add("p_entity_id", id, OracleDbType.Int64, ParameterDirection.Input);
				p.Add("p_is_full_info", fullInfo, OracleDbType.Int32, ParameterDirection.Input);

				p.Add("rv", dbType: OracleDbType.RefCursor, direction: ParameterDirection.ReturnValue);
				var dbObjectProps = db.Query<DbObjectProp>(fnName, p, commandType: CommandType.StoredProcedure).ToList();
				return dbObjectProps;
			});
		}

		/// <summary>
		/// Получить данные по объектам, попадающим под фильтр для табличного представления 
		/// </summary>
		/// <param name="filterIds">Идентификаторы выбранных вариантов в фильтрах</param>
		/// <returns></returns>
		public List<DbObjectTabInfo> GetObjectForTab(IEnumerable<long> filterIds)
		{
			var fnName = "filter_semiflat_pck.get_filtered_map_objects_tab";
			return WithConnection(db =>
			{
				var p = new OracleDynamicParameters();

				var value = new
				{
					id = filterIds
				};
				var newvalue = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(value));
				var clob = new OracleClob((OracleConnection)db);
				clob.Write(newvalue, 0, newvalue.Length);

				p.Add("p_id_col", clob, OracleDbType.Clob, ParameterDirection.Input);

				p.Add("rv", dbType: OracleDbType.RefCursor, direction: ParameterDirection.ReturnValue);
				var dbObjectProps = db.Query<DbObjectTabInfo>(fnName, p, commandType: CommandType.StoredProcedure).ToList();
				return dbObjectProps;
			});
		}
	}  
}
