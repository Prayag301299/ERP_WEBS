using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.ViewModel
{
    public class ResponseViewModel
    {
        public int statusCode { get; set; }
        public bool isSuccess { get; set; }
        public object data { get; set; }
        public string msg { get; set; }
    }
}