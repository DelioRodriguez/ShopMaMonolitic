using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs;

public class SalesOrdersDetailsDb : ISalesOrderDetailsDb
{
    private readonly ShopContext context;
    public SalesOrdersDetailsDb(ShopContext context)
    {
        this.context = context;
    }

    private SalesOrderDetails ValidateOrderDetailsExists(int orderId)
    {
        var orderDetails = this.context.SalesOrderDetails.Find(orderId);
        if (orderDetails is null)
        {
            throw new SalesOrderDetailsException("Orden no existente.");
        }
        return orderDetails;
    }

    private static SalesOrderDetailsModel MapToModel(SalesOrderDetails entity)
    {
        return new SalesOrderDetailsModel
        {
            OrderId = entity.OrderId,
            Discount = entity.Discount,
            ProductId = entity.ProductId,
            UnitPrice = entity.UnitPrice,
            Qty = entity.Qty
        };
    }

    private static void MapToEntity(SaveSalesOrderDetailsModel model, SalesOrderDetails entity)
    {
        entity.OrderId = model.OrderId;
        entity.ProductId = model.ProductId;
        entity.UnitPrice = model.UnitPrice;
        entity.Qty = model.Qty;
        entity.Discount = model.Discount;
    }

    private static void MapToEntity(UpdateSalesOrderDetailsModel model, SalesOrderDetails entity)
    {
        entity.OrderId = model.OrderId;
        entity.ProductId = model.ProductId;
        entity.UnitPrice = model.UnitPrice;
        entity.Qty = model.Qty;
        entity.Discount = model.Discount;
    }

    public SalesOrderDetailsModel GetSalesOrderDetail(int orderId)
    {
        var orderDetails = ValidateOrderDetailsExists(orderId);
        return MapToModel(orderDetails);
    }

    public List<SalesOrderDetailsModel> GetSalesOrderDetails()
    {
        return this.context.SalesOrderDetails.Select(OrderDetails  => MapToModel(OrderDetails)).ToList();
    }

    public void SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetails)
    {
       SalesOrderDetails OrderDetails = new SalesOrderDetails();
        MapToEntity(saveSalesOrderDetails, OrderDetails);
        this.context.SalesOrderDetails.Add(OrderDetails);
        this.context.SaveChanges();
    }

    public void UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel)
    {
        var orderDetails = ValidateOrderDetailsExists(updateSalesOrderDetailsModel.OrderId);
        MapToEntity(updateSalesOrderDetailsModel, orderDetails);
        this.context.SalesOrderDetails.Update(orderDetails);
        this.context.SaveChanges();
    }

    public void RemoveSalesOrderDetails(RemoveSalesOrderDetailsModel removeSalesOrderDetails)
    {
        var orderDetails = ValidateOrderDetailsExists(removeSalesOrderDetails.OrderID);
        this.context.SalesOrderDetails.Remove(orderDetails);
        this.context.SaveChanges(); 
    }
}