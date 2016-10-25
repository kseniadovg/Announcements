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
            GetAnnouncements().ForEach(el => context.Announcements.Add(el));

            context.SaveChanges();

            base.Seed(context);
        }

        

        List<Announcement> GetAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>
            {
                new Announcement { Title = "House Rent special offer", Body = "30% discount for first 3 month!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user1", Tags="house;rent" },
                new Announcement { Title = "Vase on sale", Body = "Original vase from 50-ies", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user2" , Tags="vase;sale"},
                new Announcement { Title = "Dog lost", Body = "Help find Brownie for a fee! A friendly 2-year old spaniel was lost near bus station №1", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user3" , Tags="dog;pet"}
            };
            return announcements;
        }
    }
}
