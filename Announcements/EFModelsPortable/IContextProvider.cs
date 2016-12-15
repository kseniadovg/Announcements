using EFModels;

namespace EFModels
{
    public interface IContextProvider
    {
        Context GetContext();
    }
}
