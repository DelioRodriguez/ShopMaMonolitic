using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Interfaces;

namespace ShopMaMonolitic.Controllers
{
    public class SalesCustomersController : Controller
    {
        private readonly ISalesCustomersDb salesCustomersDb;
        public SalesCustomersController(ISalesCustomersDb salesCustomersDb)
        {
            this.salesCustomersDb = salesCustomersDb;
        }
        // GET: SalesCustomersController
        public ActionResult Index()
        {
            var salesCustomers = this.salesCustomersDb.GetSalesCustomers();
            return View(salesCustomers);
        }

        // GET: SalesCustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesCustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesCustomersController/Create
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

        // GET: SalesCustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesCustomersController/Edit/5
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

        // GET: SalesCustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesCustomersController/Delete/5
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
