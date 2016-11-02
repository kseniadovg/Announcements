﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

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
            byte[] b1 = File.ReadAllBytes("C:\\Users\\odov\\Downloads\\images\\house.jpg");
            byte[] b2 = File.ReadAllBytes("C:\\Users\\odov\\Downloads\\images\\vase.jpg");
            byte[] b3 = File.ReadAllBytes("C:\\Users\\odov\\Downloads\\images\\spaniel.jpg");

            List<Announcement> announcements = new List<Announcement>
            {
                new Announcement { Title = "House Rent special offer", Body = "30% discount for first 3 month!", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "682a8016-fb04-46c9-92e1-ac5dc5e15d7d", Tags="house;rent", Image=b1 },
                new Announcement { Title = "Vase on sale", Body = "Original vase from 50-ies", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="vase;sale", Image=b2},
                new Announcement { Title = "Dog lost", Body = "Help find Brownie for a fee! A friendly 2-year old spaniel was lost near bus station №1", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "137182fa-cafa-424c-b1db-00c07b27547f" , Tags="dog;pet", Image=b3}
            };
            return announcements;
        }
    }
}
