using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.ViewModel
{
    public class DealerMasterViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public bool Status { get; set; }
        public string LegalStatus { get; set; }
        public string NatureofBusiness { get; set; }
        public string Industry { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Zipcode { get; set; }
        public string Landline_mobileno { get; set; }
        public string EmailID { get; set; }
        public string Salutation { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public string EmailId2 { get; set; }
        public string Website { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Dow { get; set; }
        public string Tanno { get; set; }
        public string GSTNo { get; set; }
        public string PANNo { get; set; }
        public string GSTIN_UIN { get; set; }
        public string CreatadeBy { get; set; }
        public DateTime CreatadeDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastupdatedDate { get; set; }
    }
}
