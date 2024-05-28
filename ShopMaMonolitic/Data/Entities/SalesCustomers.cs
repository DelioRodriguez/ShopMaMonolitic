using System;

public class SalesCustomers : BaseEntity
{
    public string companyName { set; get; }
    public string contactName { set; get; }
    public string contactTtitle { set; get; }
    public string addess { set; get; }
    public string email { set; get; }
    public string city { set; get; }
    public string region { set; get; }
    public string postalCode { set; get; }
    public string country { set; get; }
    public string phone { set; get; }
    public string fax { set; get; }
}
public SalesCustomers(int orderID, string companyName, string contactTtitle, string addess, string email, string city, string region, string postalCode, string country, string phone, string fax) : base (orderID) 
	{
        
	}
}
