using EFModels;
using Facebook;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace SpWebApp.Controllers
{
    [Authorize]
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

        [Route("api/MyAnnouncements")]
        public IEnumerable<Announcement> GetMyAnnouncements()
        {
            /*var identity = HttpContext.GetOwinContext().Authentication.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);*///null
            //var identity = HttpContext.Session["fbuser"];
            //var access_token = identity.FindFirstValue("FacebookAccessToken");
            //var fb = new FacebookClient(access_token);
            //dynamic myInfo = fb.Get("/me?fields=email");

            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()); //null
            //var user = User.Identity;
            //var facebookClient = new FacebookClient(FacebookAccessToken);
            //var me = facebookClient.Get("me") as JsonObject;
            //var uid = me["id"];

            var v = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name);

            string id = "1087250668040767";
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            return announcementService.GetOwnAnnouncements(id);
        }

        [Route("api/MyFriendsAnnouncements")]
        public IEnumerable<Announcement> GetFriendsAnnouncements()
        {
            string id = "";
            List<string> ids = null;
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            return announcementService.GetFriendsAnnouncements(ids);
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
