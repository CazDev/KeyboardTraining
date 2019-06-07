using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyboardTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer.ViewModels.Tests
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
        }
    }
}