namespace ShopMaMonolitic.Data.Exceptions;

public class ProductionCategoriesDbException : Exception
{
    public ProductionCategoriesDbException(string message) : base(message)
    {
    
    }
    private void logError(String message)
    {

    }
    private void sendError(String message)
    {
    }
}