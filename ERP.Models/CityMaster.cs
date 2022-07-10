using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Models
{
    public class CityMaster : BaseModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}
