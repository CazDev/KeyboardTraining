using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public static class Extentions
{
    public static ImageSource ToImageSource(this Icon icon)
    {
        ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
            icon.Handle,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());

        return imageSource;
    }

    public static string RemoveSpacesFromEnd(this string input)
    {
        string result = input;
        while (true)
        {
            bool IsBroken = false;
            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (result[i] == ' ')
                {
                    result = result.Remove(result.Length - 1);
                    IsBroken = true;
                }
                else
                {
                    break;
                }
            }
            if (!IsBroken)
            {
                break;
            }
        }
        return result;
    }
}
