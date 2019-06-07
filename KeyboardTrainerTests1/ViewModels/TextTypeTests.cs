using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyboardTrainer.Views.Training_.ViewModels.Tests
{
    [TestClass()]
    public class TextTypeTests
    {
        int actualMistakes = 0;
        int expectedMistakes = 0;
        string ChrsLeft;
        [TestMethod()]
        public void TypeTextTest()
        {
            TextType.Mistaked += TextType_Mistaked;
            TextType.StatisticChanged += TextType_StatisticChanged;
            ChrsLeft = "ABCdef123.,!)";
            TextType.NewRound("ABCdef123.,!)");
            ChrsLeft = "BCdef123.,!)";
            TextType.SendChar("A");
            //stat changes -> chars left should be "BCdef123.,!)"

            char[] charsToSend = "BCdef".ToCharArray();

            ChrsLeft = "Cdef123.,!)";
            bool? result = TextType.SendChar("B");
            Assert.AreEqual(true, result);

            ChrsLeft = "def123.,!)";
            result = TextType.SendChar("C");
            Assert.AreEqual(true, result);

            ChrsLeft = "ef123.,!)";
            result = TextType.SendChar("d");
            Assert.AreEqual(true, result);

            ChrsLeft = "f123.,!)";
            result = TextType.SendChar("e");
            Assert.AreEqual(true, result);

            ChrsLeft = "123.,!)";
            result = TextType.SendChar("f");
            Assert.AreEqual(true, result);

            foreach (char chr in "errorChars".ToCharArray())
            {
                expectedMistakes++;
                bool? r = TextType.SendChar(chr.ToString());
                Assert.AreEqual(false, r);
            }

            expectedMistakes++;
            bool? res = TextType.SendChar(null);
            Assert.AreEqual(null, res);

            foreach (char chr in "123.,!)".ToCharArray())
            {
                ChrsLeft = ChrsLeft.Substring(1);//remove first char
                bool? r = TextType.SendChar(chr.ToString());
                Assert.AreEqual(true, r);
            }

            Assert.AreEqual("", "");
            Assert.AreEqual(expectedMistakes, actualMistakes);
        }

        private void TextType_StatisticChanged(Statistics statistics)
        {
            Assert.AreEqual(ChrsLeft, statistics.CharsLeft);
            Assert.AreEqual(expectedMistakes, statistics.Mistakes);
        }

        private void TextType_Mistaked(string letter)
        {
            actualMistakes++;
        }
    }
}