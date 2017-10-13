using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using ChartApp.Fragments;
using Samples.Business.DataModel;

namespace ChartApp
{
    [Activity(Label = "ChartApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            var chartModels = new List<ChartModel>
            {
                new ChartModel() {model = "Plot"},
                new ChartModel() {model = "Bar"},
                new ChartModel() {model = "Area"}
            };
            var adapter = new ChartPagerAdapter(SupportFragmentManager, chartModels);

            viewPager.Adapter = adapter;
        }
    }
}

