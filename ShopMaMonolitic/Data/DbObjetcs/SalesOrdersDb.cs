using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs;

public class SalesOrdersDb : ISalesOrdersDb
{
    private readonly ShopContext context;
    public SalesOrdersDb(ShopContext context)
    {
        this.context = context;
    }

    public SalesOrderModel GetSalesOrder(int orderId)
    {
        var GetSalesOrder = this.context.SalesOrders.Find(orderId);

        SalesOrderModel salesOrder = new SalesOrderModel()
        {
            OrderId = GetSalesOrder.orderId,
            OrderDate = GetSalesOrder.OrderDate,
            RequiredDate = GetSalesOrder.RequiredDate,
            ShippedDate = GetSalesOrder.ShippedDate,
            Freight = GetSalesOrder.Freight,
            ShipName = GetSalesOrder.ShipName,
            ShipAddress = GetSalesOrder.ShipAddress,
            ShipCity = GetSalesOrder.ShipCity,
            ShipRegion = GetSalesOrder.ShipRegion,
            ShipPostalCode = GetSalesOrder.ShipPostalCode,
            ShipCountry = GetSalesOrder.ShipCountry
        };
        return salesOrder;
    }

    public List<SalesOrderModel> GetSalesOrders()
    {
        return this.context.SalesOrders.Select(ListSalesOrder =>  new SalesOrderModel()
        {
            OrderId = ListSalesOrder.orderId,
            OrderDate = ListSalesOrder.OrderDate,
            RequiredDate = ListSalesOrder.RequiredDate,
            ShippedDate = ListSalesOrder.ShippedDate,
            Freight = ListSalesOrder.Freight,
            ShipName = ListSalesOrder.ShipName,
            ShipAddress = ListSalesOrder.ShipAddress,
            ShipCity = ListSalesOrder.ShipCity,
            ShipRegion = ListSalesOrder.ShipRegion,
            ShipPostalCode = ListSalesOrder.ShipPostalCode,
            ShipCountry = ListSalesOrder.ShipCountry
        }).ToList();
    }

    public void SaveSalesOrders(SaveSalesOrdersModel saveSalesOrders)
    {
        SalesOrders salesOrders = new SalesOrders()
        {
            OrderId = saveSalesOrders.OrderId,
            custId = saveSalesOrders.CustId,
            empid = saveSalesOrders.EmpId,
            OrderDate = saveSalesOrders.OrderDate,
            RequiredDate = saveSalesOrders.RequiredDate,
            ShippedDate = saveSalesOrders.ShippedDate,
            Freight = saveSalesOrders.Freight,
            ShipName = saveSalesOrders.ShipName,
            ShipAddress = saveSalesOrders.ShipAddress,
            ShipCity = saveSalesOrders.ShipCity,
            ShipRegion = saveSalesOrders.ShipRegion,
            ShipPostalCode = saveSalesOrders.ShipPostalCode,
            ShipCountry = saveSalesOrders.ShipCountry
        };
        this.context.SalesOrders.Add(salesOrders);
        this.context.SaveChanges();
    }

    public void UpdateSalesOrdes(UpdateSalesOrdersModels updateSalesOrdersModels)
    {
        throw new NotImplementedException();
    }
    public void RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel)
    {
        SalesOrders salesOrdersToDelete = this.context.SalesOrders.Find(removeSalesOrdersModel.OrderId);
        if(salesOrdersToDelete is null)
        {
            throw new SalesOrderExeption("Venta no registrada");
        }
        salesOrdersToDelete.OrderId = removeSalesOrdersModel.OrderId;

        this.context.SalesOrders.Update(salesOrdersToDelete);
        this.context.SaveChanges();
    }
}