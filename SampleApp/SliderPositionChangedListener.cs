using Com.Rey.Material.Widget;
using Java.Lang;

namespace SampleApp
{
    public class SliderPositionChangedListener : Object, Slider.IOnPositionChangeListener
    {
        private TextView _target;

        public SliderPositionChangedListener(TextView target)
        {
            _target = target;
        }

        public void OnPositionChanged(Slider p0, bool p1, float p2, float p3, int p4, int p5)
        {
            _target.Text = $"pos={p3} value={p5}";
        }
    }
}