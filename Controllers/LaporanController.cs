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
         
        public ActionResult Chart()
        {
            return View();
        }
        public ActionResult Details([FromUri] string id)

        {
            ViewBag.CNM_Number = id;
            return View();
        }

        public ActionResult Edit([FromUri] string id)

        {
            ViewBag.CNM_Number = id;
            return View();
        }

        public ActionResult New()

        { 
            return View();
        }

        #region DataFetching

        #endregion
    }
}