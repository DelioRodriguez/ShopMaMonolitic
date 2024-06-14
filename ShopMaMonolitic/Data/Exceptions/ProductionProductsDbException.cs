namespace DefaultNamespace;

public class ProductionProductsDbException : Exception
{
    public ProductionProductsDbException(string message) : base(message)
    {
        
    }

    private void logError(String message)
    {

    }
    private void sendError(String message)
    {
    }

}