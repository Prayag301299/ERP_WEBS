using ERP.Models;
using ERP.ViewModel;
using ERP_WEB.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ERP_WEB.Controllers
{
    public class CountryController : Controller
    {
        Common CommonApiCall;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCountry()
        {

            return View();
        }

        
        [HttpPost]
        public IActionResult SaveCountry(CountryMaster model)
        {

            return View();
        }

    }
}
