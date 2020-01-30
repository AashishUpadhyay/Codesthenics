using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codesthenics;

namespace UnitTestProject
{
    [TestClass]
    public class LruCacheTests
    {
        [TestMethod]
        public void TestLastElementIsRemovedWhenOnlySetOperationsApplied()
        {
            var lruCache = new LruCache<string, string>(3);
            lruCache.Set("A", "A");
            lruCache.Set("B", "B");
            lruCache.Set("C", "C");
            lruCache.Set("D", "D");
            lruCache.Set("D", "D");

            string value;
            if (!(!lruCache.TryGetValue("A", out value) &&
                  lruCache.TryGetValue("B", out value) &&
                  lruCache.TryGetValue("C", out value) &&
                  lruCache.TryGetValue("D", out value) && lruCache.IsCacheValid()))
            {
                Assert.IsTrue(false);
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestNoElementRemovedWhenSizeLimitIsNotViolated()
        {
            var lruCache = new LruCache<string, string>(3);
            lruCache.Set("B", "B");
            lruCache.Set("A", "A");
            lruCache.Set("A", "A");

            string value;
            if (!(lruCache.TryGetValue("A", out value) &&
                  lruCache.TryGetValue("B", out value) && lruCache.IsCacheValid()))
            {
                Assert.IsTrue(false);
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestLastElementIsRemovedWhenOnlySetAndGetBothOperationsApplied()
        {
            var lruCache = new LruCache<string, string>(3);
            lruCache.Set("A", "A");
            lruCache.Set("B", "B");
            string valueToRead;
            lruCache.TryGetValue("A", out valueToRead);
            lruCache.Set("C", "C");
            lruCache.Set("D", "D");
            lruCache.Set("D", "D");

            string value;
            if (!(lruCache.TryGetValue("A", out value) &&
                  !lruCache.TryGetValue("B", out value) &&
                  lruCache.TryGetValue("C", out value) &&
                  lruCache.TryGetValue("D", out value) &&
                  lruCache.IsCacheValid()
                ))
            {
                Assert.IsTrue(false);
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestLastElementIsRemovedWhenOnlySetAndGetBothOperationsApplied_Negative()
        {
            //negative test
            var lruCache = new LruCache<string, string>(3);
            lruCache.Set("A", "A");
            lruCache.Set("B", "B");
            string valueToRead;
            lruCache.TryGetValue("A", out valueToRead);
            lruCache.TryGetValue("B", out valueToRead);
            lruCache.Set("C", "C");
            lruCache.Set("D", "D");
            lruCache.Set("D", "D");

            string value;
            if (!(lruCache.TryGetValue("A", out value) &&
                  !lruCache.TryGetValue("B", out value) &&
                  lruCache.TryGetValue("C", out value) &&
                  lruCache.TryGetValue("D", out value) &&
                  lruCache.IsCacheValid()
                ))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
    }
}
