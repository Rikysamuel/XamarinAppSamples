using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Samples.Business.DataModel;
using Object = Java.Lang.Object;

namespace DrawerApp.Activities
{
    [Activity(Label = "DrawerListAdapter")]
    public class DrawerListAdapter : BaseAdapter
    {
        private Context mContext;
        private List<NavItem> mNavItems;

        public DrawerListAdapter(Context context, List<NavItem> navItems)
        {
            mContext = context;
            mNavItems = navItems;
        }

        public override Object GetItem(int position) => mNavItems[position];

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;

            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater) mContext.GetSystemService(Context.LayoutInflaterService);
                view = inflater.Inflate(Resource.Layout.drawer_item, null);
            }
            else
            {
                view = convertView;
            }

            var titleView = (TextView) view.FindViewById(Resource.Id.title);
            var subtitleView = (TextView) view.FindViewById(Resource.Id.subTitle);
            var iconView = (ImageView) view.FindViewById(Resource.Id.icon);

            titleView.Text = mNavItems[position].mTitle;
            subtitleView.Text = mNavItems[position].mSubtitle;
            iconView.SetImageResource(mNavItems[position].mIcon);

            return view;
        }
        public override int Count => mNavItems.Count;
    }
}