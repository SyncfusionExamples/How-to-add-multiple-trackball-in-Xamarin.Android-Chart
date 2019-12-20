using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Java.Util;
using System;
using System.Threading.Tasks;

namespace SfChartMultipleTrackball
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ChartTrackballBehaviorExt trackballBehavior1, trackballBehavior2;
        ChartExt chart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TrackballViewModel trackballViewModel = new TrackballViewModel();

            chart = new ChartExt(this);
            chart.Title.Text = "Average sales for person";
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            DateTimeAxis primaryAxis = new DateTimeAxis();
            primaryAxis.Title.Text = "Year";
            primaryAxis.PlotOffset = 5;
            primaryAxis.AxisLineOffset = 5;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.Interval = 1;
            primaryAxis.IntervalType = DateTimeIntervalType.Years;
            primaryAxis.LineStyle.StrokeWidth = 1;
            primaryAxis.LineStyle.StrokeColor = Color.ParseColor("#404041");
            primaryAxis.LabelStyle.LabelFormat = "yyyy";
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Revenue";
            secondaryAxis.Minimum = 10;
            secondaryAxis.Maximum = 80;
            secondaryAxis.Interval = 10;
            secondaryAxis.MajorTickStyle.StrokeWidth = 0;
            secondaryAxis.LineStyle.StrokeWidth = 0;
            chart.SecondaryAxis = secondaryAxis;
            TrackballViewModel viewModel = new TrackballViewModel();
            
            LineSeries series = new LineSeries();
            series.ItemsSource = viewModel.LineSeries1;
            series.XBindingPath = "Date";
            series.YBindingPath = "Value";
            series.LegendIcon = ChartLegendIcon.Circle;
            series.DataMarker.ShowMarker = true;
            series.DataMarker.MarkerColor = Color.White;
            series.DataMarker.ShowLabel = false;
            series.DataMarker.MarkerStrokeWidth = 2;
            series.DataMarker.MarkerStrokeColor = Color.ParseColor("#00BDAE");
            series.DataMarker.MarkerHeight = 6;
            series.DataMarker.MarkerWidth = 6;

            LineSeries series1 = new LineSeries();
            series1.ItemsSource = viewModel.LineSeries2;
            series1.XBindingPath = "Date";
            series1.YBindingPath = "Value";
            series1.LegendIcon = ChartLegendIcon.Circle;
            series1.DataMarker.ShowMarker = true;
            series1.DataMarker.MarkerColor = Color.White;
            series1.DataMarker.ShowLabel = false;
            series1.DataMarker.MarkerStrokeWidth = 2;
            series1.DataMarker.MarkerStrokeColor = Color.ParseColor("#404041");
            series1.DataMarker.MarkerHeight = 6;
            series1.DataMarker.MarkerWidth = 6;
            
            chart.Series.Add(series);
            chart.Series.Add(series1);

            trackballBehavior1 = new ChartTrackballBehaviorExt();
            trackballBehavior1.LineStyle.StrokeWidth = 3;
            trackballBehavior1.ActivationMode = ChartTrackballActivationMode.None;
            chart.Behaviors.Add(trackballBehavior1);

            trackballBehavior2 = new ChartTrackballBehaviorExt();
            trackballBehavior2.LineStyle.StrokeWidth = 3;
            trackballBehavior2.ActivationMode = ChartTrackballActivationMode.None;
            chart.Behaviors.Add(trackballBehavior2);
            
            SetContentView(chart);
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            
            Task.Run(async () =>
            {
                await ShowTrackball();
            });
        }

        async Task ShowTrackball()
        {
            Task.Delay(1000).Wait();

            trackballBehavior1.Show(chart.ValueToPoint(chart.PrimaryAxis, new DateTime(2000, 9, 14).ToOADate()), chart.ValueToPoint(chart.SecondaryAxis, 55));
            trackballBehavior2.Show(chart.ValueToPoint(chart.PrimaryAxis, new DateTime(2005, 2, 11).ToOADate()), chart.ValueToPoint(chart.SecondaryAxis, 60));
        }
    }
}