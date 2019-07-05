using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyboardTrainer.Models.Tests
{
    [TestClass()]
    public class LocTests
    {
        [TestMethod()]
        public void Translate_AddTranslateTest()
        {
            Loc.Curr_Language = MLanguage.ENGLISH;
            Loc.AddTranslate("hello", "привет");
            Loc.AddTranslate("hello", "привет");//nothing should change
            Loc.Curr_Language = MLanguage.RUSSIAN;
            Assert.AreEqual("привет", Loc.Translate("привет"));
            Assert.AreEqual("привет", Loc.Translate("hello"));
            Loc.Curr_Language = MLanguage.ENGLISH;
            Assert.AreEqual("hello", Loc.Translate("привет"));
            Assert.AreEqual("hello", Loc.Translate("hello"));
        }
    }
}