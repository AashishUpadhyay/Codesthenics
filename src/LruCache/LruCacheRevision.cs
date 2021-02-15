using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class LruCacheRevision
	{
		private readonly Dictionary<int, LinkedListNode<int[]>> _cache;
		private readonly LinkedList<int[]> _linkedList;
		private readonly int _size;

		public LruCacheRevision(int size = 5)
		{
			_size = size;
			_cache = new Dictionary<int, LinkedListNode<int[]>>();
			_linkedList = new LinkedList<int[]>();
		}

		public void Put(int key, int value)
		{
			if (_cache.ContainsKey(key))
			{
				_cache[key].Value[1] = value;
				_linkedList.Remove(_cache[key]);
				_linkedList.AddFirst(_cache[key]);
				return;
			}

			if (_cache.Count() < _size)
			{
				_cache.Add(key, new LinkedListNode<int[]>(new int[2] { key, value }));
				_linkedList.AddFirst(_cache[key]);
				return;
			}

			var itemToRemove = _linkedList.Last();
			_linkedList.Remove(itemToRemove);
			_cache.Remove(itemToRemove[0]);

			_cache.Add(key, new LinkedListNode<int[]>(new int[2] { key, value }));
			_linkedList.AddFirst(_cache[key]);

			return;
		}

		public int Get(int key)
		{
			if (!_cache.ContainsKey(key))
				return -1;

			_linkedList.Remove(_cache[key]);
			_linkedList.AddFirst(_cache[key]);

			return _cache[key].Value[1];
		}
	}
}
