using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Models
{
    public class StateMaster : BaseModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }

    }
}
