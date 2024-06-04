namespace DefaultNamespace;

public class SuppliersDbException : Exception
{
    public SuppliersDbException(string message) : base(message)
    {
        
    }

    private void logError(String message)
    {

    }
    private void sendError(String message)
    {
    }
}