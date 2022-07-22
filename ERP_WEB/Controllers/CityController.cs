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
        public IActionResult Add()
        {
            fillDropDown();
            CityMasterViewModel model = new CityMasterViewModel();
            return PartialView("Add", model);
        }
        public ActionResult Edit(int Id)
        {
            fillDropDown();
            CityMasterViewModel CityViewModel = new CityMasterViewModel();
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.GetDataById("City", "GetCityById", "id=" + Id);
            if (response.data != null)
            {
                CityViewModel = JsonConvert.DeserializeObject<CityMasterViewModel>(response.data.ToString());
            }
            return PartialView("Add", CityViewModel);
        }
        public IActionResult Save(CityMaster model)
        {

            if (ModelState.IsValid)
            {

                commonApiClassrepo = new CommonApiClass(_config);
                var json = JsonConvert.SerializeObject(model);
                var abc = commonApiClassrepo.PostApi("City", "AddOrEditCity", json);
            }
            return RedirectToAction("Index");
        }
        void fillDropDown()
        {
            ResponseViewModel responseforCountry = new ResponseViewModel();
            List<CountryMaster> Country = new List<CountryMaster>();
            commonApiClassrepo = new CommonApiClass(_config);
            responseforCountry = commonApiClassrepo.GetApi("Country", "GetAllCountry");
            if (responseforCountry.data != null)
            {
                Country = JsonConvert.DeserializeObject<List<CountryMaster>>(responseforCountry.data.ToString());
                if (Country.Count > 0)
                {
                    ViewBag.Country = Country;
                }
            }



            ResponseViewModel responseforState = new ResponseViewModel();
            List<StateMaster> State = new List<StateMaster>();
            commonApiClassrepo = new CommonApiClass(_config);
            responseforState = commonApiClassrepo.GetApi("State", "GetAllState");
            if (responseforState.data != null)
            {
                State = JsonConvert.DeserializeObject<List<StateMaster>>(responseforState.data.ToString());
                if (State.Count > 0)
                {
                    ViewBag.State = State;
                }
            }
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
