using AdventureWorksSales.Core.Abstract;
using AdventureWorksSales.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class SalesOrderController : Controller
    {
        private ISalesOrderRepo salesOrderRepo;
        public int PageSize = 100;

        public SalesOrderController(ISalesOrderRepo _salesOrderRepo)
        {
            salesOrderRepo = _salesOrderRepo;
        }
        // GET: SalesOrder
        
        public ActionResult Index(int page = 1)
        {
            var salesOrders = salesOrderRepo.GetAll();

            var order = new SalesOrderListingViewModels
            {
                SalesOrders = salesOrders
                .OrderBy(p => p.SalesOrderID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = salesOrders.Count()
                },
            };
            return View(order);
        }
    }
}