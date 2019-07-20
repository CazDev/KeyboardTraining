using KeyboardTrainer.Models;
using System.Windows;

public class SilenceMessageBox
{
    public static MessageBoxResult Show(string text, string caption, MessageBoxButton buttons, MessageBoxImage icon)
    {
        MessageBoxResult result;

        if (UserProgressSaver.SoundOn)
        {
            result = MessageBox.Show(text, caption, buttons, icon);
        }
        else
        {
            result = MessageBox.Show(text, caption, buttons, MessageBoxImage.None); // if MessageBoxImage = none, no sound
        }

        return result;
    }
}