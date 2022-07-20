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
                ResponseViewModel responseforstate = new ResponseViewModel();
                List<CountryMaster> Country = new List<CountryMaster>();
                responseforstate = commonApiClassrepo.GetApi("Country", "GetAllCountry");
                if (responseforstate.data != null)
                {
                    Country = JsonConvert.DeserializeObject<List<CountryMaster>>(response.data.ToString());
                    if (Country.Count > 0)
                    {
                        ViewBag.Country = Country;
                    }
                }
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

        public StateMasterViewModel getStateDetails()
        {
            StateMasterViewModel model = new StateMasterViewModel();
            commonApiClassrepo = new CommonApiClass(_config);

            ResponseViewModel Stateresponse = new ResponseViewModel();
            ResponseViewModel Countryresponse = new ResponseViewModel();

            //Get State Data
            List<StateMaster> State = new List<StateMaster>();
            List<StateMasterViewModel> StateView = new List<StateMasterViewModel>();
            
            //Get Country Date
            List<CountryMaster> Country = new List<CountryMaster>();


            Stateresponse = commonApiClassrepo.GetApi("State", "GetAllState");
            if (Stateresponse.data != null)
            {
                State = JsonConvert.DeserializeObject<List<StateMaster>>(Stateresponse.data.ToString());

            }
            Countryresponse = commonApiClassrepo.GetApi("Country", "GetAllCountry");
            if (Countryresponse.data != null)
            {
                Country = JsonConvert.DeserializeObject<List<CountryMaster>>(Countryresponse.data.ToString());
            }



            return model;
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
    }
}
