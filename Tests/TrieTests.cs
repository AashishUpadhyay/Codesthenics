using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;

namespace Tests
{
    [TestClass]
    public class ArrayTrieTests
    {
        [TestMethod]
        public void ShouldInsertTheWordInArrayTrie()
        {
            var trie = new ArrayTrie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("MEENAKSHI_MURALIDHAR");

            Assert.IsTrue(trie.Contains("DOG"));
            Assert.IsTrue(trie.Contains("MARVEL"));
            Assert.IsTrue(trie.Contains("AASHISH"));
            Assert.IsTrue(trie.Contains("MEENAKSHI_MURALIDHAR"));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenWOrldDoesNotExistsArrayTrie()
        {
            var trie = new ArrayTrie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("MEENAKSHI");

            Assert.IsFalse(trie.Contains("BAKLAWA"));
        }

        [TestMethod]
        public void ShouldReturnTrieNodeWhenFoundArrayTrie()
        {
            var trie = new ArrayTrie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("MEENAKSHI");
            var node = trie.FindNode("AASHISH");
            Assert.IsTrue(node.Contains("AASHISH"));
        }

        [TestMethod]
        public void ShouldReturnNULLWhenNotFoundArrayTrie()
        {
            var trie = new ArrayTrie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("AASHISHUPADHYAY");
            trie.Insert("MEENAKSHI");
            var node = trie.FindNode("AAAAA");
            Assert.IsTrue(node == null);
        }

        [TestMethod]
        public void ShouldReturnAllMatchingStringsArrayTrie()
        {
            var trie = new ArrayTrie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("AASHISHUPADHYAY");
            trie.Insert("MEENAKSHI");
            trie.Insert("AASHISHVERMA");
            trie.Insert("AASHIMA");
            var node = trie.FindAllStringsMatchingPrefix("AASH");
            Assert.IsTrue(node.Any(u => u.ToLowerInvariant().Equals("aashish")) && node.Any(u => u.ToLowerInvariant().Equals("aashishupadhyay")) && node.Any(u => u.ToLowerInvariant().Equals("aashishverma")) && node.Any(u => u.ToLowerInvariant().Equals("aashima")));
        }

        [TestMethod]
        public void ShouldInsertTheWordInTrie()
        {
            var trie = new Trie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("MEENAKSHI_MURALIDHAR");

            Assert.IsTrue(trie.Contains("DOG"));
            Assert.IsTrue(trie.Contains("MARVEL"));
            Assert.IsTrue(trie.Contains("AASHISH"));
            Assert.IsTrue(trie.Contains("MEENAKSHI_MURALIDHAR"));
        }

        [TestMethod]
        public void ShouldReturnFalseWhenWOrldDoesNotExists()
        {
            var trie = new Trie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("MEENAKSHI");

            Assert.IsFalse(trie.Contains("BAKLAWA"));
        }

        [TestMethod]
        public void ShouldReturnTrieNodeWhenFound()
        {
            var trie = new Trie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("MEENAKSHI");
            var node = trie.FindNode("AASHISH");
            Assert.IsTrue(node.Contains("AASHISH"));
        }

        [TestMethod]
        public void ShouldReturnNULLWhenNotFound()
        {
            var trie = new Trie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("AASHISHUPADHYAY");
            trie.Insert("MEENAKSHI");
            var node = trie.FindNode("AAAAA");
            Assert.IsTrue(node == null);
        }

        [TestMethod]
        public void ShouldReturnAllMatchingStrings()
        {
            var trie = new Trie();
            trie.Insert("DOG");
            trie.Insert("MARVEL");
            trie.Insert("AASHISH");
            trie.Insert("AASHISHUPADHYAY");
            trie.Insert("MEENAKSHI");
            trie.Insert("AASHISHVERMA");
            trie.Insert("AASHIMA");
            var node = trie.FindAllStringsMatchingPrefix("AASH");
            Assert.IsTrue(node.Any(u => u.ToLowerInvariant().Equals("aashish")) && node.Any(u => u.ToLowerInvariant().Equals("aashishupadhyay")) && node.Any(u => u.ToLowerInvariant().Equals("aashishverma")) && node.Any(u => u.ToLowerInvariant().Equals("aashima")));
        }
    }
}
