using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly ISalesOrderDetailsDb salesOrderDetailsService;

        public SalesOrderDetailsController(ISalesOrderDetailsDb salesOrderDetailsDb)
        {
            this.salesOrderDetailsService = salesOrderDetailsDb;
        }

        // GET: SalesOrderDetailsController
        public ActionResult Index()
        {
            var orderDetails = this.salesOrderDetailsService.GetSalesOrderDetails();
            return View(orderDetails);
        }

        // GET: SalesOrderDetailsController/Details/5
        public ActionResult Details(int id)
        {
            var ordersDetails = this.salesOrderDetailsService.GetSalesOrderDetail(id);
            return View(ordersDetails);
        }

        // GET: SalesOrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesOrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaveSalesOrderDetailsModel addModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    salesOrderDetailsService.SaveSalesOrderDetails(addModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(addModel);
        }

        // GET: SalesOrderDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            var orderDetails = salesOrderDetailsService.GetSalesOrderDetail(id);
            return View(orderDetails);
        }

        // POST: SalesOrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateSalesOrderDetailsModel updateModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    salesOrderDetailsService.UpdateSalesOrderDetails(updateModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(updateModel);
        }

        // GET: SalesOrderDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            var detaildelete = salesOrderDetailsService.GetSalesOrderDetail(id);
            return View(detaildelete);
        }

        // POST: SalesOrderDetailsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var removeModel = new RemoveSalesOrderDetailsModel { OrderID = id };
                salesOrderDetailsService.RemoveSalesOrderDetails(removeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete order detail.");
                var detail = salesOrderDetailsService.GetSalesOrderDetail(id);
                return View(detail);
            }
        }
    }
}