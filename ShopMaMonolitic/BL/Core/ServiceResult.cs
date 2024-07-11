namespace ShopMaMonolitic.BL.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        // Clase que maneja los resultados de la operacion del proceso que estamos llamando.
        public bool Success { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}