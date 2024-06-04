namespace ShopMaMonolitic.Data.Exceptions;

public class CategoriesDbException : Exception
{
    public CategoriesDbException(string message) : base(message)
    {
    
    }
    private void logError(String message)
    {

    }
    private void sendError(String message)
    {
    }
}