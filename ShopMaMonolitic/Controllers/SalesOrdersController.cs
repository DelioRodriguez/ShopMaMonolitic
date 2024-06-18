using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class SalesOrdersController : Controller
    {
        private readonly ISalesOrdersDb salesOrdersService;
        
        public SalesOrdersController(ISalesOrdersDb salesOrdersDb)
        {
            this.salesOrdersService = salesOrdersDb;
        }

        // GET: SalesOrderController
        public ActionResult Index()
        {
            var salesOrders = this.salesOrdersService.GetSalesOrders();
            return View(salesOrders);
        }

        // GET: SalesOrderController/Details/5
        public ActionResult Details(int id)
        {
            var order = this.salesOrdersService.GetSalesOrder(id);
            return View(order);
        }

        // GET: SalesOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaveSalesOrdersModel orderAdd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.salesOrdersService.SaveSalesOrders(orderAdd);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(orderAdd);
        }

        // GET: SalesOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var order = this.salesOrdersService.GetSalesOrder(id);
            return View(order);
        }

        // POST: SalesOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateSalesOrdersModels updateModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.salesOrdersService.UpdateSalesOrdes(updateModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(updateModel);
        }

        // GET: SalesOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = this.salesOrdersService.GetSalesOrder(id);
            return View(order);
        }

        // POST: SalesOrderController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var removeModel = new RemoveSalesOrdersModel { OrderId = id };
                this.salesOrdersService.RemoveSalesOrders(removeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete order.");
                var order = this.salesOrdersService.GetSalesOrder(id);
                return View(order);
            }
        }
    }
}
