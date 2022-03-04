using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConimOnline.DAL
{
    public class ConimDAL
    {
        public string StoredProcedure(DynamicParameters parameters, String Spname, String Conn)
        {
            //string result;
            ConnectionStringSettings dbConnString = ConfigurationManager.ConnectionStrings[Conn];
            IDbConnection db = new SqlConnection(dbConnString.ConnectionString);

            try
            {
                var StoredProcedure = db.Query<dynamic>(Spname, parameters,
                   commandType: CommandType.StoredProcedure).ToList();

                return JsonConvert.SerializeObject(StoredProcedure, Formatting.Indented); 

            }
            catch (Exception ex)
            {

                return JsonConvert.SerializeObject(ex); ;
            }
        }
    }
}