using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class SilenceMessageBox
{
    public static MessageBoxResult Show(string text, string caption, MessageBoxButton buttons, MessageBoxImage icon)
    {
        MessageBoxResult result;

        result = MessageBox.Show(text, caption, buttons, MessageBoxImage.None);

        return result;
    }
}