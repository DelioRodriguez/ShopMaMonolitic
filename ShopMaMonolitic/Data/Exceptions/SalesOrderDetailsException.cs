namespace ShopMaMonolitic.Data.Exceptions;

public class SalesOrderDetailsException : Exception
{
	public SalesOrderDetailsException(string message) : base(message)
	{
	}
    private void LogError(string message)
    {

    }
    private void SendError(string message)
    {

    }
}
