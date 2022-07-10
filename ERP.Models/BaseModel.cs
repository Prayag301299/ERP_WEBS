using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Models
{
    public class BaseModel
    {
        public string CreatadeBy { get; set; }
        public DateTime CreatadeDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastupdatedDate { get; set; }
    }
}
