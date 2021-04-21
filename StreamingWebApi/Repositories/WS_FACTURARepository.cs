using StreamingWebApi.Oracle;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace StreamingWebApi.Repositories
{
    public class WS_FACTURARepository : IWS_FACTURARepository
    {
        IConfiguration configuration;
        public WS_FACTURARepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetWS_FACTURADetails(int usId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("FC_ID", OracleDbType.Int32, ParameterDirection.Input, usId);
                dyParam.Add("FC_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_FACTURADETAILS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetWS_FACTURAList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("FCCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_FACTURA";

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

