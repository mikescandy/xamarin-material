//using Android.App;
//using Android.Content;
//using Android.Graphics;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Android.OS;
//using Android.Support.V4.App;
//using Android.Support.V4.View;
//using Android.Support.V4.Widget;
//using Android.Support.V7.App;
//using Com.Rey.Material.App;
//using Com.Rey.Material.Util;
//using Com.Rey.Material.Widget;
//using Java.Lang;
//using ActionBar = Android.Support.V7.App.ActionBar;
//using Button = Android.Widget.Button;
//using Exception = System.Exception;
//using Fragment = Android.App.Fragment;
//using FragmentManager = Android.App.FragmentManager;
//using FrameLayout = Android.Widget.FrameLayout;
//using ListView = Android.Widget.ListView;
//using Object = System.Object;
//using TextView = Com.Rey.Material.Widget.TextView;

//namespace SampleApp
//{
//    public static class Tab
//    {
//        public static string PROGRESS = "progress";
//        public static string BUTTONS = "buttons";
//        public static string FAB = "fab";
//        public static string SWITCHES = "switches";
//        public static string SLIDERS = "sliders";
//        public static string SPINNERS = "spinners";
//        public static string TEXTFIELDS = "textfields";
//        public static string SNACKBARS = "snackbars";
//        public static string DIALOGS = "dialogs";

//    }

//    [Activity(Label = "SampleApp", MainLauncher = true, Icon = "@drawable/icon")]
//    public class MainActivity : AppCompatActivity, ToolbarManager.IOnToolbarGroupChangedListener
//    {
//        private static string[] mItems = new string[] { Tab.PROGRESS, Tab.BUTTONS, Tab.FAB, Tab.SWITCHES, Tab.SLIDERS, Tab.SPINNERS, Tab.TEXTFIELDS, Tab.SNACKBARS, Tab.DIALOGS }; int count = 1;
//        private DrawerLayout dl_navigator;
//        private FrameLayout fl_drawer;
//        private ListView lv_drawer;
//        private CustomViewPager vp;
//        private TabIndicatorView tiv;

//        private DrawerAdapter mDrawerAdapter;
//        private PagerAdapter mPagerAdapter;

//        private Toolbar mToolbar;
//        private ToolbarManager mToolbarManager;
//        private SnackBar mSnackBar;
//        protected override void OnCreate(Bundle bundle)
//        {
//            base.OnCreate(bundle);

//            // Set our view from the "main" layout resource
//            SetContentView(Resource.Layout.activity_main);

//            // Get our button from the layout resource,
//            // and attach an event to it
//            Button button = FindViewById<Button>(Resource.Id.MyButton);

//            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
//        }

//        public void OnToolbarGroupChanged(int p0, int p1)
//        {
//            mToolbarManager.NotifyNavigationStateChanged();
//        }


//        class DrawerAdapter : BaseAdapter, View.IOnClickListener, ThemeManager.IOnThemeChangedListener
//        {


//            private string mSelectedTab;
//            private int mTextColorLight;
//            private int mTextColorDark;
//            private int mBackgroundColorLight;
//            private int mBackgroundColorDark;
//            Context context;
//            public DrawerAdapter(Context context)
//            {
//                mTextColorLight = context.Resources.GetColor(Resource.Color.abc_primary_text_material_light);
//                mTextColorDark = context.Resources.GetColor(Resource.Color.abc_primary_text_material_dark);
//                mBackgroundColorLight = ThemeUtil.ColorPrimary(context, 0);
//                mBackgroundColorDark = ThemeUtil.ColorAccent(context, 0);
//                this.context = context;
//                ThemeManager.Instance.RegisterOnThemeChangedListener(this);
//            }
//            public override Java.Lang.Object GetItem(int position)
//            {
//                return mItems[position];
//            }

//            public override long GetItemId(int position)
//            {
//                return 0;
//            }

//            public override View GetView(int position, View convertView, ViewGroup parent)
//            {
//                View v = convertView;
//                if (v == null)
//                {
//                    v = LayoutInflater.From(context).Inflate(Resource.Layout.row_drawer, null);
//                    v.SetOnClickListener(this);
//                }

//                v.Tag = position;
//                var tab = (string)GetItem(position);
//                ((TextView)v).Text = tab;

//                if (tab == (string)mSelectedTab)
//                {
//                    v.SetBackgroundColor(ThemeManager.Instance.CurrentTheme == 0 ? context.Resources.GetColor(mBackgroundColorLight) : context.Resources.GetColor(mBackgroundColorDark));
//                    ((TextView)v).SetTextColor(Color.ParseColor("0xFFFFFFFF"));
//                }
//                else
//                {
//                    v.SetBackgroundResource(0);
//                    ((TextView)v).SetTextColor(ThemeManager.Instance.CurrentTheme == 0 ? context.Resources.GetColor(mTextColorLight) : context.Resources.GetColor(mTextColorDark));
//                }

//                return v;
//            }

//            public override int Count { get { return mItems.Length; } }
//            public void OnClick(View v)
//            {
//                var position = (int)v.Tag;
//                vp.SetCurrentItem(position);
//                dl_navigator.CloseDrawer(fl_drawer);
//            }

//            public void OnThemeChanged(ThemeManager.OnThemeChangedEvent p0)
//            {
//                NotifyDataSetInvalidated();
//            }

//            public void setSelected(string tab)
//            {
//                if (tab != mSelectedTab)
//                {
//                    mSelectedTab = tab;
//                    NotifyDataSetInvalidated();
//                }
//            }

//            public string getSelectedTab()
//            {
//                return mSelectedTab;
//            }

//        }

//        private class PagerAdapter : FragmentStatePagerAdapter
//        {

//            Fragment[] mFragments;
//            string[] mTabs;


//            private static Field sActiveField;
        
//        static {
//            Field f = null;
//            try {
//                Class<?> c = Class.forName("android.support.v4.app.FragmentManagerImpl");
//            f = c.getDeclaredField("mActive");
//                f.setAccessible(true);   
//            } catch (Exception e) {}

//    sActiveField = f;
//        }

//public PagerAdapter(FragmentManager fm, Tab[] tabs)
//{
//    super(fm);
//    mTabs = tabs;
//    mFragments = new Fragment[mTabs.length];


//    //dirty way to get reference of cached fragment
//    try
//    {
//        ArrayList<Fragment> mActive = (ArrayList<Fragment>)sActiveField.get(fm);
//        if (mActive != null)
//        {
//            for (Fragment fragment : mActive)
//            {
//                if (fragment instanceof ProgressFragment)
//                            setFragment(Tab.PROGRESS, fragment);
//                        else if (fragment instanceof ButtonFragment)
//                            setFragment(Tab.BUTTONS, fragment);
//                        else if (fragment instanceof FabFragment)
//                            setFragment(Tab.FAB, fragment);
//                        else if (fragment instanceof SwitchesFragment)
//                            setFragment(Tab.SWITCHES, fragment);
//                        else if (fragment instanceof SliderFragment)
//                            setFragment(Tab.SLIDERS, fragment);
//                        else if (fragment instanceof SpinnersFragment)
//                            setFragment(Tab.SPINNERS, fragment);
//                        else if (fragment instanceof TextfieldFragment)
//                            setFragment(Tab.TEXTFIELDS, fragment);
//                        else if (fragment instanceof SnackbarFragment)
//                            setFragment(Tab.SNACKBARS, fragment);
//                        else if (fragment instanceof DialogsFragment)
//                            setFragment(Tab.DIALOGS, fragment);
//        }
//    }

//            }
//            catch(Exception e){}
//        }
        
//        private void setFragment(Tab tab, Fragment f)
//{
//    for (int i = 0; i < mTabs.length; i++)
//        if (mTabs[i] == tab)
//        {
//            mFragments[i] = f;
//            break;
//        }
//}

//@Override
//        public Fragment getItem(int position)
//{
//    if (mFragments[position] == null)
//    {
//        switch (mTabs[position])
//        {
//            case PROGRESS:
//                mFragments[position] = ProgressFragment.newInstance();
//                break;
//            case BUTTONS:
//                mFragments[position] = ButtonFragment.newInstance();
//                break;
//            case FAB:
//                mFragments[position] = FabFragment.newInstance();
//                break;
//            case SWITCHES:
//                mFragments[position] = SwitchesFragment.newInstance();
//                break;
//            case SLIDERS:
//                mFragments[position] = SliderFragment.newInstance();
//                break;
//            case SPINNERS:
//                mFragments[position] = SpinnersFragment.newInstance();
//                break;
//            case TEXTFIELDS:
//                mFragments[position] = TextfieldFragment.newInstance();
//                break;
//            case SNACKBARS:
//                mFragments[position] = SnackbarFragment.newInstance();
//                break;
//            case DIALOGS:
//                mFragments[position] = DialogsFragment.newInstance();
//                break;
//        }
//    }

//    return mFragments[position];
//}

//@Override
//        public CharSequence getPageTitle(int position)
//{
//    return mTabs[position].toString().toUpperCase();
//}

//@Override
//        public int getCount()
//{
//    return mFragments.length;
//}
//    }
//}

//}