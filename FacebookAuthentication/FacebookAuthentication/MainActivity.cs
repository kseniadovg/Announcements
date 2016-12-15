using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Security;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Object = Java.Lang.Object;
using Services;

namespace FacebookAuthentication
{
    [Activity(Label = "FacebookAuthentication", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IFacebookCallback
    {
        int count = 1;

        private ICallbackManager mCallbackManager;
        private ArrayAdapter<Boom> adapter;

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

            var booms = new Boom[10]; ;
            for (int i = 0; i < 10; i++)
            {
                booms[i] = (new Boom { Name = $"boom{i}" });
            }

            Button buttonGetRecords = FindViewById<Button>(Resource.Id.button1);

            ListView boomsView = FindViewById<ListView>(Resource.Id.listView1);
            adapter = new ArrayAdapter<Boom>(this, Android.Resource.Layout.SimpleListItem1, booms);

            buttonGetRecords.Click += (sender, args) =>
            {
                boomsView.Adapter = adapter;
            };

        }

        class Boom
        {
            public string Name;

            public override string ToString()
            {
                return "Name: " + Name;
            }
        }

        public void OnCancel()
        {

        }

        public void OnError(FacebookException p0)
        {

        }

        public void OnSuccess(Object p0)
        {
            LoginResult result = p0 as LoginResult;
            Console.WriteLine(result.AccessToken.UserId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            mCallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
    }
}

