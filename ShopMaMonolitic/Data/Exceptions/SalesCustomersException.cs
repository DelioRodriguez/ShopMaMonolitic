namespace ShopMaMonolitic.Data.Exceptions;

public class SalesCustomersException : Exception
{
    public SalesCustomersException(string message) : base(message)
    {
    }

    private void LogError(string message)
    {
    }

    private void SendError(string message)
    {
    }
}