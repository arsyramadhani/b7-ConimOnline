using ConimOnline.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ConimOnline.Models;
using Dapper;
using System.IO;
using System.Data;
using System.Web.Http;

namespace ConimOnline.Controllers.Api
{
    public class ConimController : Controller
    { 

        readonly ConimDAL conimDAL = new ConimDAL();

        readonly string conString = ConfigurationManager.ConnectionStrings["CONIM"].ConnectionString;
        readonly string SP_CONIM_ONLINE = "[DBO].[SP_CONIM_ONLINE]";
        readonly string ConimConn = "CONIM";

        // POST: Conim 
        public ActionResult Index(ConimModel conimModel, string ListAnggota, string ListFasilitator)
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
                { "Filename", conimModel.Filename},
                { "Filepath", conimModel.Filepath},
            };
            var parameters = new DynamicParameters(dictionary);

            if (conimModel.Type == "QCP" || conimModel.Type == "QCC")
            {
                if (conimModel.Option == "POST_LAPORAN")
                { 
                    DataTable dtAnggota = JsonConvert.DeserializeObject<DataTable>(ListAnggota);
                    DataTable dtFasilitator = JsonConvert.DeserializeObject<DataTable>(ListFasilitator);
                     
                    parameters.Add("@LIST_ANGGOTA", dtAnggota.AsTableValuedParameter("[dbo].[AnggotaTableType]"));
                    parameters.Add("@LIST_FASILITATOR", dtFasilitator.AsTableValuedParameter("[dbo].[FasilitatorTableType]"));
                }
            } 

            return Json(conimDAL.StoredProcedure(parameters, SP_CONIM_ONLINE, ConimConn), JsonRequestBehavior.AllowGet);
        }

        //[Route("api/conim")]
        //public ActionResult Conim(ConimModel conimModel, AuthModel authModel)
        //{

        //    var dictionary = new Dictionary<string, object>
        //    {
        //        { "OPTION", conimModel.Option },
        //        { "USERAD", authModel.Username },
        //        { "CNM_NIK", conimModel.NIK },
        //        { "CNM_Number", conimModel.Number },
        //        { "CNM_Creator", conimModel.UserName },
        //        { "CNM_Type", conimModel.Type },
        //        { "CNM_NamaQCC", conimModel.QCC },
        //        { "CNM_NamaFasilitator", conimModel.Fasilitator },
        //        { "CNM_Nama", conimModel.Name },
        //        { "CNM_Departemen", conimModel.Department },
        //        { "CNM_Tema", conimModel.Tema },
        //        { "CNM_Flag", conimModel.Flag },
        //        { "CNM_UserID", conimModel.UserId },
        //        { "CNM_Branch", conimModel.Branch },
        //        { "CNM_Flag", conimModel.Flag },
        //        { "CNM_PICApproval", conimModel.PicApproval },
        //        { "CNM_NoteApprovalPIC", conimModel.PicNote },
        //        { "Filename", conimModel.Filename },
        //        { "Filepath", conimModel.Filepath },
        //        { "Name", conimModel.Name }, 
        //    };

        //    var parameters = new DynamicParameters(dictionary);
        //    return Json(conimDAL.StoredProcedure(parameters, SP_CONIM_ONLINE, ConimConn));
        //}

        public ActionResult Attachment()
        {
            string path;
            string randGuid = Guid.NewGuid().ToString();
            var file = Request.Files[0];
            var fileName = Path.GetFileName(randGuid + "_" + file.FileName);
            var alias = file.FileName;

            path = Path.Combine(Server.MapPath("~/uploadFolder/"), fileName);

            try
            {
                file.SaveAs(path);
            }
            catch (Exception ex)
            {

                //throw ex;
                return Json(ex.ToString());
            }

            path.Replace("\\\\", "\\");
            bool result = true;

            var myData = new
            {
                result,
                fileName,
                alias,
                path
            };


            if (System.IO.File.Exists(path))
            { 
                result = true;
                 
                return Json(JsonConvert.SerializeObject(myData));
            };

            result = false;
           
            return Json(JsonConvert.SerializeObject(myData));
        }

        public ActionResult DownloadFile(string filePath, string fileName)
        {
            string fullName = filePath;

            byte[] fileBytes = GetFile(fullName);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }

    }
}