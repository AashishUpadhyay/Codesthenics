using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;

namespace Tests
{
	[TestClass]
	public class LruCacheRevisionRevisionTests
	{
		[TestMethod]
		public void TestLastElementIsRemovedWhenOnlyPutOperationsApplied()
		{
			var LruCacheRevision = new LruCacheRevision(3);
			LruCacheRevision.Put(1, 1);
			LruCacheRevision.Put(2, 2);
			LruCacheRevision.Put(3, 3);
			LruCacheRevision.Put(4, 4);
			LruCacheRevision.Put(5, 5);

			Assert.IsTrue((LruCacheRevision.Get(1) == -1 &&
			  LruCacheRevision.Get(2) == -1 &&
			  LruCacheRevision.Get(3) == 3 &&
			  LruCacheRevision.Get(4) == 4 &&
			  LruCacheRevision.Get(5) == 5));
		}

		[TestMethod]
		public void TestNoElementRemovedWhenSizeLimitIsNotViolated()
		{
			var LruCacheRevision = new LruCacheRevision(3);
			LruCacheRevision.Put(2, 2);
			LruCacheRevision.Put(1, 1);
			LruCacheRevision.Put(1, 1);

			Assert.IsTrue(LruCacheRevision.Get(1) == 1 &&
		  LruCacheRevision.Get(2) == 2);
		}

		[TestMethod]
		public void TestLastElementIsRemovedWhenOnlyPutAndGetBothOperationsApplied()
		{
			var LruCacheRevision = new LruCacheRevision(3);
			LruCacheRevision.Put(1, 1);
			LruCacheRevision.Put(2, 2);
			LruCacheRevision.Get(1);
			LruCacheRevision.Put(3, 3);
			LruCacheRevision.Put(4, 4);
			LruCacheRevision.Put(4, 4);

			Assert.IsTrue(LruCacheRevision.Get(1) == 1 &&
			  LruCacheRevision.Get(2) == -1 &&
			  LruCacheRevision.Get(3) == 3 &&
			  LruCacheRevision.Get(4) == 4);
		}

		[TestMethod]
		public void TestLastElementIsRemovedWhenOnlyPutAndGetBothOperationsApplied_Negative()
		{
			var LruCacheRevision = new LruCacheRevision(3);
			LruCacheRevision.Put(1, 1);
			LruCacheRevision.Put(2, 2);
			LruCacheRevision.Get(1);
			LruCacheRevision.Get(2);
			LruCacheRevision.Put(3, 3);
			LruCacheRevision.Put(4, 4);
			LruCacheRevision.Put(4, 4);

			Assert.IsTrue(LruCacheRevision.Get(1) == -1 &&
			  LruCacheRevision.Get(2) == 2 &&
			  LruCacheRevision.Get(3) == 3 &&
			  LruCacheRevision.Get(4) == 4
			);
		}
	}
}
