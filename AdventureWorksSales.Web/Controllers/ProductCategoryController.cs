using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorksSales.Web.ViewModels;
using AdventureWorksSales.Core;
using System.Data;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductCategoryController : Controller
    {

        private IProductCategoryRepo productCategoryRepo;
        public int PageSize = 10;
        public ProductCategoryController(IProductCategoryRepo _productCategoryRepo)
        {
            productCategoryRepo = _productCategoryRepo;
        }

        public ActionResult Index(int page = 1)
        {
            var productCategories = productCategoryRepo.GetAll();
               
            var prod = new ProductCategoryListingModels
            {
                ProductCategories = productCategories
                .OrderBy(p => p.ProductCategoryID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = productCategories.Count()
                },
            };
            return View(prod);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productCategory.ModifiedDate = DateTime.Now;
                    productCategory.rowguid = Guid.NewGuid();
                    productCategoryRepo.Add(productCategory);

                    TempData["message"] = string.Format("{0} has been created", productCategory.Name);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (DataException err)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again later"+err.Message);
                return RedirectToAction("Index");
            }
            
        }

        // Get: Product Category
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductCategory productCategory = productCategoryRepo.Get(id);
            return View("index",productCategory);
        }


        public JsonResult Edit(ProductCategory productCategory)
        {
            bool result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    productCategory.ModifiedDate = DateTime.Now;
                    productCategoryRepo.Update(productCategory, productCategory.ProductCategoryID);

                    result = true;
                }
            }
            catch (DataException err)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again later" + err.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }

}