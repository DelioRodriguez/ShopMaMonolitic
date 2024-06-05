using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;
using System.Net;

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
       SalesOrders salesOrdersToUpdate = this.context.SalesOrders.Find(updateSalesOrdersModels.OrderId);

        if(salesOrdersToUpdate is null) 
        {
            throw new SalesOrderExeption("Orden no existente.");
        }
        salesOrdersToUpdate.OrderId = updateSalesOrdersModels.OrderId;
        salesOrdersToUpdate.custId = updateSalesOrdersModels.CustId;
        salesOrdersToUpdate.empid = updateSalesOrdersModels.EmpId;
        salesOrdersToUpdate.OrderDate = updateSalesOrdersModels.OrderDate;
        salesOrdersToUpdate.RequiredDate = updateSalesOrdersModels.RequiredDate;
        salesOrdersToUpdate.ShippedDate = updateSalesOrdersModels.ShippedDate;
        salesOrdersToUpdate.shipperId = updateSalesOrdersModels.ShipperId;
        salesOrdersToUpdate.Freight = updateSalesOrdersModels.Freight;
        salesOrdersToUpdate.ShipName = updateSalesOrdersModels.ShipName;
        salesOrdersToUpdate.ShipAddress = updateSalesOrdersModels.ShipAddress;
        salesOrdersToUpdate.ShipCity = updateSalesOrdersModels.ShipCity;
        salesOrdersToUpdate.ShipRegion = updateSalesOrdersModels.ShipRegion;
        salesOrdersToUpdate.ShipPostalCode = updateSalesOrdersModels.ShipPostalCode;
        salesOrdersToUpdate.ShipCountry = updateSalesOrdersModels.ShipCountry;

        this.context.SalesOrders.Update(salesOrdersToUpdate);
        this.context.SaveChanges();
    }

    public void RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel)
    {
        SalesOrders salesOrdersToDelete = this.context.SalesOrders.Find(removeSalesOrdersModel.OrderId);
        if(salesOrdersToDelete is null)
        {
            throw new SalesOrderExeption("Orden no existente.");
        }
        salesOrdersToDelete.OrderId = removeSalesOrdersModel.OrderId;

        this.context.SalesOrders.Update(salesOrdersToDelete);
        this.context.SaveChanges();
    }
}