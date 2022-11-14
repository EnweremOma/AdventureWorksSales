using AdventureWorksSales.Core.Abstract;
using AdventureWorksSales.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISalesOrderRepo salesOrderRepo;
        public HomeController(ISalesOrderRepo _salesOrderRepo)
        {
            salesOrderRepo = _salesOrderRepo;
        }
        public async Task<ActionResult> Index()
        {
            var model = new HomeViewModel
            {
                TotalOrders = salesOrderRepo.GetAll().Count(),
                HigestLineTotal = decimal.Round((await salesOrderRepo.GetLineTotal()).Max(), 3, MidpointRounding.AwayFromZero),
                FrontBrakeSalesTotal = (await salesOrderRepo.GetProductSales(948)).Count()
            };
            return View(model);
        }

    }
}