using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Patterns
{
    public interface ICache
    {
        object Get(string key);
        void Put(string key, object value);
    }

    public class Cache : ICache
    {
        private readonly int _cap;
        private readonly LinkedList<Tuple<string, object>> _lst;
        private readonly Dictionary<string, LinkedListNode<Tuple<string, object>>> _map;
        private readonly object _lock = new object();
        private readonly object _lock_nd_movement = new object();

        public Cache(int cap)
        {
            this._cap = cap;
            _lst = new LinkedList<Tuple<string, object>>();
            _map = new Dictionary<string, LinkedListNode<Tuple<string, object>>>();
        }

        public int Count => _map.Count;

        public object Get(string key)
        {
            if (!_map.ContainsKey(key))
                return null;

            lock (_lock)
            {
                RemoveNodeAndAddItToBeginning(_map[key], _map[key]);
                return _map[key].Value.Item2;
            }
        }

        public void Put(string key, object value)
        {
            LinkedListNode<Tuple<string, object>> new_node = new LinkedListNode<Tuple<string, object>>(new Tuple<string, object>(key, value));

            lock (_lock)
            {
                if (_map.ContainsKey(key))
                {
                    RemoveNodeAndAddItToBeginning(_map[key], new_node);
                }
                else
                {
                    if (_map.Count == _cap)
                    {
                        LinkedListNode<Tuple<string, object>> node_to_remove = _lst.Last;
                        _lst.RemoveLast();
                        _map.Remove(node_to_remove.Value.Item1);
                    }
                    _lst.AddFirst(new_node);
                }
                _map[key] = new_node;
            }
        }

        private void RemoveNodeAndAddItToBeginning(LinkedListNode<Tuple<string, object>> nd_to_remove, LinkedListNode<Tuple<string, object>> nd_to_add)
        {
            lock (_lock_nd_movement)
            {
                _lst.Remove(nd_to_remove);
                _lst.AddFirst(nd_to_add);
            }
        }
    }
}
