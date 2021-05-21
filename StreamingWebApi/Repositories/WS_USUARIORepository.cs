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

        public object PostWS_USUARIOInsert(int usIdC, string usName, string usSName, string usLastName, string usSLastName, string usEmail, string usPass, string usTel)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("US_USER", OracleDbType.Int32, ParameterDirection.Input, usIdC);
                dyParam.Add("US_PN", OracleDbType.Varchar2, ParameterDirection.Input, usName);
                dyParam.Add("US_SN", OracleDbType.Varchar2, ParameterDirection.Input, usSName);
                dyParam.Add("US_PA", OracleDbType.Varchar2, ParameterDirection.Input, usLastName);
                dyParam.Add("US_SA", OracleDbType.Varchar2, ParameterDirection.Input, usSLastName);
                dyParam.Add("US_MAIL", OracleDbType.Varchar2, ParameterDirection.Input, usEmail);
                dyParam.Add("US_PASS", OracleDbType.Varchar2, ParameterDirection.Input, usPass);
                dyParam.Add("US_TEL", OracleDbType.Varchar2, ParameterDirection.Input, usTel);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "US_POSTWS_USUARIODETAILS";

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
