using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Com.Rey.Material.Widget;
using Button = Android.Widget.Button;

namespace SampleApp
{
    [Activity(Label = "SampleApp", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/Theme.AppTheme")]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var slider = FindViewById<Slider>(Resource.Id.slider_sl_discrete);
            
            //slider.SetValueRange(1,9,true);
            
        }
    }
}