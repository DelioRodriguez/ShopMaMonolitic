using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Interfaces;

namespace ShopMaMonolitic.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly ISalesOrderDetailsDb salesOrderDetailsDb;
        public SalesOrderDetailsController(ISalesOrderDetailsDb salesOrderDetailsDb)
        {
            this.salesOrderDetailsDb = salesOrderDetailsDb;
        }

        // GET: SalesOrderDetailsController
        public ActionResult Index()
        {
            var salesOrderDetails = this.salesOrderDetailsDb.GetSalesOrderDetails();
            return View();
        }

        // GET: SalesOrderDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesOrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesOrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesOrderDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesOrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesOrderDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesOrderDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
