using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.ViewModel
{
    public class StateMasterViewModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
        public string CreatadeBy { get; set; }
        public DateTime CreatadeDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastupdatedDate { get; set; }
    }
}
