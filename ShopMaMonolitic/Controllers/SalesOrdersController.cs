using Microsoft.AspNetCore.Mvc;
using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Controllers;

public class SalesOrdersController : Controller
{
    private readonly ISalesOrdersDb salesOrdersService;

    public SalesOrdersController(ISalesOrdersDb salesOrdersDb)
    {
        salesOrdersService = salesOrdersDb;
    }

    // GET: SalesOrderController
    public ActionResult Index()
    {
        var salesOrders = salesOrdersService.GetSalesOrders();
        return View(salesOrders);
    }

    // GET: SalesOrderController/Details/5
    public ActionResult Details(int id)
    {
        var order = salesOrdersService.GetSalesOrder(id);
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
        try
        {
            orderAdd.OrderDate = DateTime.Now;
            salesOrdersService.SaveSalesOrders(orderAdd);
            return RedirectToAction(nameof(Index));
        }
        catch (SalesOrdersServicesExeption exp)
        {
            Console.WriteLine(exp.Message);
            return View();
        }
    }

    // GET: SalesOrderController/Edit/5
    public ActionResult Edit(int id)
    {
        var order = salesOrdersService.GetSalesOrder(id);
        var updateOrders = new UpdateSalesOrdersModels
        {
            OrderId = order.OrderId,
            CustId = order.CustId,
            EmpId = order.EmpId,
            OrderDate = order.OrderDate,
            RequiredDate = order.RequiredDate,
            ShippedDate = order.ShippedDate,
            ShipperId = order.ShipperId,
            Freight = order.Freight,
            ShipName = order.ShipName,
            ShipAddress = order.ShipAddress,
            ShipCity = order.ShipCity,
            ShipRegion = order.ShipRegion,
            ShipPostalCode = order.ShipPostalCode,
            ShipCountry = order.ShipCountry
        };
        return View(updateOrders);
    }

    // POST: SalesOrderController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UpdateSalesOrdersModels updateModel)
    {
        try
        {
            salesOrdersService.UpdateSalesOrdes(updateModel);
            return RedirectToAction(nameof(Index));
        }
        catch (SalesOrdersServicesExeption ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }

    // GET: SalesOrderController/Delete/5
    public ActionResult Delete(int id)
    {
        var order = salesOrdersService.GetSalesOrder(id);
        return View(order);
    }

    // POST: SalesOrderController/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            var removeModel = new RemoveSalesOrdersModel { OrderId = id };
            salesOrdersService.RemoveSalesOrders(removeModel);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            var order = salesOrdersService.GetSalesOrder(id);
            return View(order);
        }
    }
}