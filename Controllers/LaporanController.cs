using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConimOnline.DAL;
using Newtonsoft.Json;
using ConimOnline.Models;
using Dapper;
using System.Web.Http;

namespace ConimOnline.Controllers
{
    public class LaporanController : Controller
    {

        readonly ConimDAL conimDAL = new ConimDAL();

        readonly string conString = ConfigurationManager.ConnectionStrings["CONIM"].ConnectionString;
        ////readonly string SP_CONIM_ONLINE = "[DBO].[SP_CONIM_ONLINE]";
        ////readonly string ConimConn = "CONIM";

        // GET: Laporan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Find()
        {
            return View();
        }
        public ActionResult Outstanding()
        {
            return View();
        }
        public ActionResult Details([FromUri] string id)

        {
            ViewBag.CNM_Number = id;
            return View();
        }

        #region DataFetching

        //[Route("Conim")]
        //public ActionResult Conim(ConimModel conimModel, AuthModel authModel)
        //{
        //    var dictionary = new Dictionary<string, object>
        //    {
        //        { "OPTION", conimModel.Option },
        //        { "USERAD", authModel.Username },
        //    };

        //    var parameters = new DynamicParameters(dictionary);
        //    return Json(conimDAL.StoredProcedure(parameters, SP_CONIM_ONLINE, ConimConn));
        //}
        #endregion
    }
}