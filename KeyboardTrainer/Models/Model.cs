using System;
using static KeyboardTrainer.Views.Training_.ViewModels.ViewModel;

namespace KeyboardTrainer.Views.Training_.Models
{
    public class Model
    {
        /// <summary>
        /// Chars that user should type
        /// </summary>
        public string ChrsLeft { get; set; }
        public int Mistakes { get; set; }
        public event Mistake Mistaked;

        /// <summary>
        /// When user presses key, returns if it is right key
        /// </summary>
        /// <param name="chr">key char, translated to russian if need</param>
        public bool? SendChar(string chr)
        {
            if (chr.ToLower() == "backspace")
            {
                return null;
            }
            if (chr.ToLower() == ChrsLeft.Substring(0, 1))
            {
                ChrsLeft = ChrsLeft.Substring(1);
                return true;
            }
            else
            {
                Mistaked?.Invoke(ChrsLeft.Substring(0, 1));
                Mistakes++;
                return false;
            }
        }

        /// <summary>
        /// mistakes = 0
        /// ChrsLeft = str_Input
        /// </summary>
        /// <param name="str_input"></param>
        public void NewRound(string str_input)
        {
            ChrsLeft = str_input;
            Mistakes = 0;
        }
    }
}