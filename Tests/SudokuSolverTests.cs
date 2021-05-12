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
	public class SudokuSolverTests
	{
		[TestMethod]
		public void Test1()
		{
			var ri = new SudokuSolver();
			var input = new char[9][] {
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '1', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '3' },
				new char[9] { '4', '.', '.', '.', '.', '3', '.', '.', '1' },
				new char[9] { '.', '.', '.', '.', '2', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '2', '.', '.' },
				new char[9] { '.', '.', '.', '4', '1', '.', '.', '.', '.' },
				new char[9] { '.','.','.','.','.','.','.','.','.'}
		};
			var returnValue = ri.SolveSudoku(input);
		}

		[TestMethod]
		public void Test2()
		{
			var ri = new SudokuSolver();
			var input = new char[9][] {
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
				new char[9] { '.','.','.','.','.','.','.','.','.'}
		};
			var returnValue = ri.SolveSudoku(input);
		}
	}
}
