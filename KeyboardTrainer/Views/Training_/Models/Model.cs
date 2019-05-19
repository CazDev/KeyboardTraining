namespace KeyboardTrainer.Views.Training_.Models
{
    public class Model
    {
        /// <summary>
        /// Chars that user should type
        /// </summary>
        public string ChrsLeft { get; set; }
        public int Mistakes { get; set; }

        /// <summary>
        /// When user presses key
        /// </summary>
        /// <param name="chr">key char, translated to russian if need</param>
        public void SendChar(string chr)
        {
            if (chr.ToLower() == ChrsLeft.Substring(0, 1))
            {
                ChrsLeft = ChrsLeft.Substring(1);
            }
            else
            {
                Mistakes++;
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