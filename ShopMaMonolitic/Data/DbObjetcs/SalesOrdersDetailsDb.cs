using ShopMaMonolitic.BL.Exceptions;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.Entities;
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
        var orderDetails = context.SalesOrderDetails.Find(orderId);
        if (orderDetails == null) throw new SalesOrderDetailsServicesExeption("Orden no existente.");
        //Casos

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

    private SalesOrderDetails MapToEntity(SaveSalesOrderDetailsModel model)
    {
        var entity = new SalesOrderDetails();
        entity.OrderId = model.OrderId;
        entity.ProductId = model.ProductId;
        entity.UnitPrice = model.UnitPrice;
        entity.Qty = model.Qty;
        entity.Discount = model.Discount;
        return entity;
    }

    private void MapToEntity(UpdateSalesOrderDetailsModel model, SalesOrderDetails entity)
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
        return context.SalesOrderDetails.Select(OrderDetails => MapToModel(OrderDetails)).ToList();
    }

    public void SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetails)
    {
        if (saveSalesOrderDetails == null) throw new SalesOrderDetailsServicesExeption("Order no exists");
        // Casos para los campos

        var orderDetails = MapToEntity(saveSalesOrderDetails);
        context.SalesOrderDetails.Add(orderDetails);
        context.SaveChanges();
    }

    public void UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel)
    {
        // Revisar estas linea con esto valido y el prof me trabajo eso (No le dije que tenia un metodo para validad).
        var orderDetails = ValidateOrderDetailsExists(updateSalesOrderDetailsModel.OrderId);
        MapToEntity(updateSalesOrderDetailsModel, orderDetails);
        context.SalesOrderDetails.Update(orderDetails);
        context.SaveChanges();
    }

    public void RemoveSalesOrderDetails(RemoveSalesOrderDetailsModel removeSalesOrderDetailsModel)
    {
        var orderDetails = ValidateOrderDetailsExists(removeSalesOrderDetailsModel.OrderId);
        context.SalesOrderDetails.Remove(orderDetails);
        context.SaveChanges();
    }
}