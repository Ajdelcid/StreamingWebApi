using StreamingWebApi.Oracle;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace StreamingWebApi.Repositories
{
    public class WS_CLASIFICACIONRepository : IWS_CLASIFICACIONRepository
    {
        IConfiguration configuration;
        public WS_CLASIFICACIONRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetWS_CLASIFICACIONDetails(int clId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("CL_ID", OracleDbType.Int32, ParameterDirection.Input, clId);
                dyParam.Add("CL_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_CLASIFICACIONDETAILS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetWS_CLASIFICACIONList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("CLCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_CLASIFICACION";

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
