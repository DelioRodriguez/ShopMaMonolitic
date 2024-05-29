namespace ShopMaMonolitic.Data.Entities;

public class SecurityUser
{
    public int userID { get; set; }
    public string email { get; set; }
    public string password { set; get; }
    public string name { set; get; }
}