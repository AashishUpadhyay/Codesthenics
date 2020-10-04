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

		[TestMethod]
		public void Test3()
		{
			var chooseStepwordChain = new ChooseStepwordChain();
			var returnedValueBFS = chooseStepwordChain.LadderLengthBFS("dog", "cat", new List<string>() {
				"dot","dop","dat","cat"
			});

			var returnedValueDFS = chooseStepwordChain.LadderLengthBFS("dog", "cat", new List<string>() {
				"dot","dop","dat","cat"
			});

			Assert.IsTrue(returnedValueBFS == returnedValueDFS);
		}

		[TestMethod]
		public void Test4()
		{
			var chooseStepwordChain = new ChooseStepwordChain();
			var returnedValueBFS = chooseStepwordChain.LadderLengthBFS("dog", "cat", new List<string>() {
				 "dop","dat","cat"
			});

			var returnedValueDFS = chooseStepwordChain.LadderLengthBFS("dog", "cat", new List<string>() {
				"dop","dat","cat"
			});

			Assert.IsTrue(returnedValueBFS == 0);
			Assert.IsTrue(returnedValueBFS == returnedValueDFS);
		}

		[TestMethod]
		public void Test5()
		{
			var chooseStepwordChain = new ChooseStepwordChain();
			var returnedValueBFS = chooseStepwordChain.LadderLengthBFS("hit", "cog", new List<string>() {
			   "hot","dot","dog","lot","log","cog"
			});

			var returnedValueDFS = chooseStepwordChain.LadderLengthBFS("hit", "cog", new List<string>() {
				"hot","dot","dog","lot","log","cog"
			});

			Assert.IsTrue(returnedValueBFS == returnedValueDFS);
		}

		[TestMethod]
		public void Test6()
		{
			var chooseStepwordChain = new ChooseStepwordChain();
			var returnedValueBFS = chooseStepwordChain.LadderLengthBFS("hit", "cog", new List<string>() {
			  "hot","dot","dog","lot","log"
			});

			var returnedValueDFS = chooseStepwordChain.LadderLengthBFS("hit", "cog", new List<string>() {
			  "hot","dot","dog","lot","log"
			});

			Assert.IsTrue(returnedValueBFS == 0);
			Assert.IsTrue(returnedValueBFS == returnedValueDFS);
		}

		[TestMethod]
		public void Test7()
		{
			var chooseStepwordChain = new ChooseStepwordChain();
			var returnedValueBFS = chooseStepwordChain.LadderLengthBFS("qa", "sq", new List<string>() {			  "si","go","se","cm","so","ph","mt","db","mb","sb","kr","ln","tm","le","av","sm","ar","ci","ca","br","ti","ba","to","ra","fa","yo","ow","sn","ya","cr","po","fe","ho","ma","re","or","rn","au","ur","rh","sr","tc","lt","lo","as","fr","nb","yb","if","pb","ge","th","pm","rb","sh","co","ga","li","ha","hz","no","bi","di","hi","qa","pi","os","uh","wm","an","me","mo","na","la","st","er","sc","ne","mn","mi","am","ex","pt","io","be","fm","ta","tb","ni","mr","pa","he","lr","sq","ye"
			});

			var returnedValueDFS = chooseStepwordChain.LadderLengthBFS("qa", "sq", new List<string>() {"si","go","se","cm","so","ph","mt","db","mb","sb","kr","ln","tm","le","av","sm","ar","ci","ca","br","ti","ba","to","ra","fa","yo","ow","sn","ya","cr","po","fe","ho","ma","re","or","rn","au","ur","rh","sr","tc","lt","lo","as","fr","nb","yb","if","pb","ge","th","pm","rb","sh","co","ga","li","ha","hz","no","bi","di","hi","qa","pi","os","uh","wm","an","me","mo","na","la","st","er","sc","ne","mn","mi","am","ex","pt","io","be","fm","ta","tb","ni","mr","pa","he","lr","sq","ye"});

			Assert.IsTrue(returnedValueBFS == returnedValueDFS);
		}
	}
}
