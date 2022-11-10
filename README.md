# # How to add the multiple trackball in Xamarin.Android chart (SfChart)?

[SfChart](https://help.syncfusion.com/xamarin-android/sfchart/getting-started) allows you add multiple trackballs to a single chart and drag them independently to view the information of different data points at the same time.

The following steps describe how to add multiple trackballs to [SfChart](https://help.syncfusion.com/xamarin-android/sfchart/getting-started).

**Step 1:** Create a custom ChartTrackballBehaviorExt class, which is inherited from [ChartTrackballBehavior](https://help.syncfusion.com/cr/xamarin-android/Com.Syncfusion.Charts.ChartTrackballBehavior.html).
```
public class ChartTrackballBehaviorExt : ChartTrackballBehavior
{
}
```

**Step 2:** Create an instance of ChartTrackballBehaviorExt and add it to the [Behaviors](https://help.syncfusion.com/cr/xamarin-android/Com.Syncfusion.Charts.ChartBase.html#Com_Syncfusion_Charts_ChartBase_Behaviors) collection.
```
ChartTrackballBehaviorExt trackballBehavior1 = new ChartTrackballBehaviorExt();
ChartTrackballBehaviorExt trackballBehavior2 = new ChartTrackballBehaviorExt();
chart.Behaviors.Add(trackballBehavior1);
chart.Behaviors.Add(trackballBehavior2);
```

**Step 3:** Activate the multiple trackballs at load time using the [Show](https://help.syncfusion.com/xamarin-android/sfchart/trackball#show-method) method.
```
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
 
    trackballBehavior1.Show(pointX, pointY);
    trackballBehavior2.Show(pointX, pointY);
}
```

**Step 4:** Set [ActivationMode](https://help.syncfusion.com/xamarin-android/sfchart/trackball#activation-mode) to [None](https://help.syncfusion.com/cr/cref_files/xamarin-android/Syncfusion.SfChart.Android~Com.Syncfusion.Charts.ChartTrackballActivationMode.html) to restrict the default movement of the trackball behavior.
```
trackballBehavior1.ActivationMode = ChartTrackballActivationMode.None;
trackballBehavior2.ActivationMode = ChartTrackballActivationMode.None;
```

**Step 5:** Interact with multiple trackballs by overriding the touch methods of [ChartTrackballBehavior](https://help.syncfusion.com/cr/xamarin-android/Com.Syncfusion.Charts.ChartTrackballBehavior.html) class and the [HitTest](https://help.syncfusion.com/cr/cref_files/xamarin-android/Syncfusion.SfChart.Android~Com.Syncfusion.Charts.ChartTrackballBehavior~HitTest.html) method. The HitTest method is used to find the trackball that is currently activated by user.

```
public class ChartTrackballBehaviorExt : ChartTrackballBehavior
{
    bool isActivated= false;
 
    protected override void OnTouchDown(float pointX, float pointY)
    {
        if (HitTest(pointX, pointY))
        {
            isActivated= true;
            base.OnTouchDown(pointX, pointY);
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
        isActivated= false;
    }
}
```

**Step 6:** Tap and drag each trackball separately to view the data points at different positions simultaneously.

## Output:

![Multiple trackball in Xamarin.Android Chart](https://user-images.githubusercontent.com/53489303/200626390-8a6fd840-4069-4f8a-a35c-7330490bec39.gif)

KB article - [How to add the multiple trackball in Xamarin.Android chart](https://www.syncfusion.com/kb/10840/how-to-add-the-multiple-trackball-in-xamarin-android-charts)

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
