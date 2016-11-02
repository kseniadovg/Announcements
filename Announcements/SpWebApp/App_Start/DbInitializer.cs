using EFModels;
using System.Data.Entity;

namespace SpWebApp
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DbInitializerWithSeed());
            Context context = new ContextProvider().GetContext();
            context.Database.Initialize(true);
        }
    }
}