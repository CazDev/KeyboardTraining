using System;
using System.Windows;

namespace KeyboardTrainer.Models
{
    [Serializable]
    public class WindowSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public WindowState WindowState { get; set; } = WindowState.Normal;

        public WindowSize(int width, int height, WindowState windowState)
        {
            Width = width;
            Height = height;
            WindowState = WindowState;
        }

        public WindowSize(Window win)
        {
            Width = (int)win.Width;
            Height = (int)win.Height;
            WindowState = win.WindowState;
        }

        public void ApplySizeForWindow(Window win)
        {
            win.Width = this.Width;
            win.Height = this.Height;
            win.WindowState = this.WindowState;
        }
    }
}
