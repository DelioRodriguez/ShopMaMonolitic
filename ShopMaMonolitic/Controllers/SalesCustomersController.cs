using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers
{
    public class SalesCustomersController : Controller
    {
        private readonly ISalesCustomersServices salesCustomersService;
        private readonly ILogger<SalesCustomersController> _logger;

        public SalesCustomersController(ISalesCustomersServices salesCustomersService, ILogger<SalesCustomersController> logger)
        {
            this.salesCustomersService = salesCustomersService;
            this._logger = logger;
        }

        // GET: SalesCustomersController
        public ActionResult Index()
        {
            try
            {
                var result = salesCustomersService.GetSalesCustomers();
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }
                return View(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sales customers.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }

        // GET: SalesCustomersController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = salesCustomersService.GetSalesCustomer(id);
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }
                return View(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sales customer details.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
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
                var result = salesCustomersService.SaveSalesCustomers(customerAdd);
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating sales customer.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }

        // GET: SalesCustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = salesCustomersService.GetSalesCustomer(id);
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }

                var updateCustomers = new UpdateSalesCustomersModel
                {
                    CustId = result.Data.CustId,
                    CompanyName = result.Data.CompanyName,
                    ContactName = result.Data.ContactName,
                    ContactTitle = result.Data.ContactTitle,
                    Address = result.Data.Address,
                    Email = result.Data.Email,
                    City = result.Data.City,
                    Region = result.Data.Region,
                    PostalCode = result.Data.PostalCode,
                    Country = result.Data.Country,
                    Phone = result.Data.Phone,
                    Fax = result.Data.Fax
                };
                return View(updateCustomers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sales customer for edit.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }

        // POST: SalesCustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateSalesCustomersModel updateModel)
        {
            try
            {
                var result = salesCustomersService.UpdateSalesCustomers(updateModel);
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while editing sales customer.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }

        // GET: SalesCustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var result = salesCustomersService.GetSalesCustomer(id);
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }
                return View(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting sales customer for delete.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }

        // POST: SalesCustomersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var removeModel = new RemoveSalesCustomersModel { CustId = id };
                var result = salesCustomersService.RemoveSalesCustomers(removeModel);
                if (!result.Success)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting sales customer.");
                return RedirectToAction("Error", "Home", new { errorMessage = ex.Message });
            }
        }
    }
}