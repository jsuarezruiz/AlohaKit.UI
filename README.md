# AlohaKit UI

This library offers an **easier way to create drawn controls** in .NET MAUI in both XAML and C#.

It includes a new **CanvasView** control that allows content such as drawn Layouts or Views so that it creates a single native view that creates the native Canvas but the rest of the child elements become fully drawn and managed by the Canvas.

XAML

```
<alohakit:CanvasView>
    <alohakit:Rectangle
        WidthRequest="50" HeightRequest="50" 
        X="30" Y="30" 
        ScaleX="0.5" ScaleY="0.5"
        Fill="Green" />
    <alohakit:RoundRectangle
        WidthRequest="50" HeightRequest="50" 
        X="120" Y="10" 
        CornerRadius="12, 0, 0, 24"
        Fill="Orange" />
    <alohakit:Ellipse
        WidthRequest="50" HeightRequest="50" 
        X="130" Y="70">
        <alohakit:Ellipse.Fill>
            <LinearGradientBrush StartPoint="0, 0" EndPoint="1, 0">
                <LinearGradientBrush.GradientStops>
                    <GradientStop Color="Red" />
                    <GradientStop Color="Yellow" Offset="1" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </alohakit:Ellipse.Fill>
    </alohakit:Ellipse>
</alohakit:CanvasView>

```
C#

```
CanvasView()
    .Children({
        Rectangle()
            .X(10).Y(10)
            .Height(80).Width(80)
            .Fill(Colors.Red),
        Ellipse() 
            .X(10).Y(100)
            .Height(80).Width(80)
            .Fill(Colors.Orange),
        Label()
            .X(10).Y(200)
            .Height(20).Width(100)
            .Text("Label"),
    });
```

This way, instead of needing to use the .NET MAUI Graphics Canvas extension methods, you use XAML or C# in a similar way to how you would normally create UI in .NET MAUI.
