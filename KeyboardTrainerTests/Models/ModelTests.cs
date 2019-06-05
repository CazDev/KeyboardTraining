using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyboardTrainer.Views.Training_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTrainer.Views.Training_.Models.Tests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod()]
        public void SendCharTest()
        {
            TypeLogic model = new TypeLogic();
            model.NewRound("qwertyuiopasdfghjklzxcvbnm");//starts new round using this string
            model.SendChar("q");//user input
            Assert.AreEqual("wertyuiopasdfghjklzxcvbnm", model.ChrsLeft);

            var chrsToDelete = "w1e2r3t4y5uio6pasd7fgh8jk9lzxc".ToCharArray();
            for (int i = 0; i < chrsToDelete.Length; i++)
            {
                model.SendChar(chrsToDelete[i].ToString());
            }

            Assert.AreEqual("vbnm", model.ChrsLeft);
            Assert.AreEqual(9, model.Mistakes);
        }
    }
}