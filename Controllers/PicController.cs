using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConimOnline.Controllers
{
    public class PicController : Controller
    {
        // GET: Pic
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pic
        public ActionResult ProgramKerja()
        {
            return View();
        }

        // GET: Pic
        public ActionResult Penilaian()
        {
            return View();
        }
    }
}