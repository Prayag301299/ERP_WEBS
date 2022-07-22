using ERP.Models;
using ERP.Repository.Implement;
using ERP.ViewModel;
using ERP_WEB.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace ERP_WEB.Controllers
{
    public class CountryController : Controller
    {
        //public  Common _Common;
        IConfiguration _config;
        public CountryController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<CountryMaster> Country = new List<CountryMaster>();
            response = commonApiClassrepo.GetApi("Country", "GetAllCountry");
            if (response.data != null)
            {
                Country = JsonConvert.DeserializeObject<List<CountryMaster>>(response.data.ToString());
                if (Country.Count > 0)
                {
                    ViewBag.CounryData = Country;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            return View();
        }






        public IActionResult Add()
        {
            CountryMasterViewModel model = new CountryMasterViewModel();
            return PartialView("Add", model);
        }
        public ActionResult Edit(int Id)
        {
            CountryMasterViewModel country= new CountryMasterViewModel();
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.GetDataById("Country", "GetCountryById", "id=" + Id);
            if (response.data != null)
            {
                country = JsonConvert.DeserializeObject<CountryMasterViewModel>(response.data.ToString());
            }
            return PartialView("Add", country);
        }


        [HttpPost]
        public IActionResult Save(CountryMaster model)
        {

            if (ModelState.IsValid)
            {
                
                commonApiClassrepo = new CommonApiClass(_config);
                var json = JsonConvert.SerializeObject(model);
                var abc = commonApiClassrepo.PostApi("Country", "AddOrEditCountry", json);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.DeleteApi("Country", "DeleteCountry", "id=" + Id);
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
