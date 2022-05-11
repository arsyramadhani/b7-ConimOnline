using ConimOnline.DAL;
using ConimOnline.Models;
using ConimOnline.Helper;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Reflection;

namespace ConimOnline.Controllers.Api
{
    public class ConimApiController : ApiController
    {
        readonly ConimDAL conimDAL = new ConimDAL();
        readonly ConimHelper conimHelper = new ConimHelper();

        readonly string conString = ConfigurationManager.ConnectionStrings["CONIM"].ConnectionString;
        readonly string SP_CONIM_ONLINE = "[DBO].[SP_CONIM_ONLINE]";
        readonly string SP_CONIM_LAPORAN = "[DBO].[SP_CONIM_LAPORAN]"; 
        readonly string ConimConn = "CONIM";
        readonly string CultureAppsConn = "CULTURE_APPS";

        // GET api/<controller>
        [Route("api/conim")]
        public dynamic Get()
        {
            return "CONIM API V1";
        } 

        // POST api/<controller> 
        [Route("api/conim")]
        [HttpPost]
        public dynamic Post([FromBody] ConimModel conimModel)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "OPTION", conimModel.Option },
                { "USERAD", conimModel.UserName },
                { "CNM_NIK", conimModel.NIK },
                { "CNM_Type", conimModel.Type },
                { "CNM_NAMA", conimModel.Name },
                { "CNM_Creator", conimModel.UserName },
                { "CNM_Departemen", conimModel.Department },
                { "CNM_SubDept", conimModel.Subdept },
                { "CNM_Tema", conimModel.Tema },
                { "CNM_Approval", conimModel.Approval },
                { "CNM_PICApproval", conimModel.PicApproval },
                { "CNM_PICCompanyApproval", conimModel.PicCompanyApproval },
                { "CNM_UserID", conimModel.UserId },
                { "CNM_Number", conimModel.Number },
                { "CNM_NIKBefore", conimModel.NIKBefore },
                { "Filename", conimModel.Filename},
                { "Filepath", conimModel.Filepath},
                { "ApprovalType", conimModel.ApprovalType},
                { "CNM_NoteApproval", conimModel.ApprovalNote}
            };
            var parameters = new DynamicParameters(dictionary); 


            if (conimModel.Type == "QCP" || conimModel.Type == "QCC")
            {
                if (conimModel.Option == "POST_LAPORAN")
                {
                    //DataTable dtAnggota = JsonConvert.DeserializeObject<DataTable>(conimModel.ListAnggota);
                    //DataTable dtFasilitator = JsonConvert.DeserializeObject<DataTable>(conimModel.ListFasilitator.ToString());
                    DataTable dtAnggota = ToDataTable(conimModel.ListAnggota);
                    DataTable dtFasilitator = ToDataTable(conimModel.ListFasilitator);


                    parameters.Add("@LIST_ANGGOTA", dtAnggota.AsTableValuedParameter("[dbo].[AnggotaTableType]"));
                    parameters.Add("@LIST_FASILITATOR", dtFasilitator.AsTableValuedParameter("[dbo].[FasilitatorTableType]"));
                }
            }

            return conimDAL.SP(parameters, SP_CONIM_ONLINE, ConimConn);

        }

        // POST api/<controller> 
        [Route("api/laporan")]
        [HttpPost]
        public dynamic LaporanApi([FromBody] ConimModel conimModel)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "OPTION", conimModel.Option },
                { "USERAD", conimModel.UserName },
                { "CNM_NIK", conimModel.NIK }, 
                { "CNM_Type", conimModel.Type },
                { "CNM_NAMA", conimModel.Name },
                { "CNM_Creator", conimModel.UserName },
                { "CNM_Departemen", conimModel.Department },
                { "CNM_SubDept", conimModel.Subdept },
                { "CNM_Tema", conimModel.Tema },
                { "CNM_Approval", conimModel.Approval },
                { "CNM_PICApproval", conimModel.PicApproval },
                { "CNM_PICCompanyApproval", conimModel.PicCompanyApproval },
                { "CNM_UserID", conimModel.UserId },
                { "CNM_Number", conimModel.Number },
                { "CNM_NIKBefore", conimModel.NIKBefore },
                { "Filename", conimModel.Filename},
                { "Filepath", conimModel.Filepath},
                { "ApprovalType", conimModel.ApprovalType},
                { "CNM_NoteApproval", conimModel.ApprovalNote}
            };
            var parameters = new DynamicParameters(dictionary);


            if (conimModel.Type == "QCP" || conimModel.Type == "QCC")
            {
                if (conimModel.Option == "POST_LAPORAN")
                {
                    //DataTable dtAnggota = JsonConvert.DeserializeObject<DataTable>(conimModel.ListAnggota);
                    //DataTable dtFasilitator = JsonConvert.DeserializeObject<DataTable>(conimModel.ListFasilitator.ToString());
                    DataTable dtAnggota = ToDataTable(conimModel.ListAnggota);
                    DataTable dtFasilitator = ToDataTable(conimModel.ListFasilitator);


                    parameters.Add("@LIST_ANGGOTA", dtAnggota.AsTableValuedParameter("[dbo].[AnggotaTableType]"));
                    parameters.Add("@LIST_FASILITATOR", dtFasilitator.AsTableValuedParameter("[dbo].[FasilitatorTableType]"));
                }
            }

            return conimDAL.SP(parameters, SP_CONIM_LAPORAN, ConimConn);

        }

        [Route("api/v1/{sp}")]
        [HttpPost]
        public dynamic PostConim([FromBody] ConimModel conimModel, [FromUri] string sp)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "OPTION", conimModel.Option },
                { "USERAD", conimModel.UserName },
                { "CNM_NIK", conimModel.NIK },
                { "CNM_Type", conimModel.Type },
                { "CNM_NAMA", conimModel.Name },
                { "CNM_Creator", conimModel.UserName },
                { "CNM_Departemen", conimModel.Department },
                { "CNM_SubDept", conimModel.Subdept },
                { "CNM_Tema", conimModel.Tema },
                { "CNM_Approval", conimModel.Approval },
                { "CNM_PICApproval", conimModel.PicApproval },
                { "CNM_PICCompanyApproval", conimModel.PicCompanyApproval },
                { "CNM_UserID", conimModel.UserId },
                { "CNM_Number", conimModel.Number },
                { "CNM_Flag", conimModel.Flag },
                { "CNM_NIKBefore", conimModel.NIKBefore },
                { "Filename", conimModel.Filename},
                { "Filepath", conimModel.Filepath},
                { "CNM_Year", conimModel.Year},
                { "CNM_Site", conimModel.Site},
                { "ApprovalType", conimModel.ApprovalType},
                { "CNM_NoteApproval", conimModel.ApprovalNote}
            };
            var parameters = new DynamicParameters(dictionary);


            if (conimModel.Type == "QCP" || conimModel.Type == "QCC")
            {
                if (conimModel.Option == "POST_LAPORAN")
                {
                    //DataTable dtAnggota = JsonConvert.DeserializeObject<DataTable>(conimModel.ListAnggota);
                    //DataTable dtFasilitator = JsonConvert.DeserializeObject<DataTable>(conimModel.ListFasilitator.ToString());
                    DataTable dtAnggota = ToDataTable(conimModel.ListAnggota);
                    DataTable dtFasilitator = ToDataTable(conimModel.ListFasilitator);


                    parameters.Add("@LIST_ANGGOTA", dtAnggota.AsTableValuedParameter("[dbo].[AnggotaTableType]"));
                    parameters.Add("@LIST_FASILITATOR", dtFasilitator.AsTableValuedParameter("[dbo].[FasilitatorTableType]"));
                }
            }

            return conimDAL.SP(parameters, "[DBO].[" + sp.ToUpper() + "]", CultureAppsConn); 
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        [Route("api/trial/editdocument")] 
        public HttpResponseMessage GetEditDocument([FromUri] string path)
        {
            return Request.CreateResponse(HttpStatusCode.OK, path);
        } 
    }
     
}