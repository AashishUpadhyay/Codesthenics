using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class FindMostSimilarWebsites
    {
        public IList<Tuple<string, string>> Find(IList<Tuple<string, int>> websiteUserTuples, int noOfPairsToReturn)
        {
            var returnValue = new List<Tuple<string, string>>();

            var websiteUserDictionary = new Dictionary<string, IList<int>>();

            foreach (var tuple in websiteUserTuples)
            {
                if (websiteUserDictionary.ContainsKey(tuple.Item1))
                    websiteUserDictionary[tuple.Item1].Add(tuple.Item2);
                else
                    websiteUserDictionary.Add(tuple.Item1, new List<int>(tuple.Item2));
            }

            var jaccardIndexWebSiteTupleDictionary = new Dictionary<decimal, IList<Tuple<string, string>>>();

            var keys = websiteUserDictionary.Keys.ToList();
            var heap = new Heap<decimal>(Comparer<decimal>.Create((decimal x, decimal y)=>
            {
                if (x == y)
                    return 0;
                else if (x > y)
                    return -1;
                else
                    return 1;
            }));

            for (int i = 0; i < keys.Count - 1; i++)
            {
                for (int j = i + 1; j < keys.Count; j++)
                {
                    var jaccardIndex = CalculateJaccardIndex(websiteUserDictionary[keys[i]], websiteUserDictionary[keys[j]]);
                    var websiteTuple = new Tuple<string, string>(keys[i], keys[j]);
                    if (jaccardIndexWebSiteTupleDictionary.ContainsKey(jaccardIndex))
                        jaccardIndexWebSiteTupleDictionary[jaccardIndex].Add(websiteTuple);
                    else
                        jaccardIndexWebSiteTupleDictionary.Add(jaccardIndex, new List<Tuple<string, string>>() {
                            websiteTuple
                        });

                    heap.Push(jaccardIndex);
                }
            }

            while(noOfPairsToReturn>0)
            {
                var topJaccardIndex = heap.Pop();
                returnValue.AddRange(jaccardIndexWebSiteTupleDictionary[topJaccardIndex].ToList());
                noOfPairsToReturn--;
            }

            return returnValue;
        }

        private decimal CalculateJaccardIndex(IList<int> list1, IList<int> list2)
        {
            decimal countMatchingUsers = 0;
            var totalUsers = new HashSet<int>();
            foreach (var list1user in list1)
            {
                totalUsers.Add(list1user);
            }

            foreach (var list2User in list2)
            {
                if (totalUsers.Contains(list2User))
                    countMatchingUsers++;
                else
                    totalUsers.Add(list2User);
            }

            return (countMatchingUsers / totalUsers.Count);
        }
    }
}
