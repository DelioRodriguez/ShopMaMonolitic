using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
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
    private SalesOrders ValidateOrderExists(int orderId)
    {
        var order = context.SalesOrders.Find(orderId);
        if (order is null) throw new SalesOrdersServicesExeption("Orden no existente.");
        // Casos 
        return order;
    }

    private static SalesOrderModel MapToModel(SalesOrders entity)
    {
        return new SalesOrderModel
        {
            OrderId = entity.OrderId,
            CustId = entity.CustId,
            EmpId = entity.EmpId,
            OrderDate = entity.OrderDate,
            RequiredDate = entity.RequiredDate,
            ShippedDate = entity.ShippedDate,
            ShipperId = entity.ShipperId,
            Freight = entity.Freight,
            ShipName = entity.ShipName,
            ShipAddress = entity.ShipAddress,
            ShipCity = entity.ShipCity,
            ShipRegion = entity.ShipRegion,
            ShipPostalCode = entity.ShipPostalCode,
            ShipCountry = entity.ShipCountry
        };
    }

    private SalesOrders MapToEntity(SaveSalesOrdersModel model)
    {
        var entity = new SalesOrders();
        entity.OrderId = model.OrderId;
        entity.CustId = model.CustId;
        entity.EmpId = model.EmpId;
        entity.OrderDate = model.OrderDate;
        entity.RequiredDate = model.RequiredDate;
        entity.ShippedDate = model.ShippedDate;
        entity.ShipperId = model.ShipperId;
        entity.Freight = model.Freight;
        entity.ShipName = model.ShipName;
        entity.ShipAddress = model.ShipAddress;
        entity.ShipCity = model.ShipCity;
        entity.ShipRegion = model.ShipRegion;
        entity.ShipPostalCode = model.ShipPostalCode;
        entity.ShipCountry = model.ShipCountry;
        return entity;
    }

    private void MapToEntity(UpdateSalesOrdersModels model, SalesOrders entity)
    {
        entity.OrderId = model.OrderId;
        entity.CustId = model.CustId;
        entity.EmpId = model.EmpId;
        entity.OrderDate = model.OrderDate;
        entity.RequiredDate = model.RequiredDate;
        entity.ShippedDate = model.ShippedDate;
        entity.ShipperId = model.ShipperId;
        entity.Freight = model.Freight;
        entity.ShipName = model.ShipName;
        entity.ShipAddress = model.ShipAddress;
        entity.ShipCity = model.ShipCity;
        entity.ShipRegion = model.ShipRegion;
        entity.ShipPostalCode = model.ShipPostalCode;
        entity.ShipCountry = model.ShipCountry;
    }

    public SalesOrderModel GetSalesOrder(int OrderId)
    {
        var order = ValidateOrderExists(OrderId);
        return MapToModel(order);
    }

    public List<SalesOrderModel> GetSalesOrders()
    {
        return context.SalesOrders.Select(orders => MapToModel(orders)).ToList();
    }

    public void SaveSalesOrders(SaveSalesOrdersModel saveSalesOrders)
    {
        if (saveSalesOrders == null) throw new SalesCustomerServicesExeption("Order no exist");
        // Casos de ingresion de datos
        if (saveSalesOrders.ShipName.Length > 40) throw new SalesCustomerServicesExeption("Logitud Invalida");

        var order = MapToEntity(saveSalesOrders);
        context.SalesOrders.Add(order);
        context.SaveChanges();
    }

    public void UpdateSalesOrdes(UpdateSalesOrdersModels updateSalesOrdersModels)
    {
        var order = ValidateOrderExists(updateSalesOrdersModels.OrderId);

        if (updateSalesOrdersModels == null) throw new SalesOrdersServicesExeption("");
        // Casos 
        if (updateSalesOrdersModels.ShipName.Length > 40) throw new SalesCustomerServicesExeption("Logitud Invalida");

        MapToEntity(updateSalesOrdersModels, order);
        context.SalesOrders.Update(order);
        context.SaveChanges();
    }

    public void RemoveSalesOrders(RemoveSalesOrdersModel removeSalesOrdersModel)
    {
        var order = ValidateOrderExists(removeSalesOrdersModel.OrderId);
        context.SalesOrders.Remove(order);
        context.SaveChanges();
    }
}