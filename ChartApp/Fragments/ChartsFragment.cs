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
using OxyPlot.Xamarin.Android;
using Samples.Business.Manager;
using Samples.Business.Utils;

namespace ChartApp.Fragments
{
    public class ChartsFragment : Android.Support.V4.App.Fragment
    {
        public static ChartsFragment NewInstance(String model)
        {
            var fragment = new ChartsFragment();

            var args = new Bundle();
            args.PutString(Util.PLOT_MODEL, model);
            fragment.Arguments = args;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.chart_layout, container, false);
            var plotView = view.FindViewById<PlotView>(Resource.Id.plot_view);
            var model = Arguments.GetString(Util.PLOT_MODEL);
            Console.WriteLine("the model is: " + model);
            switch (model)
            {
                case "Plot":
                    plotView.Model = ChartManager.GetInstance().CreatePlotModel();
                    break;
                case "Bar":
                    plotView.Model = ChartManager.GetInstance().CreateBarModel(true);
                    break;
                case "Area":
                    plotView.Model = ChartManager.GetInstance().CreateAreaModel();
                    break;
                default:
                    break;
            }

            return view;
        }
    }
}