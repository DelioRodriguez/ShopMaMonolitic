using DefaultNamespace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;
using System;

namespace ShopMaMonolitic.Controllers
{
    public class ProductionSuppliersController : Controller
    {
        private readonly IProductionSuppliersDb suppliersService;

        public ProductionSuppliersController(IProductionSuppliersDb suppliersService)
        {
            this.suppliersService = suppliersService;
        }

        // GET: ProductionSuppliers
        public ActionResult Index()
        {
            var suppliers = suppliersService.GetSuppliers();
            return View(suppliers);
        }

        // GET: ProductionSuppliers/Details/5
        public ActionResult Details(int id)
        {
            var supplier = suppliersService.GetSuppliers(id);
            return View(supplier);
        }

        // GET: ProductionSuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionSuppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductionSuppliersAddModel supplierAddModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierAddModel.CreationDate = DateTime.Now;
                    supplierAddModel.CreatorUser = 1; 
                    suppliersService.SaveSuppliers(supplierAddModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(supplierAddModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(supplierAddModel);
            }
        }

        // GET: ProductionSuppliers/Edit/5
        public ActionResult Edit(int id)
        {
            var supplier = suppliersService.GetSuppliers(id);
            var model = new ProductionSuppliersUpdateModel
            {
                SupplierId = supplier.SuppliersID,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                ModifyUser = 1, 
                ModifyDate = DateTime.Now,
            };
            return View(model);
        }

        // POST: ProductionSuppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductionSuppliersUpdateModel supplierUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierUpdate.ModifyUser = 1; // Suponiendo que 1 es el ID del usuario actual
                    supplierUpdate.ModifyDate = DateTime.Now;
                    suppliersService.UpdateSuppliers(supplierUpdate);
                    return RedirectToAction(nameof(Index));
                }
                return View(supplierUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                return View(supplierUpdate);
            }
        }

        // GET: ProductionSuppliers/Delete/5
        public ActionResult Delete(int id)
        {
            var supplier = suppliersService.GetSuppliers(id);
            var model = new ProductionSuppliersRemoveModel
            {
                SupplierId = id,
                Deleted = true,
                DeletedUser = 1,
                DeleteDate = DateTime.Now,
            };
            return View(supplier);
        }

        // POST: ProductionSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var supplierToRemove = new ProductionSuppliersRemoveModel
                {
                    SupplierId = id,
                    DeletedUser = 1, // Suponiendo que 1 es el ID del usuario actual
                    DeleteDate = DateTime.Now
                };
                suppliersService.RemoveSuppliers(supplierToRemove);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists, see your system administrator.");
                var supplier = suppliersService.GetSuppliers(id);
                return View(supplier);
            }
        }
    }
}
