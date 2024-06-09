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

    private SalesOrders ValidateOrderExists(int orderId)
    {
        var order = this.context.SalesOrders.Find(orderId);
        if (order is  null)
        {
            throw new SalesOrderExeption("Orden no existente.");
        }
        return order;
    }

    private SalesOrderModel MapToModel(SalesOrders entity)
    {
        return new SalesOrderModel
        {
            OrderId = entity.OrderId,
            OrderDate = entity.OrderDate,
            RequiredDate = entity.RequiredDate,
            ShippedDate = entity.ShippedDate,
            Freight = entity.Freight,
            ShipName = entity.ShipName,
            ShipAddress = entity.ShipAddress,
            ShipCity = entity.ShipCity,
            ShipRegion = entity.ShipRegion,
            ShipPostalCode = entity.ShipPostalCode,
            ShipCountry = entity.ShipCountry
        };
    }

    private void MapToEntity(SaveSalesOrdersModel model, SalesOrders entity)
    {
        entity.custId = model.CustId;
        entity.empId = model.EmpId;
        entity.OrderDate = DateTime.Now;
        entity.RequiredDate = model.RequiredDate;
        entity.ShippedDate = model.ShippedDate;
        entity.shipperId = model.ShipperId;
        entity.Freight = model.Freight;
        entity.ShipName = model.ShipName;
        entity.ShipAddress = model.ShipAddress;
        entity.ShipCity = model.ShipCity;
        entity.ShipRegion = model.ShipRegion;
        entity.ShipPostalCode = model.ShipPostalCode;
        entity.ShipCountry = model.ShipCountry;
    }

    private void MapToEntity(UpdateSalesOrdersModels model, SalesOrders entity) 
    {
        entity.custId = model.CustId;
        entity.empId = model.EmpId;
        entity.OrderDate = model.OrderDate;
        entity.RequiredDate = model.RequiredDate;
        entity.ShippedDate = model.ShippedDate;
        entity.shipperId = model.ShipperId;
        entity.Freight = model.Freight;
        entity.ShipName = model.ShipName;
        entity.ShipAddress = model.ShipAddress;
        entity.ShipCity = model.ShipCity;
        entity.ShipRegion = model.ShipRegion;
        entity.ShipPostalCode = model.ShipPostalCode;
        entity.ShipCountry = model.ShipCountry;
    }

    public SalesOrderModel GetSalesOrder(int orderId)
    {
        var order = ValidateOrderExists(orderId);
        return MapToModel(order);
    }

    public List<SalesOrderModel> GetSalesOrders()
    {
        return this.context.SalesOrders.Select(orders => MapToModel(orders)).ToList();
    }

    public void SaveSalesOrders(SaveSalesOrdersModel saveSalesOrders)
    {
        var order = new SalesOrders();
        MapToEntity(saveSalesOrders, order);
        this.context.SalesOrders.Add(order);
        this.context.SaveChanges();
    }

    public void UpdateSalesOrdes(UpdateSalesOrdersModels updateSalesOrdersModels)
    {
        var order = ValidateOrderExists(updateSalesOrdersModels.OrderId);
        MapToEntity(updateSalesOrdersModels, order);
        this.context.SalesOrders.Update(order);
        this.context.SaveChanges();
    }

    public void RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel)
    {
        var order = ValidateOrderExists(removeSalesOrdersModel.OrderId);
        this.context.SalesOrders.Remove(order); 
        this.context.SaveChanges();
    }
}