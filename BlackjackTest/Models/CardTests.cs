using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Models.Enums;

namespace Uno.Models.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void ColorAsStringTest()
        {
            Assert.AreEqual("r", Card.ColorAsString(Color.Red));
            Assert.AreEqual("b", Card.ColorAsString(Color.Blue));
            Assert.AreEqual("g", Card.ColorAsString(Color.Green));
            Assert.AreEqual("y", Card.ColorAsString(Color.Yellow));
            Assert.AreEqual("w", Card.ColorAsString(Color.Wild));
        }

        [TestMethod()]
        public void FaceAsStringTest()
        {
            Assert.AreEqual("0", Card.FaceAsString(Face.Zero));
            Assert.AreEqual("1", Card.FaceAsString(Face.One));
            Assert.AreEqual("2", Card.FaceAsString(Face.Two));
            Assert.AreEqual("3", Card.FaceAsString(Face.Three));
            Assert.AreEqual("4", Card.FaceAsString(Face.Four));
            Assert.AreEqual("5", Card.FaceAsString(Face.Five));
            Assert.AreEqual("6", Card.FaceAsString(Face.Six));
            Assert.AreEqual("7", Card.FaceAsString(Face.Seven));
            Assert.AreEqual("8", Card.FaceAsString(Face.Eight));
            Assert.AreEqual("9", Card.FaceAsString(Face.Nine));
            Assert.AreEqual("s", Card.FaceAsString(Face.Skip));
            Assert.AreEqual("d", Card.FaceAsString(Face.Draw2));
            Assert.AreEqual("4", Card.FaceAsString(Face.Draw4));
            Assert.AreEqual("", Card.FaceAsString(Face.Wild));
        }
    }
}