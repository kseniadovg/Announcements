using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FacebookAuthentication
{
    public class Announcement
    {
        public Drawable PostedPicture { get; set; }
        public Bitmap UserIcon { get; set; }
        public string UserPost { get; set; }
    }
}