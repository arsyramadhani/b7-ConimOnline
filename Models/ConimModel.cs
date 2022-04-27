using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConimOnline.Models
{
    public class AuthModel
    {
        public string Sp { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }

    }

    public class ConimModel
    {
        public string Sp { set; get; }
        public string Option { set; get; }

        public string Number { set; get; }

        public string Tahun { set; get; }

        public string Type { set; get; }

        public string QCC { set; get; } 

        public string NIK { set; get; }

        public string UserName { set; get; }

        public string Department { set; get; }

        public string Tema { set; get; }

        public string UserId { set; get; }

        public string Flag { set; get; }

        public string Branch { set; get; }

        public string Approval { set; get; }
        public string ApprovalType { set; get; }
        public string PicApproval { set; get; }
        public string PicCompanyApproval { set; get; }
        public string ApprovalNote { set; get; }

        public string PicNote { set; get; }

        public string Subdept { set; get; }
        public string Filename { set; get; }
        public string Filepath { set; get; }
        public string Name { set; get; }

        //public List<AnggotaModel> ListAnggota;
        //public string ListAnggota;
        public List<AnggotaModel> ListAnggota;

        public List<FasilitatorModel> ListFasilitator;
         
    }

    public class AnggotaModel
    {
        public string NIK { get; set; }
        public string Type { get; set; }

    }

    public class FasilitatorModel
    {
        public string NIK { set; get; }
    }


}
 