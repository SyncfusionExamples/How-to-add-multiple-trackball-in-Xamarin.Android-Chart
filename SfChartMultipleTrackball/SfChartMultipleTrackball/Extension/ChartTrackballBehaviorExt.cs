using Com.Syncfusion.Charts;

namespace SfChartMultipleTrackball
{
    public class ChartTrackballBehaviorExt : ChartTrackballBehavior
    {
        bool isActivated = false;

        protected override void OnTouchDown(float pointX, float pointY)
        {
            var chart = (Chart as ChartExt);
            if (!chart.IsTrackballSelected)
            {
                if (HitTest(pointX, pointY))
                {
                    isActivated = true;
                    base.OnTouchDown(pointX, pointY);
                    chart.IsTrackballSelected = true;
                }
            }
        }

        protected override void OnTouchMove(float pointX, float pointY)
        {
            if (isActivated)
            {
                Show(pointX, pointY);
                base.OnTouchMove(pointX, pointY);
            }
        }

        protected override void OnTouchUp(float pointX, float pointY)
        {
            isActivated = false;
            (Chart as ChartExt).IsTrackballSelected = false;
        }
    }  
}