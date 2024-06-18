using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class SalesCustomersController : Controller
    {
        private readonly ISalesCustomersDb salesCustomersService;
        public SalesCustomersController(ISalesCustomersDb salesCustomersDb)
        {
            this.salesCustomersService = salesCustomersDb;
        }

        // GET: SalesCustomersController
        public ActionResult Index()
        {
            var salesCustomers = this.salesCustomersService.GetSalesCustomers();
            return View(salesCustomers);
        }

        // GET: SalesCustomersController/Details/5
        public ActionResult Details(int id)
        {
            var cust = salesCustomersService.GetSalesCustomer(id);
            return View(cust);
        }

        // GET: SalesCustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesCustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaveSalesCustomersModel customerAdd)
        {

            try
            {
                this.salesCustomersService.SaveSalesCustomers(customerAdd);
                return RedirectToAction(nameof(Index));
            }
            catch(SalesCustomerServicesExeption exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: SalesCustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var cust = this.salesCustomersService.GetSalesCustomer(id);
            var updateCustomers = new UpdateSalesCustomersModel
            {
                CustId = cust.CustId,
                CompanyName = cust.CompanyName,
                ContactName = cust.ContactName,
                ContactTitle = cust.ContactTitle,
                Address = cust.Address,
                Email = cust.Email,
                City = cust.City,
                Region = cust.Region,
                PostalCode = cust.PostalCode,
                Country = cust.Country,
                Phone = cust.Phone,
                Fax = cust.Fax
            };
            return View(updateCustomers);
        }

        // POST: SalesCustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateSalesCustomersModel updateModel)
        {
            try
            {
                this.salesCustomersService.UpdateSalesCustomers(updateModel);
                return RedirectToAction(nameof(Index));
            }
            catch(SalesCustomerServicesExeption exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: SalesCustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = salesCustomersService.GetSalesCustomer(id);
            return View(customer);
        }

        // POST: SalesCustomersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var removeModel = new RemoveSalesCustomersModel { CustId = id };
                salesCustomersService.RemoveSalesCustomers(removeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete customer.");
                var customer = salesCustomersService.GetSalesCustomer(id);
                return View(customer);
            }
        }
    }
}