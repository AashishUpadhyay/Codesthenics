using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ChooseStepwordChainTests
    {
        [TestMethod]
        public void Test1()
        {
            var chooseStepwordChain = new ChooseStepwordChain();
            var returnedValue = chooseStepwordChain.BuildStepwordChain("dog", "cat", new System.Collections.Generic.HashSet<string>() {
                "dot","dop","dat","cat"
            });

            var expectedValue = new List<string>() { "dog", "dot", "dat", "cat" };

            Assert.IsTrue(returnedValue[0].Equals(expectedValue[0]));
            Assert.IsTrue(returnedValue[1].Equals(expectedValue[1]));
            Assert.IsTrue(returnedValue[2].Equals(expectedValue[2]));
            Assert.IsTrue(returnedValue[3].Equals(expectedValue[3]));
        }

        [TestMethod]
        public void Test2()
        {
            var chooseStepwordChain = new ChooseStepwordChain();
            var returnedValue = chooseStepwordChain.BuildStepwordChain("dog", "cat", new System.Collections.Generic.HashSet<string>() {
                "dop","dat","cat"
            });


            Assert.IsTrue(returnedValue == null);
        }
    }
}
