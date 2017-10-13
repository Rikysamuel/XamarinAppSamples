using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace DrawerApp.Fragments
{
    public class PreferencesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_preferences, container, false);
            var txtView = (TextView) view.FindViewById(Resource.Id.fragment_text);
            txtView.Text = Arguments.GetString("Details");
            return view;
        }
    }
}