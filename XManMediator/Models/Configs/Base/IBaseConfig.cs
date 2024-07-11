namespace XManMediator.Models.Configs.Base
{
    public interface IBaseConfig
    {
        IBaseConfig RegisterFromAssemblyContaining<T>();
    }
}
