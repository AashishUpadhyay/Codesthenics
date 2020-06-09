using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codesthenics;

namespace UnitTestProject
{
	[TestClass]
	public class RegexMatchTests
	{
		[TestMethod]
		public void Test()
		{
			Assert.IsTrue((new RegexMatch()).IsAMatch("ra.", "rat"));
			Assert.IsFalse((new RegexMatch()).IsAMatch("ra.", "rats"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("ra.m.o.n.", "ratmmosnt"));
			Assert.IsFalse((new RegexMatch()).IsAMatch("ra..", "rat"));
			Assert.IsTrue((new RegexMatch()).IsAMatch(".*at", "chat"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("r*m*d", "raymond"));
			Assert.IsFalse((new RegexMatch()).IsAMatch("*at", "chats"));
			Assert.IsTrue((new RegexMatch()).IsAMatch(".*at", "chat"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("*chat", "chat"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("**c*t", "chat"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("aashish", "aashish"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("*", "aashish"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("*", "1"));
			Assert.IsTrue((new RegexMatch()).IsAMatch("", ""));
			Assert.IsTrue((new RegexMatch()).IsAMatch("*", ""));
			Assert.IsFalse((new RegexMatch()).IsAMatch("", "a"));
		}
	}
}
