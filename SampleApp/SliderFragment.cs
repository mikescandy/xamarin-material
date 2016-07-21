using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Com.Rey.Material.Widget;

namespace SampleApp
{
    public class SliderFragment : Fragment
    {
        private TextView tv_continuous;
        private TextView tv_discrete;

        public static SliderFragment newInstance()
        {
            var fragment = new SliderFragment();
            return fragment;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_slider, container, false);

            var sl_continuous = v.FindViewById<Slider>(Resource.Id.slider_sl_continuous);
            tv_continuous = v.FindViewById<TextView>(Resource.Id.slider_tv_continuous);
            tv_continuous.Text = $"pos={sl_continuous.Position} value={sl_continuous.Value}";
            sl_continuous.SetOnPositionChangeListener(new SliderPositionChangedListener(tv_continuous));

            var sl_discrete = v.FindViewById<Slider>(Resource.Id.slider_sl_discrete);
            tv_discrete = v.FindViewById<TextView>(Resource.Id.slider_tv_discrete);
            tv_discrete.Text = $"pos={sl_discrete.Position} value={sl_discrete.Value}";
            sl_discrete.SetOnPositionChangeListener(new SliderPositionChangedListener(tv_discrete));

            return v;
        }
    }
}