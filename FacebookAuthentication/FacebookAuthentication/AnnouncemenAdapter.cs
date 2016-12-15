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
    public class AnnouncemenAdapter:BaseAdapter<Announcement>
    {
        public List<Announcement> mItems;
        private Context mContext;

        public AnnouncemenAdapter(Context context,List<Announcement> items)
        {
            mContext = context;
            mItems = items;
        }
         
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.announcement_item, null, false);
            }

            ImageView imgPost = row.FindViewById<ImageView>(Resource.Id.PostedImage);
            imgPost.SetImageDrawable(mItems[position].PostedPicture);


            ImageView imgUser = row.FindViewById<ImageView>(Resource.Id.UserIcon);
            imgUser.SetImageBitmap(mItems[position].UserIcon);

            TextView txtPost = row.FindViewById<TextView>(Resource.Id.UserPost);
            txtPost.Text = mItems[position].UserPost;

            return row;
        }

        public override int Count => mItems.Count;

        public override Announcement this[int position]
        {
            get { return mItems[position]; }
        }
    }
}