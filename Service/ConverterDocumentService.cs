using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConimOnline.Service
{
    public class ConverterDocumentService
    {
        readonly string ApprovePic = "D:\\2022_Development\\WEB_CONIM\\" + "approve.png";
        readonly string PathtoSaveFile = "D:\\2022_Development\\WEB_CONIM\\PDF";
        readonly Guid guid = Guid.NewGuid();

        public string ExcelConvert(String path)
         {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(path);

            string SaveLocation = PathtoSaveFile + "XLS_" + guid.ToString() + ".pdf";

            Worksheet sheet = workbook.Worksheets[0];

            //string picPath = "D:\\2022_Development\\WEB_CONIM\\" + "approve.png";
            ExcelPicture pictureApproveAtasan = sheet.Pictures.Add(3, 56, ApprovePic);
            pictureApproveAtasan.Width = pictureApproveAtasan.Width / 100 * 15;
            pictureApproveAtasan.Height = pictureApproveAtasan.Height / 100 * 15;
            pictureApproveAtasan.LeftColumnOffset = 100;
            pictureApproveAtasan.TopRowOffset = 25;
            //pictureApproveAtasan.ResizeBehave = ResizeBehaveType.MoveAndResize; //not working 
            ExcelPicture pictureApprovePIC = sheet.Pictures.Add(3, 61, ApprovePic);
            pictureApprovePIC.Width = pictureApprovePIC.Width / 100 * 15;
            pictureApprovePIC.Height = pictureApprovePIC.Height / 100 * 15;
            pictureApprovePIC.LeftColumnOffset = 100;
            pictureApprovePIC.TopRowOffset = 25; 

            workbook.SaveToFile(SaveLocation, Spire.Xls.FileFormat.PDF);

            return SaveLocation;
         } 

         public string WordConvert (string path)
         {
            Document document = new Document(path);
            document.LoadFromFile(path);

            string SaveLocation = PathtoSaveFile + "DOC_" + guid.ToString() + ".pdf";

            Section section = document.Sections[0];
            Paragraph para1 = section.Paragraphs[0];
            para1.Text = "Text updated";

            document.SaveToFile(SaveLocation, Spire.Doc.FileFormat.PDF);

            return SaveLocation;
        }

         
    }
}