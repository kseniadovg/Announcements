using System.Data.Entity;


namespace EFModels
{
    public class Context : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }

        public Context() : base("AnnouncementsDB")
        {
            Database.SetInitializer(new DbInitializerWithSeed());
        }
    }
}
