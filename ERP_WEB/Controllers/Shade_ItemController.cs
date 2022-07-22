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
    public class Shade_ItemController : Controller
    {
        IConfiguration _config;
        public Shade_ItemController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<Shade> Shademaster = new List<Shade>();
            response = commonApiClassrepo.GetApi("Shade", "GetAllShade");
            if (response.data != null)
            {
                Shademaster = JsonConvert.DeserializeObject<List<Shade>>(response.data.ToString());
                if (Shademaster.Count > 0)
                { 
                    ViewBag.Shade = Shademaster;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Add()
        {
            ShadeViewModel model = new ShadeViewModel();
            return PartialView("Add", model);
        }
        public ActionResult Edit(int Id)
        {
            ShadeViewModel ShadeViewModel = new ShadeViewModel();
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.GetDataById("Shade", "GetShadeById", "id=" + Id);
            if (response.data != null)
            {
                ShadeViewModel = JsonConvert.DeserializeObject<ShadeViewModel>(response.data.ToString());
            }
            return PartialView("Add", ShadeViewModel);
        }
        public ActionResult Delete(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            response = commonApiClassrepo.DeleteApi("Shade", "DeleteShade", "id="+Id);
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
        public IActionResult Save(Shade model)
        {

            if (ModelState.IsValid)
            {

                commonApiClassrepo = new CommonApiClass(_config);
                var json = JsonConvert.SerializeObject(model);
                var abc = commonApiClassrepo.PostApi("Shade", "AddOrEditShade", json);
            }
            return RedirectToAction("Index");
        }
    }
}
