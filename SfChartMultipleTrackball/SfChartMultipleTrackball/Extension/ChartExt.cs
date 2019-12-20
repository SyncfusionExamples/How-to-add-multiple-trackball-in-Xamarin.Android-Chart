using Android.Content;
using Com.Syncfusion.Charts;

namespace SfChartMultipleTrackball
{
    public class ChartExt : SfChart
    {
        // Used to activate the first trackball, if multiple trackballs are placed in the same position.
        internal bool IsTrackballSelected { get; set; } = false;

        public ChartExt(Context context) : base(context)
        {

        }
    }
}
