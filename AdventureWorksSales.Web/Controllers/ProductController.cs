using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorksSales.Web.ViewModels;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo productRepo;
        public int PageSize = 30;

        public ProductController(IProductRepo _productRepo)
        {
            productRepo = _productRepo;
        }
        // GET: Product

        public ActionResult Index(int page = 1)
        {
            var products = productRepo.GetAll();

            var prod = new ProductListingViewModels
            {
                Products = products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count()
                },
            };
            return View(prod);
        }
    }
}