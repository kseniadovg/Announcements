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
            GetAnnouncements().ForEach(el => context.Announcements.Add(el));

            context.SaveChanges();

            base.Seed(context);
        }        

        List<Announcement> GetAnnouncements()
        {
            byte[] b1 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.house).ConvertTo(Properties.Resources.house, typeof(byte[]));
            byte[] b2 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.vase).ConvertTo(Properties.Resources.vase, typeof(byte[]));
            byte[] b3 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.spaniel).ConvertTo(Properties.Resources.spaniel, typeof(byte[]));
            byte[] b4 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.puppies).ConvertTo(Properties.Resources.puppies, typeof(byte[]));
            byte[] b5 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.kittens).ConvertTo(Properties.Resources.kittens, typeof(byte[]));
            byte[] b6 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.bouquet).ConvertTo(Properties.Resources.bouquet, typeof(byte[]));
            byte[] b7 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.flowerComposition).ConvertTo(Properties.Resources.flowerComposition, typeof(byte[]));
            byte[] b8 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.cupcakes).ConvertTo(Properties.Resources.cupcakes, typeof(byte[]));
            byte[] b9 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.cakeDecorating).ConvertTo(Properties.Resources.cakeDecorating, typeof(byte[]));
            byte[] b10 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.thematicCake).ConvertTo(Properties.Resources.thematicCake, typeof(byte[]));
            byte[] b11 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.stamps).ConvertTo(Properties.Resources.stamps, typeof(byte[]));
            byte[] b12 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.car1).ConvertTo(Properties.Resources.car1, typeof(byte[]));
            byte[] b13 = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(Properties.Resources.parrots).ConvertTo(Properties.Resources.parrots, typeof(byte[]));


            List<Announcement> announcements = new List<Announcement>
            {
                new Announcement { Title = "House Rent offer", Body = "30% discount for first 3 month!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "682a8016-fb04-46c9-92e1-ac5dc5e15d7d", Tags="house;rent", Image=b1 },
                new Announcement { Title = "Vase on sale", Body = "Original vase from 50-ies", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="vase;sale", Image=b2},
                new Announcement { Title = "Dog lost", Body = "Help find Brownie for a fee! A friendly 2-year old spaniel was lost near bus station №1", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", PhoneNumber2="+380736785432", PhoneNumber3="+380673456239", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="dog;pet", Image=b3},
                new Announcement { Title = "Get a friend", Body = "Choose a nice puppy to get a good friend!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="dog;pet;puppy", Image=b4},
                new Announcement { Title = "Take a kitten", Body = "Awesome kittens need home", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="cat;pet;kitten", Image=b5},
                new Announcement { Title = "Exquisite bouquets", Body = "Our bouquets will become an excellent gift", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="flowers;bouquet", Image=b6},
                new Announcement { Title = "Flower compositions", Body = "Original flower compositions for all decoration purposes", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="flowers;decoration", Image=b7},
                new Announcement { Title = "Cupcake world", Body = "A wide variety of beautiful and delicious cupcakes", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="cupcake;baking", Image=b8},
                new Announcement { Title = "Ornate cakes", Body = "Your favourite cakes with rich decoration", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="cake;baking;decoration", Image=b9},
                new Announcement { Title = "Thematic cakes", Body = "We'll create an original cake for your thematic party!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="cake;baking;decoration", Image=b10},
                new Announcement { Title = "Looking for stamps", Body = "Looking for Venice collection stamps", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="stamps;Venice", Image=b11},
                new Announcement { Title = "Raritet car exhibition", Body = "Raritet car exhibition will take place in London, Hyde park,  on 3-4 December, 2016", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="raritet;car;exhibition", Image=b12},
                new Announcement { Title = "Free parrots", Body = "Our parrot couple regulary has nestlings, so all our friends have parrots and now is your turn", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", PhoneNumber2="+380736785432", PhoneNumber3="+380673456239",  CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="raritet;car;exhibition", Image=b13}
            };
            return announcements;
        }
    }
}
