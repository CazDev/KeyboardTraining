using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyboardTrainer.Views.Training_.Models.Tests
{
    [TestClass()]
    public class TypeLogicTests
    {
        int expectedMistakes = 0;
        int actualMistakes = 0;

        [TestMethod()]
        public void NewRoundSendCharTest()
        {
            TypeLogic typeLogic = new TypeLogic();
            typeLogic.Mistaked += TypeLogic_Mistaked;
            typeLogic.NewRound("ABCdef123.,!)");
            typeLogic.SendChar("A");

            Assert.AreEqual("BCdef123.,!)", typeLogic.ChrsLeft);
            char[] charsToSend = "BCdef".ToCharArray();
            foreach (char chr in charsToSend)
            {
                bool? result = typeLogic.SendChar(chr.ToString());
                Assert.AreEqual(true, result);
            }

            Assert.AreEqual("123.,!)", typeLogic.ChrsLeft);

            foreach (char chr in "errorChars".ToCharArray())
            {
                bool? result = typeLogic.SendChar(chr.ToString());
                Assert.AreEqual(false, result);
                expectedMistakes++;
            }

            expectedMistakes++;
            bool? res = typeLogic.SendChar(null);
            Assert.AreEqual(null, res);

            foreach (char chr in "123.,!)".ToCharArray())
            {
                bool? result = typeLogic.SendChar(chr.ToString());
                Assert.AreEqual(true, result);
            }

            Assert.AreEqual("", typeLogic.ChrsLeft);
            Assert.AreEqual(expectedMistakes, actualMistakes);
        }

        private void TypeLogic_Mistaked(string letter)
        {
            actualMistakes++;
        }
    }
}