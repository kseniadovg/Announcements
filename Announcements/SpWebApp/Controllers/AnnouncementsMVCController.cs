using EFModels;
using Facebook;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Services;
using SpWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SpWebApp.Controllers
{
    [Authorize]
    public class AnnouncementsMVCController : Controller
    {
        // GET: AnnouncementsMVC
        public string Index(string what="all")
        {
            ContextProvider contextProvider = new ContextProvider();
            AnnouncementService announcementService = new AnnouncementService(contextProvider, new TagService(contextProvider));
            IEnumerable<Announcement> c = null;
            switch(what.ToLower())
            {
                case "all":
                    {
                        c = announcementService.GetAll(); break;
                    }
                case "my":
                    {
                        FacebookUserModel me = getMe();
                        c = announcementService.GetOwnAnnouncements(me.id);
                        foreach(var announcement in c)
                        {
                            announcement.AuthorPicture = me.picture.data.url;
                        }
                        break;
                    }
                case "friends":
                    {
                        List<FacebookFriendModel> friends = getFriends();
                        List<string> ids = friends.Select(f => f.id).ToList();
                        c = announcementService.GetFriendsAnnouncements(ids);
                        foreach(var announcement in c)
                        {
                            announcement.AuthorPicture = friends.Where(f => f.id == announcement.AuthorId).Select(f => f.picture).FirstOrDefault();
                        }
                        break;
                    }
            }

            var setting = new JsonSerializerSettings
            {
                ContractResolver = new
                              CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(c, Formatting.None, setting);
        }

        FacebookUserModel getMe()
        {
            var access_token = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "FacebookAccessToken").Value;
            var client = new FacebookClient(access_token);
            dynamic fbresult = client.Get("me?fields=id,picture");
            FacebookUserModel facebookUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());

            return facebookUser;
        }

        List<FacebookFriendModel> getFriends()
        {
            var client = new FacebookClient(Session["accessToken"].ToString());
            dynamic fbresult = client.Get("/me/friends");
            var friendsList = new List<FacebookFriendModel>();
            foreach (dynamic friend in fbresult.data)
            {
                friendsList.Add(new FacebookFriendModel()
                {
                    id = friend.id,
                    picture = @"https://graph.facebook.com/" + friend.id + "/picture?type=large"
                });
            }
            return friendsList;
        }

        //// GET: AnnouncementsMVC/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AnnouncementsMVC/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AnnouncementsMVC/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AnnouncementsMVC/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AnnouncementsMVC/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AnnouncementsMVC/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AnnouncementsMVC/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
