using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.ViewModel
{
    public class ProductMasterViewModel
    {
        public int Product_Id { get; set; }
        public string Shade_Item { get; set; }
        public int GSM { get; set; }
        public int BF { get; set; }
        public int Dia { get; set; }
        public string Product_Code { get; set; }
        public int Max_Inventry_Kg { get; set; }
        public int Size_Inch { get; set; }
        public string CreatadeBy { get; set; }
        public DateTime CreatadeDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastupdatedDate { get; set; }
    }
}
