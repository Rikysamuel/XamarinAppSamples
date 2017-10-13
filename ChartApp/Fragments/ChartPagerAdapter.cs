using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Samples.Business.DataModel;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace ChartApp.Fragments
{
    public class ChartPagerAdapter : FragmentPagerAdapter
    {
        private List<ChartModel> models;
        public ChartPagerAdapter(FragmentManager fm, List<ChartModel> models) : base(fm)
        {
            this.models = models;
        }

        public override int Count => models.Count;
        public override Fragment GetItem(int position)
        {
            return ChartsFragment.NewInstance(models[position].model);
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(models[position].model);
        }
    }
}