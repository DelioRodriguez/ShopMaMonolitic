using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
using ShopMaMonolitic.Data.Exceptions;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.Data.DbObjetcs;

public class SalesOrderDetailsDb : ISalesOrderDetailsDb
{
    private readonly ShopContext context;
    public SalesOrderDetailsDb(ShopContext context)
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

    private SalesOrderDetailsModel MapToModel(SalesOrderDetails entity)
    {
        return new SalesOrderDetailsModel
        {
            OrderId = entity.orderId,
            Discount = entity.Discount,
            ProductId = entity.productId,
            UnitPrice = entity.unitPrice,
            Qty = entity.Qty
        };
    }

    private void MapToEntity(SaveSalesOrderDetailsModel model, SalesOrderDetails entity)
    {
        entity.orderId = model.OrderId;
        entity.productId = model.ProductId;
        entity.unitPrice = model.UnitPrice;
        entity.Qty = model.Qty;
        entity.Discount = model.Discount;
    }

    private void MapToEntity(UpdateSalesOrderDetailsModel model, SalesOrderDetails entity)
    {
        entity.unitPrice = model.UnitPrice;
        entity.Qty = model.Qty;
        entity.Discount = model.Discount;
    }

    public SalesOrderDetailsModel GetSalesOrderDetails(int orderId)
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