using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModels;
using Services;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextProvider contextProvider = new ContextProvider();
            Context context = contextProvider.GetContext();

            Announcement a = context.Announcements.FirstOrDefault();
            //a.Body = "20% discount for first 3 month!";

            //AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            //announcementService.Update(a);

            //Announcement an = new Announcement { Title = "Take your kitten", Body = "Nice kitten for you", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user3", Tags = "kitten;cat;pet" };
            //announcementService.Add(an);


            //TagService tagService = new TagService(contextProvider);
            //tagService.FillTagsSet();
            //var v = TagsSingletonContainer.Tags;

            //AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            //Announcement an = new Announcement { Title = "Take your kitten", Body = "Nice kitten for you", Email = "user1@ukr.net", PhoneNumber1 = "+380677654325", CreatedTime = DateTime.UtcNow, AuthorId = "user3", Tags = "kitten;cat;pet" };
            //announcementService.Add(an);

            //v = TagsSingletonContainer.Tags;
        }
    }
}
