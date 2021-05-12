using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HuffmanTreeTests
    {
        [TestMethod]
        public void Test1()
        {
            var huffmanTree = new HuffmanEncoding();
            var characterFrequencies = new Dictionary<char, int>();
            characterFrequencies.Add('C', 1);
            characterFrequencies.Add('A', 1);
            characterFrequencies.Add('T', 1);
            characterFrequencies.Add('S', 1);
            var encoding = huffmanTree.EncodeCharacters(characterFrequencies);
            Assert.IsTrue(encoding.Count == 4 && encoding['C'] == "00" && encoding['S'] == "01" && encoding['T'] == "10" && encoding['A'] == "11");
        }

        [TestMethod]
        public void Test2()
        {
            var huffmanTree = new HuffmanEncoding();
            var characterFrequencies = new Dictionary<char, int>();
            characterFrequencies.Add('a', 3);
            characterFrequencies.Add('c', 6);
            characterFrequencies.Add('e', 8);
            characterFrequencies.Add('f', 2);
            var encoding = huffmanTree.EncodeCharacters(characterFrequencies);
            Assert.IsTrue(encoding.Count == 4 && encoding['e'] == "0" && encoding['f'] == "100" && encoding['a'] == "101" && encoding['c'] == "11");
        }
    }
}
