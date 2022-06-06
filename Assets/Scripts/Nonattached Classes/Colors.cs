using UnityEngine; 

public class Colors
{
    public float roadColorChangeRate; 

    static private readonly int[] copRed = { 237, 35, 13 };
    static private readonly int[] copBlue = { 2, 118, 186 };
    static private readonly int[] electricTangerine = { 255, 147, 0 };
    static private readonly int[] electricYellow = { 255, 218, 51 };
    static private readonly int[] electricBlue = { 0, 161, 255 };
    static private readonly int[] electricDarkBlue = { 0, 83, 147 };
    static private readonly int[] slowMotionClover = { 0, 143, 0 };
    static private readonly int[] skyBlue = { 0, 215, 255 };
    static private readonly int[] batteryEndRed = { 148, 17, 0 };


    static private float startingRoadColor = 213;

    static public Color rgbToColor(int[] rgb)
    {
        float a = rgb[0] / 255.0f;
        float b = rgb[1] / 255.0f;
        float c = rgb[2] / 255.0f;

        return new Color(a, b, c);
    }

    static public Color rgbToColor(float colorValue)
    {
        float nColorValue = colorValue / 255;
        return new Color(nColorValue, nColorValue, nColorValue);
    }

    static public Color makeAlphaZero(Color color)
    {
        return new Color(color.r, color.g, color.b, 0); 
    }

    static public Color makeAlphaOne(Color color)
    {
        return new Color(color.r, color.g, color.b, 1);
    }

    static public Color CopRed
    {
        get { return rgbToColor(copRed);  }
    }

    static public Color CopBlue
    {
        get { return rgbToColor(copBlue); }
    }

    static public Color ElectricTangerine
    {
        get { return rgbToColor(electricTangerine); }
    }

    static public Color ElectricYellow
    {
        get { return rgbToColor(electricYellow); }
    }

    static public Color ElectricBlue
    {
        get { return rgbToColor(electricBlue); }
    }

    static public Color ElectricDarkBlue
    {
        get { return rgbToColor(electricDarkBlue); }
    }

    static public Color SlowMotionClover
    {
        get { return rgbToColor(slowMotionClover); }
    }

    static public Color SkyBlue
    {
        get { return rgbToColor(skyBlue); }
    }

    static public Color BatteryEndRed
    {
        get { return rgbToColor(batteryEndRed); }
    }

    static public float StartingRoadColor
    {
        get { return startingRoadColor;  }
    }

    static public Color carColor(float roadColor)
    {
        if (roadColor >= 106.5)
        {
            return new Color(0, 0, 0);
        }
        else
        {
            return new Color(1, 1, 1);
        }
    }
}
