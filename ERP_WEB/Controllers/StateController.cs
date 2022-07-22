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
    public class StateController : Controller
    {
        IConfiguration _config;
        public StateController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Add()
        {
            fillDropDown();
            StateMasterViewModel model = new StateMasterViewModel();
            return PartialView("Add", model);
        }
        public ActionResult Edit(int Id)
        {
            fillDropDown();
            StateMasterViewModel StateViewModel = new StateMasterViewModel();
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.GetDataById("State", "GetStateById", "id=" + Id);
            if (response.data != null)
            {
                StateViewModel = JsonConvert.DeserializeObject<StateMasterViewModel>(response.data.ToString());
            }
            return PartialView("Add", StateViewModel);
        }
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<StateMaster> State = new List<StateMaster>();
            List<StateMasterViewModel> StateView = new List<StateMasterViewModel>();
            response = commonApiClassrepo.GetApi("State", "GetAllState");
            if (response.data != null)
            {
                State = JsonConvert.DeserializeObject<List<StateMaster>>(response.data.ToString());
                ViewBag.GetState = State;
            }
            return View();
        }




        public ActionResult Delete(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.DeleteApi("State", "DeleteState", "id=" + Id);
            if (response.statusCode == 400)
            {
                return Json(new { isSuccess = false, msg = "This state In Use For City" });
            }
            if (response.isSuccess == true)
            {
                return Json(new { isSuccess = true, msg = "Deleted Successfully" });
            }
            else
            {
                return Json(new { isSuccess = false });
            }

        }

        [HttpPost]
        public IActionResult Save(StateMaster model)
        {

            if (ModelState.IsValid)
            {

                commonApiClassrepo = new CommonApiClass(_config);
                var json = JsonConvert.SerializeObject(model);
                var abc = commonApiClassrepo.PostApi("State", "AddOrEditState", json);
            }
            return RedirectToAction("Index");
        }

        void fillDropDown()
        {
            ResponseViewModel responseforstate = new ResponseViewModel();
            List<CountryMaster> Country = new List<CountryMaster>();
            commonApiClassrepo = new CommonApiClass(_config);
            responseforstate = commonApiClassrepo.GetApi("Country", "GetAllCountry");
            if (responseforstate.data != null)
            {
                Country = JsonConvert.DeserializeObject<List<CountryMaster>>(responseforstate.data.ToString());
                if (Country.Count > 0)
                {
                    ViewBag.Country = Country;
                }
            }
        }
    }
}
