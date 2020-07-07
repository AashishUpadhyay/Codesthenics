using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class TowerOfHanoi
	{
		public void Move(int disks, Stack<int> source, Stack<int> intermediate, Stack<int> target)
		{
			if (disks == 0)
				return;

			Move(disks - 1, source, target, intermediate);
			target.Push(source.Pop());
			Move(disks - 1, intermediate, source, target);
		}
	}
}
