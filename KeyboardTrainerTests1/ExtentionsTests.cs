using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class ExtentionsTests
    {
        [TestMethod()]
        public void RemoveSpacesFromEndTest()
        {
            string str = "some text ";
            string newStr = str.RemoveSpacesFromEnd();
            Assert.AreEqual("some text", newStr);

            str = "some text                  ";
            newStr = str.RemoveSpacesFromEnd();
            Assert.AreEqual("some text", newStr);

            str = "some text\nnew line\tand tab        ";
            newStr = str.RemoveSpacesFromEnd();
            Assert.AreEqual("some text\nnew line\tand tab", newStr);

            str = "                  ";
            newStr = str.RemoveSpacesFromEnd();
            Assert.AreEqual("", newStr);
        }
    }
}