namespace ShopMaMonolitic.Data.Core;

public abstract class BaseEntity
{
    /* Este campo se repite en una de mis tablas y en otra tabla que va
     relacionado a mi rama, se le dio a greed esa tabla por que o si no me tocarian 4 tablas*/
    public string CompanyName { set; get; }
}