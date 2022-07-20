using ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ERP.Repository.Interface
{
    public interface ICommonApiClass
    {
        ResponseViewModel GetApi(string ControlerName, string methodName);
        ResponseViewModel GetDataById(string ControlerName, string methodName, string para);
        ResponseViewModel DeleteApi(string ControlerName, string methodName, string para);
        HttpResponseMessage PostApi(string ControlerName, string methodName, string BodyData);
    }
}
