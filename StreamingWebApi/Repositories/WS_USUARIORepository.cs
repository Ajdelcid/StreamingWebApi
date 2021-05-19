using StreamingWebApi.Oracle;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace StreamingWebApi.Repositories
{
    public class WS_USUARIORepository : IWS_USUARIORepository
    {
        IConfiguration configuration;
        public WS_USUARIORepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetWS_USUARIODetails(int usId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("US_ID", OracleDbType.Int32, ParameterDirection.Input, usId);
                dyParam.Add("US_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_USUARIODETAILS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetWS_USUARIOList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("USCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_USUARIO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetWS_USUARIOLogin(string usIdC, string usPass)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("US_ID", OracleDbType.NVarchar2, ParameterDirection.Input, usIdC);
                dyParam.Add("US_PASS", OracleDbType.NVarchar2, ParameterDirection.Input, usPass);
                dyParam.Add("US_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_USUARIOLogin";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Connection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }  
    }
}
