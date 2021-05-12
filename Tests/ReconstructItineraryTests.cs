using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Tests
{
	[TestClass]
	public class ReconstructItineraryTests
	{
		[TestMethod]
		public void Test1()
		{
			var ri = new ReconstructItinerary();
			var tickets = new List<IList<string>>() {
				new List<string>(){"EZE","AXA"},new List<string>(){"TIA","ANU"},new List<string>(){"ANU","JFK"},new List<string>(){"JFK","ANU"},new List<string>(){"ANU","EZE"},new List<string>(){"TIA","ANU"},new List<string>(){"AXA","TIA"},new List<string>(){"TIA","JFK"},new List<string>(){"ANU","TIA"},new List<string>(){"JFK","TIA"}
			};
			var iti = ri.FindItinerary(tickets);
			var itiAsString = string.Join(",", iti);
			Assert.IsTrue(string.Equals("JFK,ANU,EZE,AXA,TIA,ANU,JFK,TIA,ANU,TIA,JFK", itiAsString));
		}
	}
}
