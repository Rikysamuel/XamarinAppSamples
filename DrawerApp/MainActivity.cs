using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using DrawerApp.Activities;
using DrawerApp.Fragments;
using Samples.Business.DataModel;

namespace DrawerApp
{
    [Activity(Label = "DrawerApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity, AdapterView.IOnItemClickListener
    {
        private static string TAG = typeof(MainActivity).Name;

        ListView mDrawerList;
        RelativeLayout mDrawerPane;
        private ActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;

        List<NavItem> mNavItems = new List<NavItem>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mNavItems.Add(new NavItem("Home", "Meetup destination", Resource.Drawable.Icon));
            mNavItems.Add(new NavItem("Preferences", "Change your preferences", Resource.Drawable.Icon));
            mNavItems.Add(new NavItem("About", "Get to know about us", Resource.Drawable.Icon));

            mDrawerLayout = (DrawerLayout) FindViewById(Resource.Id.drawerLayout);

            // Populate the Navigtion Drawer with options
            mDrawerPane = (RelativeLayout) FindViewById(Resource.Id.drawerPane);
            mDrawerList = (ListView) FindViewById(Resource.Id.navList);
            DrawerListAdapter adapter = new DrawerListAdapter(this, mNavItems);
            mDrawerList.Adapter = adapter;
            mDrawerList.OnItemClickListener = this;
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            selectItemFromDrawer(position);
        }

        private void selectItemFromDrawer(int position)
        {
            var bundle = new Bundle();
            bundle.PutString("Details", mNavItems[position].mTitle);

            Fragment fragment = new PreferencesFragment();
            fragment.Arguments = bundle;

            var fragmentManager = FragmentManager.BeginTransaction();
            fragmentManager.Replace(Resource.Id.mainContent, fragment);
            fragmentManager.Commit();

            mDrawerList.SetItemChecked(position, true);
            this.Title = mNavItems[position].mTitle;

            // Close the drawer
            mDrawerLayout.CloseDrawer(mDrawerPane);
        }
    }
}

