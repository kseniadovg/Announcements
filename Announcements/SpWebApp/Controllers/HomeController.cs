using System.Web.Mvc;

namespace SpWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {  
                   
            return View();
        }

        public ActionResult MyAnnouncements()
        {
            return View();
        }

        public ActionResult FriendsAnnouncements()
        {
            return View();
        }
    }

            //var v = User.Identity.Name;//working
            //var v1 = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name);//working    

    //var client = new FacebookClient(Session["accessToken"].ToString());
    //dynamic fbresult = client.Get("me?fields=id,email,first_name,last_name,gender,locale,link,timezone,location,picture");
    //FacebookUserModel facebookUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());

    //public class FacebookUserModel
    //{
    //    public string id { get; set; }
    //    public string email { get; set; }
    //    public string first_name { get; set; }
    //    public string last_name { get; set; }
    //    public string gender { get; set; }
    //    public string locale { get; set; }
    //    public string link { get; set; }
    //    public string username { get; set; }
    //    public int timezone { get; set; }
    //    public Picture picture { get; set; }
    //}
    //public class Picture
    //{
    //    public PicureData data { get; set; }
    //}

    //public class PicureData
    //{
    //    public string url { get; set; }
    //    public bool is_silhouette { get; set; }
    //}
}
