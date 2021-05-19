using StreamingWebApi.Oracle;
using System;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace StreamingWebApi.Repositories
{
    public class WS_MULTIMEDIARepository : IWS_MULTIMEDIARepository
    {
        IConfiguration configuration;
        public WS_MULTIMEDIARepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetWS_MULTIMEDIADetails(int muId)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("MU_ID", OracleDbType.Int32, ParameterDirection.Input, muId);
                dyParam.Add("MU_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_MULTIMEDIADETAILS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetWS_MULTIMEDIAList()
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("MUCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_GETWS_MULTIMEDIA";

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
