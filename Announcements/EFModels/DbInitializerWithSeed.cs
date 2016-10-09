using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels
{
    public class DbInitializerWithSeed : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            GetCategories().ForEach(el => context.Categories.Add(el));
            GetTags().ForEach(el => context.Tags.Add(el));
            context.SaveChanges();
            GetAnnouncements(context).ForEach(el => context.Announcements.Add(el));

            context.SaveChanges();

            base.Seed(context);
        }

        List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>
            {
                new Category { Name = "Other" },
                new Category { Name = "House Rent" },
                new Category { Name = "Looking for" },
                new Category { Name = "On Sale" }
            };

            return categories;
        }

        List<Tag> GetTags()
        {
            List<Tag> tags = new List<Tag>
            {
                new Tag { Name = "house" },
                new Tag { Name = "pet" },
                new Tag { Name = "dog" },
                new Tag { Name = "vase" }
            };

            return tags;
        }

        List<Announcement> GetAnnouncements(Context context)
        {
            List<Announcement> announcements = new List<Announcement>
            {
                new Announcement { Title = "House Rent special offer", Body = "30% discount for first 3 month!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user1" },
                new Announcement { Title = "Vase on sale", Body = "Original vase from 50-ies", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user2" },
                new Announcement { Title = "Dog lost", Body = "Help find Brownie for a fee! A friendly 2-year old spaniel was lost near bus station №1", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user3" }
            };

            announcements[0].Category = context.Categories.FirstOrDefault(c => c.Name == "House Rent");
            announcements[1].Category = context.Categories.FirstOrDefault(c => c.Name == "On Sale");
            announcements[2].Category = context.Categories.FirstOrDefault(c => c.Name == "Looking for");

            announcements[0].Tags.Add(context.Tags.FirstOrDefault(t => t.Name == "house"));
            announcements[1].Tags.Add(context.Tags.FirstOrDefault(t => t.Name == "vase"));
            announcements[2].Tags.Add(context.Tags.FirstOrDefault(t => t.Name == "dog"));
            announcements[2].Tags.Add(context.Tags.FirstOrDefault(t => t.Name == "pet"));

            return announcements;
        }
    }
}
