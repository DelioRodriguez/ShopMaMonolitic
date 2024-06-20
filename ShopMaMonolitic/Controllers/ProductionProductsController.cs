using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;
using System;
using System.Collections.Generic;

namespace ShopMaMonolitic.Controllers
{
    public class ProductionProductsController : Controller
    {
        private readonly IProductionProductsDb productsService;

        public ProductionProductsController(IProductionProductsDb productsService)
        {
            this.productsService = productsService;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = productsService.GetProducts();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = productsService.GetProduct(id);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductionProductsAddModel productAddModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productAddModel.CreationDate = DateTime.Now;
                    productAddModel.CreatorUser = 1; 
                    productsService.SaveProducts(productAddModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(productAddModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(productAddModel);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = productsService.GetProduct(id);
            var model = new ProductionProductsUpdateModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                categoryID = product.categoryID,
                supplierID = product.supplierID,
                ModifyUser = product.modify_user ?? 1, 
                ModifyDate = product.modify_date ?? DateTime.Now,
                CreationDate = product.CreationDate,
                UnitPrice = product.UnitPrice,
                Discontinued = product.Discontinued
            };
            return View(model);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductionProductsUpdateModel productUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productUpdate.ModifyUser = 1; 
                    productUpdate.ModifyDate = DateTime.Now;
                    productsService.UpdateProducts(productUpdate);
                    return RedirectToAction(nameof(Index));
                }
                return View(productUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(productUpdate);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productsService.GetProduct(id);
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var productToRemove = new ProductionProductsRemoveModel
                {
                    ProductID = id,
                    DeletedUser = 1, 
                    DeletedDate = DateTime.Now
                };
                productsService.RemoveProducts(productToRemove);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists, see your system administrator.");
                var product = productsService.GetProduct(id);
                return View(product);
            }
        }
    }
}
