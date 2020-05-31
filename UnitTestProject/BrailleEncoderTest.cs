using System;
using Codesthenics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class BrailleEncoderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("code");
            Assert.AreEqual("100100101010100110100010", received);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("Braille");
            Assert.AreEqual("000001110000111010100000010100111000111000100010", received);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("The quick brown fox jumps over the lazy dog");
            Assert.AreEqual("000001011110110010100010000000111110101001010100100100101000000000110000111010101010010111101110000000110100101010101101000000010110101001101100111100011100000000101010111001100010111010000000011110110010100010000000111000100000101011101111000000100110101010110110", received);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("");
            Assert.AreEqual("", received);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var be = new BrailleEncoder();
            var received = be.Encode(null);
            Assert.AreEqual("", received);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("  code ");
            Assert.AreEqual("000000000000100100101010100110100010000000", received);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("CODE");
            Assert.AreEqual("000001100100000001101010000001100110000001100010", received);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var be = new BrailleEncoder();
            var received = be.Encode("CODE Braille The quick brown fox jumps over the lazy dog  code ");
            Assert.AreEqual("000001100100000001101010000001100110000001100010000000000001110000111010100000010100111000111000100010000000000001011110110010100010000000111110101001010100100100101000000000110000111010101010010111101110000000110100101010101101000000010110101001101100111100011100000000101010111001100010111010000000011110110010100010000000111000100000101011101111000000100110101010110110000000000000100100101010100110100010000000", received);
        }
    }
}
