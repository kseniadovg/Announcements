using System.Data.Entity;


namespace EFModels
{
    public class Context : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public Context() : base("AnnouncementsDB")
        {
            Database.SetInitializer(new DbInitializerWithSeed());
        }
    }
}
