using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitmanList
{
    public class LruCache<TK, TV>
    {
        private readonly object _lock = new object();
        private readonly int _size;
        private readonly Dictionary<TK, DoublyinkedListNode<NodeData>> _cache;
        private readonly DoublyinkedList<NodeData> _linkedList;


        public LruCache(int size = 5)
        {
            _size = size;
            _cache = new Dictionary<TK, DoublyinkedListNode<NodeData>>();
            _linkedList = new DoublyinkedList<NodeData>();
        }

        public void Set(TK key, TV value)
        {
            lock (_lock)
            {
                if (_cache.ContainsKey(key))
                {
                    _linkedList.Remove(_cache[key]);
                    _cache.Remove(key);
                }

                var nodeData = new NodeData(key, value);
                var node = new DoublyinkedListNode<NodeData>(nodeData)
                {
                    Value = nodeData
                };
                _linkedList.Add(node);
                _cache.Add(key, node);

                if (_cache.Count > _size)
                {
                    _cache.Remove(_linkedList.Head.Value.Key);
                    _linkedList.Remove(_linkedList.Head);
                }
            }
        }

        public bool TryGetValue(TK key, out TV value)
        {
            lock (_lock)
            {
                DoublyinkedListNode<NodeData> fetchedValue;
                if (_cache.TryGetValue(key, out fetchedValue))
                {
                    value = fetchedValue.Value.Value;
                    var newNode = new NodeData(key, fetchedValue.Value.Value);
                    _linkedList.Remove(fetchedValue);
                    _linkedList.Add(new DoublyinkedListNode<NodeData>(newNode));
                    return true;
                }

                value = default(TV);
                return false;
            }
        }

        public bool IsCacheValid()
        {
            lock(_lock)
            {
              return  _cache != null && (_linkedList != null && _cache.Count() == _linkedList.Count);
            }
        }

        private class NodeData
        {
            public NodeData(TK key, TV value)
            {
                Key = key;
                Value = value;
            }

            public TK Key { get; private set; }

            public TV Value{ get; private set; }
        }

    }

    public class LruCacheTests
    {
        public static void RunAll()
        {
            try
            {
                TestsLastRecentlyUsedElementIsRemoved_Test1();
                TestsLastRecentlyUsedElementIsRemoved_Test2();
                Console.WriteLine("All tests passed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Tests failed!");
            }
        }

        public static void TestsLastRecentlyUsedElementIsRemoved_Test1()
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
                throw new Exception("Last recently used element does not get removed!");
            }
        }

        public static void TestsLastRecentlyUsedElementIsRemoved_Test2()
        {
            var lruCache = new LruCache<string, string>(3);
            lruCache.Set("B", "B");
            lruCache.Set("A", "A");
            lruCache.Set("A", "A");

            string value;
            if (!(lruCache.TryGetValue("A", out value) &&
                lruCache.TryGetValue("B", out value) && lruCache.IsCacheValid()))
            {
                throw new Exception("Cache removes item even when not required!");
            }
        }
    }
}
