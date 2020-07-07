using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class DisjointSet<T>
    {
        private IList<Node<T>> Nodes = new List<Node<T>>();
        private readonly IDictionary<T, Node<T>> Set = new Dictionary<T, Node<T>>();
        private readonly IDictionary<T, IList<T>> ReverseSet = new Dictionary<T, IList<T>>();

        public IList<IList<T>> Group(IDictionary<T, IList<T>> items)
        {
            MakeSet(items);
            foreach (var item in items.Keys)
            {
                foreach (var val in items[item])
                {
                    Union(item, val);
                }
            }
            return ReverseSet.Select(u => u.Value).ToList();
        }

        private void MakeSet(IDictionary<T, IList<T>> items)
        {
            foreach (var item in items.Keys)
            {
                var node = new Node<T>()
                {
                    Val = item,
                    Rank = 1
                };

                node.Group = node;
                Set.Add(item, node);
                ReverseSet.Add(item, new List<T>() { item });
            }
        }

        private void Union(T item1, T item2)
        {
            var group1 = Find(item1);
            var group2 = Find(item2);

            if (group1 != group2)
            {
                if (group1.Rank > group2.Rank)
                {
                    SwitchGroups(item2, group1, group2);
                }
                else
                {
                    SwitchGroups(item1, group2, group1);
                }
            }
        }

        private void SwitchGroups(T item2, Node<T> group1, Node<T> group2)
        {
            group2.Group = group1;
            Set[item2] = group1;

            foreach (var i in ReverseSet[group2.Val])
            {
                Set[i] = group1;
                ReverseSet[group1.Val].Add(i);
            }

            ReverseSet.Remove(group2.Val);
        }

        private Node<T> Find(T item)
        {
            var group = Set[item];

            while (group != Set[group.Val])
                group = Set[group.Val].Group;

            return group;
        }
    }

    public class Node<T>
    {
        public T Val { get; set; }

        public Node<T> Group { get; set; }
        public int Rank { get; set; }

        public static bool operator ==(Node<T> obj1, Node<T> obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;

            return obj1.Val.Equals(obj2.Val);
        }

        public static bool operator !=(Node<T> obj1, Node<T> obj2)
        {
            return !(obj1.Val.Equals(obj2.Val));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var node = (Node<T>)obj;
            return Val.Equals(node.Val);
        }

        public override int GetHashCode()
        {
            return Val.GetHashCode();
        }
    }
}
