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
    public class GSMController : Controller
    {
        IConfiguration _config;
        public GSMController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<Gsm> Gsmmaster = new List<Gsm>();
            response = commonApiClassrepo.GetApi("Gsm", "GetAllGsm");
            if (response.data != null)
            {
                Gsmmaster = JsonConvert.DeserializeObject<List<Gsm>>(response.data.ToString());
                if (Gsmmaster.Count > 0)
                {
                    ViewBag.GsmMaster = Gsmmaster;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            return View(Gsmmaster);
        }
        public IActionResult Add()
        {
            GsmViewModel model = new GsmViewModel();
            return PartialView("Add", model);
        }
        public ActionResult Edit(int Id)
        {
            GsmViewModel GSMViewModel = new GsmViewModel();
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.GetDataById("Gsm", "GetGsmById", "id=" + Id);
            if (response.data != null)
            {
                GSMViewModel = JsonConvert.DeserializeObject<GsmViewModel>(response.data.ToString());
            }
            return PartialView("Add", GSMViewModel);
        }
        public ActionResult Delete(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.DeleteApi("Gsm", "DeleteGsm", "id=" + Id);
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
        public IActionResult Save(GsmViewModel model)
        {

            if (ModelState.IsValid)
            {

                commonApiClassrepo = new CommonApiClass(_config);
                var json = JsonConvert.SerializeObject(model);
                var abc = commonApiClassrepo.PostApi("Gsm", "AddOrEditGsm", json);
            }
            return RedirectToAction("Index");
        }
    }
}
