using EFModels;

namespace RepositoryAndUow
{
    public interface IContextProvider
    {
        Context GetContext();
    }
}
