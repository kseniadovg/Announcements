using EFModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpWebApp.Controllers
{
    public class AnnouncementsController : ApiController
    {
        // GET: api/Announcements
        public IEnumerable<Announcement> Get()
        {
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            var c=announcementService.GetAll();
            return c;
        }

        // GET: api/Announcements/5
        public Announcement Get(int id)
        {
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            return announcementService.GetById(id);
        }

        // POST: api/Announcements
        public void Post([FromBody]Announcement announcement)
        {
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            announcementService.Add(announcement);
        }

        // PUT: api/Announcements/5
        public void Put(int id, [FromBody]Announcement announcement)
        {
            if (id == announcement.Id)
            {
                ContextProvider contextProvider = new ContextProvider();
                AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
                announcementService.Update(announcement);
            }
        }

        // DELETE: api/Announcements/5
        public void Delete(int id)
        {
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            var a = announcementService.GetById(id);
            if (a != null)
            {
                announcementService.Delete(a);
            }
        }
    }
}
