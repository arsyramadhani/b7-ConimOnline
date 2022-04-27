using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Pdf;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ConimOnline.Service;

namespace ConimOnline.Controllers.Api
{
    public class DocController : ApiController
    { 
        // POST api/<controller>
        public HttpResponseMessage Post([FromUri] string path)
        { 
            string ext;
            ext = Path.GetExtension(path);
            string SavedFile;

            var ResponseMessage = new HttpResponseMessage();

            if (ext == ".xls" || ext == ".xlsx")
            {
                string SavedFileLocation= new ConverterDocumentService().ExcelConvert(path);
                SavedFile = SavedFileLocation;

                ResponseMessage = Request.CreateResponse(HttpStatusCode.OK, "Success: " + SavedFile.ToString());
            } else if (ext == ".doc" || ext == ".docx")
            {
                string SavedFileLocation = new ConverterDocumentService().WordConvert(path);
                SavedFile = SavedFileLocation;

                ResponseMessage = Request.CreateResponse(HttpStatusCode.OK, "Success: " + SavedFile.ToString());
            } else
            {
                ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, "Error: Bad File Type");
            } 

            return ResponseMessage;
        } 
    }

    public class DocServices
    {
         
    }
}