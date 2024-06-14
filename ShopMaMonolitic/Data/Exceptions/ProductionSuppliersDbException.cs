namespace DefaultNamespace;

public class ProductionSuppliersDbException : Exception
{
    public ProductionSuppliersDbException(string message) : base(message)
    {
        
    }

    private void logError(String message)
    {

    }
    private void sendError(String message)
    {
    }
}