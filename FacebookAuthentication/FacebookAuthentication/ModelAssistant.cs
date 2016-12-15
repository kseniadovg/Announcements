using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FacebookAuthentication
{
    public class ModelAssistant
    {
        public static void SetImageViewWithByteArray(ImageView view, byte[] data)
        {
            Bitmap bitmap = BitmapFactory.DecodeByteArray(data, 0, data.Length);
            view.SetImageBitmap(bitmap);
        }
    }
}