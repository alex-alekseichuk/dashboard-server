using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Sota.Dashboard.DataAccess.Models;
using Sota.Dashboard.DataAccess.Utils;

namespace Sota.Dashboard.DataAccess
{
  public interface IEntityRepository {
    IEnumerable<EntityDbo> getEntityAttributes(int entityId);
  }
  
  // TODO: extends it from RepositoryBase
  public class EntityRepository : IEntityRepository {
    public EntityRepository() {
    }
    public IEnumerable<EntityDbo> getEntityAttributes(int entityId) {
        var connStr = "Data Source=localhost:1521/dev;User ID=test_user;Password=test_password";
        using (var conn = new OracleConnection(connStr)) {
          var @params = new OracleDynamicParameters();
          @params.Add("p_entity_id", entityId, OracleDbType.Int64, ParameterDirection.Input);
          @params.Add("p_is_full_info", 1, OracleDbType.Int32, ParameterDirection.Input);
          @params.Add("", dbType: OracleDbType.RefCursor, direction: ParameterDirection.ReturnValue);
          return conn.Query<EntityDbo>("filter_semiflat_pck.get_object_info", @params, commandType: CommandType.StoredProcedure).ToList();
        }
    }
  }
}