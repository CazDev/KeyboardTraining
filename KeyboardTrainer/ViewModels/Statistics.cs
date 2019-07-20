using System;

namespace KeyboardTrainer.Views.Training_.ViewModels
{
    public class Statistics : EventArgs
    {
        /// <summary>
        /// Chars that user have to type to finish game
        /// </summary>
        public string CharsLeft { get; set; }
        /// <summary>
        /// Num of mistakes that user has already done
        /// </summary>
        public int Mistakes { get; set; }
        /// <summary>
        /// User speed, keys per minute
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// How much time user is typing this round
        /// </summary>
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
