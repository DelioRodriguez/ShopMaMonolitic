namespace ShopMaMonolitic.Data.Exceptions;

public class SalesOrderExeption : Exception
{
	public SalesOrderExeption(string message) : base(message)
	{
		
	}
    private void LogError(string message)
    {

    }
    private void SendError(string message)
    {

    }
}
