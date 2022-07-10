using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.ViewModel
{
    public class CountryMasterViewModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CreatadeBy { get; set; }
        public DateTime CreatadeDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastupdatedDate { get; set; }
    }
}
