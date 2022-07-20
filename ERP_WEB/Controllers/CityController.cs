using ERP.Models;
using ERP.Repository.Implement;
using ERP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_WEB.Controllers
{
    public class CityController : Controller
    {
        IConfiguration _config;
        public CityController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<CityMaster> City = new List<CityMaster>();
            response = commonApiClassrepo.GetApi("City", "GetAllCity");
            if (response.data != null)
            {
                City = JsonConvert.DeserializeObject<List<CityMaster>>(response.data.ToString());
                if (City.Count > 0)
                {
                    return View(City);
                }
                else
                {
                    return View();
                }
            }
            return View(City);
        }


        public ActionResult Delete(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.DeleteApi("City", "DeleteCity", "id=" + Id);
            if (response.isSuccess == true)
            {
                return Json(new { isSuccess = true, msg = "Deleted Successfully" });
            }
            else
            {
                return Json(new { isSuccess = false });
            }

        }
    }
}
