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
    public class BFController : Controller
    {
        IConfiguration _config;
        public BFController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<Bf> bfmaster = new List<Bf>();
            response = commonApiClassrepo.GetApi("Bf", "GetAllBf");
            if (response.data != null)
            {
                bfmaster = JsonConvert.DeserializeObject<List<Bf>>(response.data.ToString());
                if (bfmaster.Count > 0)
                {
                    ViewBag.BF = bfmaster;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            return View(bfmaster);
        }
        public IActionResult Get()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<Bf> bfmaster = new List<Bf>();
            response = commonApiClassrepo.GetApi("Bf", "GetAllBf");
            if (response.data != null)
            {
                bfmaster = JsonConvert.DeserializeObject<List<Bf>>(response.data.ToString());
                if (bfmaster.Count > 0)
                {
                    //ViewBag.BF = bfmaster;
                    return Json(JsonConvert.SerializeObject(bfmaster));
                }
                else
                {
                    return Json(JsonConvert.SerializeObject(bfmaster));
                }
            }

            return Json(JsonConvert.SerializeObject(bfmaster));
        }
        public IActionResult Add()
        {
            BFViewModel model = new BFViewModel();
            return PartialView("Add", model);
        }
        public ActionResult Edit(int Id)
        {
            BFViewModel BFViewModel = new BFViewModel();
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.GetDataById("Bf", "GetBfById", "id=" + Id);
            if (response.data != null)
            {
                BFViewModel = JsonConvert.DeserializeObject<BFViewModel>(response.data.ToString());
            }
            return PartialView("Add", BFViewModel);
        }
        public ActionResult Delete(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.DeleteApi("Bf", "DeleteBf", "id=" + Id);
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
        public IActionResult Save(Bf model)
        {

            if (ModelState.IsValid)
            {

                commonApiClassrepo = new CommonApiClass(_config);
                var json = JsonConvert.SerializeObject(model);
                var abc = commonApiClassrepo.PostApi("Bf", "AddOrEditBf", json);
            }
            return RedirectToAction("Index");
        }
    }
}
