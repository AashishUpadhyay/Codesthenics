using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System.Collections.Generic;

namespace Tests
{
	[TestClass]
	public class CommandPatternTests
	{
		[TestMethod]
		public void Test()
		{
			var oc = new Orchestrator();
			oc.Execute();
		}

	}
}
