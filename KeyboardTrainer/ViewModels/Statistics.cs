using System;

namespace KeyboardTrainer.Views.Training_.ViewModels
{
    public class Statistics : EventArgs
    {
        public string CharsLeft { get; set; }
        public int Mistakes { get; set; }
        public double Speed { get; set; }
        public TimeSpan Time { get; set; }

        public Statistics(string charsLeft, int mistakes)
        {
            CharsLeft = charsLeft;
            Mistakes = mistakes;
        }

        public Statistics(string charsLeft, int mistakes, double speed) : this(charsLeft, mistakes)
        {
            Speed = speed;
        }

        public Statistics(string charsLeft, int mistakes, double speed, TimeSpan time) : this(charsLeft, mistakes, speed)
        {
            Time = time;
        }
    }
}
