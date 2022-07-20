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
    public class DIAController : Controller
    {
        IConfiguration _config;
        public DIAController(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        CommonApiClass commonApiClassrepo;
        public IActionResult Index()
        {
            ResponseViewModel response = new ResponseViewModel();
            commonApiClassrepo = new CommonApiClass(_config);
            List<Dia> Diamaster = new List<Dia>();
            response = commonApiClassrepo.GetApi("Bf", "GetAllBf");
            if (response.data != null)
            {
                Diamaster = JsonConvert.DeserializeObject<List<Dia>>(response.data.ToString());
            }
            return View(Diamaster);
        }
    }
}
