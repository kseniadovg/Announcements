using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Facebook;
using Java.IO;
using Java.Security;
using Newtonsoft.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Object = Java.Lang.Object;

namespace FacebookAuthentication
{
    [Activity(Label = "FacebookAuthentication", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IFacebookCallback
    {
        int count = 1;

        private ICallbackManager mCallbackManager;
        private AnnouncemenAdapter adapter;
        private bool isLoggedIn;
        private FacebookClient fb;
        private List<Announcement> announcements;
        private List<FacebookFriendModel> friendsList = new List<FacebookFriendModel>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FacebookSdk.SdkInitialize(this.ApplicationContext);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            LoginButton button = FindViewById<LoginButton>(Resource.Id.login_button);

            button.SetReadPermissions("user_friends");
            mCallbackManager = CallbackManagerFactory.Create();

            button.RegisterCallback(mCallbackManager, this);

            announcements = new List<Announcement>(); ;


            Button buttonGetRecords = FindViewById<Button>(Resource.Id.button1);


            Button buttonGetRecord2 = FindViewById<Button>(Resource.Id.button2);

            ListView boomsView = FindViewById<ListView>(Resource.Id.listView1);


            buttonGetRecords.Click += (sender, args) =>
            {

                    for (int i = 0; i < 5; i++)
                    {
                        announcements.Add(new Announcement
                        {
                            UserPost = $"boom{i}",
                            UserIcon = GetImageBitmapFromUrl(friendsList[0].picture),
                            PostedPicture = Resources.GetDrawable(Resource.Drawable.parrots)
                        });
                    }

                    adapter = new AnnouncemenAdapter(this, announcements);
                    boomsView.Adapter = adapter;

            };
            buttonGetRecord2.Click += (sender, args) =>
            {
                GetUserFrinds();
            };

        }

        public void OnCancel()
        {

        }

        public void OnError(FacebookException p0)
        {

        }

        public void OnSuccess(Object p0)
        {
            isLoggedIn = true;
            LoginResult result = p0 as LoginResult;
            announcements.Add(new Announcement() { UserPost = result.AccessToken.Permissions.ToList()[0] });
            fb = new FacebookClient(result.AccessToken.Token);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            mCallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }

        private void GetUserFrinds()
        {
            var query = string.Format("SELECT uid,name,pic_square FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1={0}) ORDER BY name ASC", "me()");

            if (isLoggedIn)
            {

                fb.GetTaskAsync("/me/friends").ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {


                        JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(t.Result.ToString());
                        friendsList = JsonConvert.DeserializeObject<List<FacebookFriendModel>>(jsonObject["data"].ToString());

                        for (int i = 0; i < friendsList.Count; i++)
                        {
                            friendsList[i].picture = @"https://graph.facebook.com/" + friendsList[i].id +
                                                     "/picture?type=normal";
                        }
                        RunOnUiThread(() =>
                        {
                            Alert("Info", "You have " + friendsList.Count + " friend(s).", false, (res) => { });
                        });
                    }
                });
            }
            else
            {
                Alert("Not Logged In", "Please Log In First", false, (res) => { });
            }
        }
        public void Alert(string title, string message, bool CancelButton, Action<Result> callback)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle(title);
            builder.SetIcon(Android.Resource.Drawable.IcLockIdleAlarm);
            builder.SetMessage(message);

            builder.SetPositiveButton("Ok", (sender, e) =>
            {
                callback(Result.Ok);
            });

            if (CancelButton)
            {
                builder.SetNegativeButton("Cancel", (sender, e) =>
                {
                    callback(Result.Canceled);
                });
            }

            builder.Show();
        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}

