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

    public void DeleteSalesOrderDetails()
    {
        throw new NotImplementedException();
    }

    public SalesOrderDetailsModel GetSalesOrderDetails(int orderId)
    {
        var GetSalesOrderDetails = this.context.SalesOrderDetails.Find(orderId);

        SalesOrderDetailsModel salesOrderDetailsModel = new SalesOrderDetailsModel()
        {
            OrderId = GetSalesOrderDetails.orderId,
            Discount = GetSalesOrderDetails.Discount,
            ProductId = GetSalesOrderDetails.productId,
            UnitPrice = GetSalesOrderDetails.unitPrice,
            Qty = (short)GetSalesOrderDetails.Qty
        };
        return salesOrderDetailsModel;
    }

    public List<SalesOrderDetailsModel> GetSalesOrderDetails()
    {
        return this.context.SalesOrderDetails.Select(ListSalesOrderDetails => new SalesOrderDetailsModel()
        {
            OrderId = ListSalesOrderDetails.orderId,
            Discount = ListSalesOrderDetails.Discount,
            ProductId = ListSalesOrderDetails.productId,
            UnitPrice = ListSalesOrderDetails.unitPrice,
            Qty = (short)ListSalesOrderDetails.Qty
        }).ToList();
    }

    public void SaveSalesOrderDetails(SaveSalesOrderDetailsModel saveSalesOrderDetails)
    {
        SalesOrderDetails salesOrderDetails = new SalesOrderDetails()
        {
            orderId = saveSalesOrderDetails.OrderId,
            productId = saveSalesOrderDetails.ProductId,
            unitPrice = saveSalesOrderDetails.UnitPrice,
            Qty = saveSalesOrderDetails.Qty,
            Discount = saveSalesOrderDetails.Discount
        };
        this.context.SalesOrderDetails.Add(salesOrderDetails);
        this.context.SaveChanges();
    }

    public void UpdateSalesOrderDetails(UpdateSalesOrderDetailsModel updateSalesOrderDetailsModel)
    {
        SalesOrderDetails salesOrderDetailsToUpdate = this.context.SalesOrderDetails.Find(updateSalesOrderDetailsModel.OrderID);
        if (salesOrderDetailsToUpdate is null ) 
        {
            throw new SalesOrderDetailsException("Orden no existente.");
        }
        salesOrderDetailsToUpdate.unitPrice = updateSalesOrderDetailsModel.UnitPrice;
        salesOrderDetailsToUpdate.Qty = updateSalesOrderDetailsModel.Qty;
        salesOrderDetailsToUpdate.Discount = updateSalesOrderDetailsModel.Discount;

        this.context.SalesOrderDetails.Update(salesOrderDetailsToUpdate);
        this.context.SaveChanges();
    }

    public void RemoveSalesOrderDetails(RemoveSalesOrderDetailsModel removeSalesOrderDetails)
    {
        SalesOrderDetails salesOrderDetailsToDelete = this.context.SalesOrderDetails.Find(removeSalesOrderDetails.OrderID);

        if (salesOrderDetailsToDelete is null)
        {
            throw new SalesCustomersException("La orden existe");
        }
        salesOrderDetailsToDelete.orderId = removeSalesOrderDetails.OrderID;

        this.context.SalesOrderDetails.Update(salesOrderDetailsToDelete);
        this.context.SaveChanges();
    }
}