﻿using ConimOnline.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ConimOnline.Models;
using Dapper;

namespace ConimOnline.Controllers.Api
{
    public class ConimController : Controller
    {


        readonly ConimDAL conimDAL = new ConimDAL();

        readonly string conString = ConfigurationManager.ConnectionStrings["CONIM"].ConnectionString;
        readonly string SP_CONIM_ONLINE = "[DBO].[SP_CONIM_ONLINE]";
        readonly string ConimConn = "CONIM";

        // GET: Conim
        public ActionResult Index(ConimModel conimModel, AuthModel authModel)
        {

            var dictionary = new Dictionary<string, object>
            {
                { "OPTION", conimModel.Option },
                { "USERAD", authModel.Username },
            };

            var parameters = new DynamicParameters(dictionary);
            return Json(conimDAL.StoredProcedure(parameters, SP_CONIM_ONLINE, ConimConn));
        }
    }
}