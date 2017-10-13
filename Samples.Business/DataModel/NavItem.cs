using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Samples.Business.DataModel
{
    public class NavItem : Java.Lang.Object
    {
        public String mTitle;
        public String mSubtitle;
        public int mIcon;

        public NavItem(String title, String subtitle, int icon)
        {
            mTitle = title;
            mSubtitle = subtitle;
            mIcon = icon;
        }
    }
}