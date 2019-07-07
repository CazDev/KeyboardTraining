using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KeyboardTrainer.Models
{
    public static class ThemeChanger
    {
        public static void ChangeTheme(this Window window, Panel panel, MTheme theme)
        {
            if (theme == MTheme.DARK)
            {
                panel.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            }
            else if (theme == MTheme.LIGHT)
            {
                panel.Background = new SolidColorBrush(Color.FromRgb(250, 250, 250));
            }
            else if (theme == MTheme.RED)
            {
                panel.Background = new SolidColorBrush(Color.FromRgb(15, 15, 15));
            }
            else if (theme == MTheme.GREEN)
            {
                panel.Background = new SolidColorBrush(Color.FromRgb(10, 10, 10));
            }

            var allElements = GetAllControls(panel);

            foreach (object element in allElements)
            {

                if ((element is Button))
                {
                    if (theme == MTheme.DARK)
                    {
                        ChangeControlTheme(element as Button, Color.FromRgb(29, 29, 29), Color.FromRgb(96, 60, 186), Color.FromRgb(255, 255, 255));
                    }
                    else if (theme == MTheme.LIGHT)
                    {
                        ChangeControlTheme(element as Button, Color.FromRgb(128, 215, 255), Color.FromRgb(0, 171, 169), Color.FromRgb(29, 29, 29));
                    }
                    else if (theme == MTheme.RED)
                    {
                        ChangeControlTheme(element as Button, Color.FromRgb(144, 45, 40), Color.FromRgb(100, 42, 40), Color.FromRgb(207, 205, 206));
                    }
                    else if(theme == MTheme.GREEN)
                    {
                        ChangeControlTheme(element as Button, Color.FromRgb(0, 75, 64), Color.FromRgb(56, 253, 57), Color.FromRgb(255, 255, 255));
                    }
                }
                else if ((element is TextBlock))
                {
                    if (theme == MTheme.DARK)
                    {
                        ChangeControlTheme(element as TextBlock, Color.FromRgb(128, 128, 128), Color.FromRgb(0, 0, 0));
                    }
                    else if (theme == MTheme.LIGHT)
                    {
                        ChangeControlTheme(element as TextBlock, Color.FromRgb(250, 250, 250), Color.FromRgb(29, 29, 29));
                    }
                    else if (theme == MTheme.RED)
                    {
                        ChangeControlTheme(element as TextBlock, Color.FromRgb(15, 15, 15), Color.FromRgb(207, 205, 206));
                    }
                    else if (theme == MTheme.GREEN)
                    {
                        ChangeControlTheme(element as TextBlock, Color.FromRgb(10, 10, 10), Color.FromRgb(255, 255, 255));
                    }
                }
                else if (element is Label)
                {
                    if (theme == MTheme.DARK)
                    {
                        ChangeControlTheme(element as Label, Color.FromRgb(0, 0, 0));
                    }
                    else if (theme == MTheme.LIGHT)
                    {
                        ChangeControlTheme(element as Label, Color.FromRgb(29, 29, 29));
                    }
                    else if (theme == MTheme.RED)
                    {
                        ChangeControlTheme(element as Label, Color.FromRgb(207, 205, 206));
                    }
                    else if (theme == MTheme.GREEN)
                    {
                        ChangeControlTheme(element as Label, Color.FromRgb(255, 255, 255));
                    }
                }
            }
        }

        static void ChangeControlTheme(Button control, Color background, Color mouseEnter, Color fontColor)
        {
            control.Background = new SolidColorBrush(background);
            control.MouseEnter += (s, e) => control.Background = new SolidColorBrush(mouseEnter);
            control.MouseLeave += (s, e) => control.Background = new SolidColorBrush(background);

            control.Foreground = new SolidColorBrush(fontColor);
        }

        static void ChangeControlTheme(TextBlock control, Color background, Color fontColor)
        {
            control.Background = new SolidColorBrush(background);

            control.Foreground = new SolidColorBrush(fontColor);
        }

        static void ChangeControlTheme(Label label, Color fontColor)
        {
            label.Foreground = new SolidColorBrush(fontColor);
        }

        static IEnumerable<object> GetAllControls(this Panel win)
        {
            /// GetAll UIElement
            UIElementCollection element = win.Children;

            /// casting the UIElementCollection into List
            List<object> lstElement = element.Cast<object>().ToList();

            /// Geting all Control from list
            List<object> lstControl = lstElement.OfType<object>().ToList();

            for (int i = 0; i < lstControl.Count(); i++)
            {
                if (lstControl[i] is StackPanel)
                {
                    lstControl.AddRange(GetAllControls(lstControl[i] as StackPanel));
                }
            }

            return lstControl;
        }
    }
}
