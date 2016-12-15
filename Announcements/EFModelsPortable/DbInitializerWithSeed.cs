using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFModels
{
    //public class DbInitializerWithSeed : DropCreateDatabaseIfModelChanges<Context>
    public class DbInitializerWithSeed : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            foreach (var announcement in GetAnnouncements())
            {
                context.Announcements.Add(announcement);
            }

            context.SaveChanges();

            base.Seed(context);
        }        

        List<Announcement> GetAnnouncements()
        {

            List<Announcement> announcements = new List<Announcement>
            {
                new Announcement { Title = "House Rent offer", Body = "30% discount for first 3 month!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1223475424393398", Tags="house;rent" },
                new Announcement { Title = "Vase on sale", Body = "Original vase from 50-ies", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1223475424393398" , Tags="vase;sale"},
                new Announcement { Title = "Dog lost", Body = "Help find Brownie for a fee! A friendly 2-year old spaniel was lost near bus station №1", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", PhoneNumber2="+380736785432", PhoneNumber3="+380673456239", CreatedTime = DateTime.UtcNow, AuthorId = "1223475424393398" , Tags="dog;pet"},
                new Announcement { Title = "Get a friend", Body = "Choose a nice puppy to get a good friend!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1223475424393398" , Tags="dog;pet;puppy"},
                new Announcement { Title = "Take a kitten", Body = "Awesome kittens need home", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1223475424393398" , Tags="cat;pet;kitten"},
                new Announcement { Title = "Exquisite bouquets", Body = "Our bouquets will become an excellent gift", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1223475424393398" , Tags="flowers;bouquet"},
                new Announcement { Title = "Flower compositions", Body = "Original flower compositions for all decoration purposes", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="flowers;decoration"},
                new Announcement { Title = "Cupcake world", Body = "A wide variety of beautiful and delicious cupcakes", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="cupcake;baking"},
                new Announcement { Title = "Ornate cakes", Body = "Your favourite cakes with rich decoration", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="cake;baking;decoration"},
                new Announcement { Title = "Thematic cakes", Body = "We'll create an original cake for your thematic party!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="cake;baking;decoration"},
                new Announcement { Title = "Looking for stamps", Body = "Looking for Venice collection stamps", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="stamps;Venice"},
                new Announcement { Title = "Raritet car exhibition", Body = "Raritet car exhibition will take place in London, Hyde park,  on 3-4 December, 2016", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="raritet;car;exhibition"},
                new Announcement { Title = "Free parrots", Body = "Our parrot couple regulary has nestlings, so all our friends have parrots and now is your turn", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", PhoneNumber2="+380736785432", PhoneNumber3="+380673456239",  CreatedTime = DateTime.UtcNow, AuthorId = "1087250668040767" , Tags="raritet;car;exhibition"}
            };
            return announcements;
        }
    }
}
