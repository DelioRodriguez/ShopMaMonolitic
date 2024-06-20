using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.BL.Services;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers;

public class SalesOrderDetailsController : Controller
{
    private readonly ISalesOrderDetailsDb salesOrderDetailsService;

    public SalesOrderDetailsController(ISalesOrderDetailsDb salesOrderDetailsDb)
    {
        salesOrderDetailsService = salesOrderDetailsDb;
    }

    // GET: SalesOrderDetailsController
    public ActionResult Index()
    {
        var orderDetails = salesOrderDetailsService.GetSalesOrderDetails();
        return View(orderDetails);
    }

    // GET: SalesOrderDetailsController/Details/5
    public ActionResult Details(int id)
    {
        var ordersDetails = salesOrderDetailsService.GetSalesOrderDetail(id);
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
        try
        {
            salesOrderDetailsService.SaveSalesOrderDetails(addModel);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View(addModel);
        }
    }

    // GET: SalesOrderDetailsController/Edit/5
    public ActionResult Edit(int id)
    {
        var orderDetails = salesOrderDetailsService.GetSalesOrderDetail(id);
        var updateOrderDetails = new UpdateSalesOrderDetailsModel
        {
            OrderId = orderDetails.OrderId,
            ProductId = orderDetails.ProductId,
            UnitPrice = orderDetails.UnitPrice,
            Qty = orderDetails.Qty,
            Discount = orderDetails.Discount
        };
        return View(updateOrderDetails);
    }

    // POST: SalesOrderDetailsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UpdateSalesOrderDetailsModel updateModel)
    {
        try
        {
            salesOrderDetailsService.UpdateSalesOrderDetails(updateModel);
            return RedirectToAction(nameof(Index));
        }
        catch (SalesOrderDetailsServicesExeption exp)
        {
            Console.WriteLine(exp.Message);
            return View();
        }
    }

    // GET: SalesOrderDetailsController/Delete/5
    public ActionResult Delete(int id)
    {
        var detaildelete = salesOrderDetailsService.GetSalesOrderDetail(id);
        return View(detaildelete);
    }

    // POST: SalesOrderDetailsController/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
        try
        {
            var removeModel = new RemoveSalesOrderDetailsModel { OrderId = id };
            salesOrderDetailsService.RemoveSalesOrderDetails(removeModel);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            var detail = salesOrderDetailsService.GetSalesOrderDetail(id);
            return View(detail);
        }
    }
}