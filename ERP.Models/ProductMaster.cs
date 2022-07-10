using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Models
{
    public class ProductMaster : BaseModel
    {
        public int Product_Id { get; set; }
        public string Shade_Item { get; set; }
        public int GSM { get; set; }
        public int BF { get; set; }
        public int Dia { get; set; }
        public string Product_Code { get; set; }
        public int Max_Inventry_Kg { get; set; }
        public int Size_Inch { get; set; }
    }
}
