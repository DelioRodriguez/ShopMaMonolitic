using ShopMaMonolitic.BL.Core;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.Data.Interfaces;
using ShopMaMonolitic.Data.Models;

namespace ShopMaMonolitic.BL.Services;

public class SalesCustomersServices : ISalesCustomersServices
{
    private readonly ISalesCustomersDb salesCustomersDb;
    private readonly ILogger<SalesCustomersServices> logger;

    public SalesCustomersServices(ISalesCustomersDb salesCustomersDb, ILogger<SalesCustomersServices> logger)
    {
        this.salesCustomersDb = salesCustomersDb;
        this.logger = logger;
    }
    private List<string> ValidateSalesCustomers(dynamic salesCustomer)
    {
        var errors = new List<string>();
        
        if (string.IsNullOrEmpty(salesCustomer.CompanyName))
        {
            errors.Add("El nombre de la compañia es requerido");
        }
        else if (salesCustomer.CompanyName.Length > 40)
        {
            errors.Add("El nombre de la compañia no puede ser mayor a 40 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.ContactName))
        {
            errors.Add("El nombre de contacto es invalido.");
        }
        else if (salesCustomer.ContactName.Length > 30)
        {
            errors.Add("El nombre de contacto no puede ser mayor a 30 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.ContactTitle))
        {
            errors.Add("El título de contacto es invalido.");
        }
        else if (salesCustomer.ContactTitle.Length > 30)
        {
            errors.Add("El título de contacto no puede ser mayor a 30 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.Address))
        {
            errors.Add("La direccion es invalida.");
        }
        else if (salesCustomer.Address.Length > 60)
        {
            errors.Add("La direccin no puede ser mayor a 60 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.Email))
        {
            errors.Add("El email es inválido.");
        }
        else if (salesCustomer.Email.Length > 50)
        {
            errors.Add("El email no puede ser mayor a 50 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.City))
        {
            errors.Add("La ciudad es invalida.");
        }
        else if (salesCustomer.City.Length > 15)
        {
            errors.Add("La ciudad no puede ser mayor a 15 caracteres");
        }

        if (salesCustomer.Region.Length > 15)
        {
            errors.Add("La region no puede ser mayor a 15 caracteres");
        }

        if (salesCustomer.PostalCode.Length > 10)
        {
            errors.Add("El codigo postal no puede ser mayor a 10 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.Country))
        {
            errors.Add("El país es invalido.");
        }
        else if (salesCustomer.Country.Length > 15)
        {
            errors.Add("El pais no puede ser mayor a 15 caracteres");
        }

        if (string.IsNullOrEmpty(salesCustomer.Phone))
        {
            errors.Add("El telefono es invalido");
        }
        else if (salesCustomer.Phone.Length > 24)
        {
            errors.Add("El telefono no puede ser mayor a 24 caracteres");
        }

        if (salesCustomer.Fax.Length > 24)
        {
            errors.Add("El fax no puede ser mayor a 24 caracteres");
        }
        return errors;
        }

    public ServiceResult GetSalesCustomers()
    {
        ServiceResult result = new ServiceResult();
        try
        {
            result.Data = salesCustomersDb.GetSalesCustomers();
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error obteniendo los Customers";
            this.logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }

    public ServiceResult GetSalesCustomer(int Id)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            result.Data = this.salesCustomersDb.GetSalesCustomer(Id);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error obteniendo los Customers";
            this.logger.LogError(result.Message,ex.ToString());
        }
        return result;
    }

    public ServiceResult SaveSalesCustomers(SaveSalesCustomersModel saveSalesCustomers)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            var validationErrors = ValidateSalesCustomers(saveSalesCustomers);
            if (validationErrors.Count > 0)
            {
                result.Success = false;
                result.Message = string.Join("; ", validationErrors);
                return result;
            }
            salesCustomersDb.SaveSalesCustomers(saveSalesCustomers);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error guardando los datos.";
            this.logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }

    public ServiceResult UpdateSalesCustomers(UpdateSalesCustomersModel updatesalesCustomers)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            if (updatesalesCustomers is null)
            {
                result.Success = false;
                result.Message = "El Cliente de venta o customer no puede ser nulo.";
                return result;
            }

            var validationErrors = ValidateSalesCustomers(updatesalesCustomers);
            if (validationErrors.Count > 0)
            {
                result.Success = false;
                result.Message = string.Join("; ", validationErrors);
                return result;
            }

            salesCustomersDb.UpdateSalesCustomers(updatesalesCustomers);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error actualizadno los datos.";
            this.logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }

    public ServiceResult RemoveSalesCustomers(RemoveSalesCustomersModel removeSalesCustomers)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            if (removeSalesCustomers is null)
            {
                result.Success = false;
                result.Message = "El cliente de venta o customer no puede ser nulo.";
                return result;
            }
            this.salesCustomersDb.RemoveSalesCustomers(removeSalesCustomers);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrio un error removiendo los datos";
            this.logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }
    }