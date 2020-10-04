using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
    public class ChooseStepwordChain
    {
        public IList<string> BuildStepwordChain(string startWord, string endWord, HashSet<string> wordListHash)
        {
            var transformationSequence = new List<string>() { startWord };
            var stopProcessing = false;

            while (!stopProcessing)
            {
                var transformedWord = TransformWord(transformationSequence[transformationSequence.Count - 1], endWord, wordListHash);

                if (transformedWord.Equals(endWord))
                {
                    stopProcessing = true;
                    transformationSequence.Add(transformedWord);
                }
                else if (transformedWord.Equals(string.Empty))
                {
                    stopProcessing = true;
                }
                else
                {
                    transformationSequence.Add(transformedWord);
                }
            }

            if (transformationSequence[transformationSequence.Count - 1] == endWord)
                return transformationSequence;

            return null;
        }

        private string TransformWord(string wordToTransform, string endWord, HashSet<string> wordListHash)
        {
            var wordToTransformAsArray = wordToTransform.ToArray();
            for (int i = 0; i < wordToTransform.Length; i++)
            {
                wordToTransformAsArray[i] = endWord[i];
                var nw =new string(wordToTransformAsArray);
                if (wordListHash.Contains(nw))
                    return nw;
                else
                    wordToTransformAsArray[i] = wordToTransform[i];
            }

            return string.Empty;
        }

        private Dictionary<string, IList<string>> _graph = new Dictionary<string, IList<string>>();
        private int _count;
        private int _wordLength;
        public int LadderLengthBFS(string beginWord, string endWord, IList<string> wordList)
        {
            _count = Int32.MaxValue;
            _wordLength = beginWord.Length;
            foreach (var word in wordList)
            {
                for (int i = 0; i < _wordLength; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < _wordLength; j++)
                    {
                        if (i == j)
                            sb.Append('*');
                        else
                            sb.Append(word[j]);
                    }

                    string nw = sb.ToString();
                    if (!_graph.ContainsKey(nw))
                        _graph.Add(nw, new List<string>());

                    _graph[nw].Add(word);
                }
            }

            return BFS(beginWord, endWord);
        }

        public int LadderLengthDFS(string beginWord, string endWord, IList<string> wordList)
        {
            _count = Int32.MaxValue;
            _wordLength = beginWord.Length;
            foreach (var word in wordList)
            {
                for (int i = 0; i < _wordLength; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < _wordLength; j++)
                    {
                        if (i == j)
                            sb.Append('*');
                        else
                            sb.Append(word[j]);
                    }

                    string nw = sb.ToString();
                    if (!_graph.ContainsKey(nw))
                        _graph.Add(nw, new List<string>());

                    _graph[nw].Add(word);
                }
            }

			HashSet<string> visited = new HashSet<string>();
			DFS(beginWord, endWord, 1, visited);
			return _count == Int32.MaxValue ? 0 : _count;
		}

        private void DFS(string word, string endWord, int level, HashSet<string> visited)
        {
            if (visited.Contains(word))
                return;

            visited.Add(word);
            for (int i = 0; i < _wordLength; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < _wordLength; j++)
                {
                    if (i == j)
                        sb.Append('*');
                    else
                        sb.Append(word[j]);
                }

                string nw = sb.ToString();
                if (_graph.ContainsKey(nw))
                {
                    var neighbours = _graph[nw];
                    foreach (var n in neighbours)
                    {
                        if (n == endWord)
                        {
                            _count = Math.Min(level + 1, _count);
                        }
                        else
                            DFS(n, endWord, level + 1, visited);
                    }
                }
            }
            visited.Remove(word);
        }

        private int BFS(string word, string endWord)
        {
            Queue<string[]> queue = new Queue<string[]>();
            queue.Enqueue(new string[2] { word, "1" });
            HashSet<string> visited = new HashSet<string>();

            while (queue.Count() > 0)
            {
                string[] dqedItem = queue.Dequeue();
                string wordToProcess = dqedItem[0];
                int nextLevel = Convert.ToInt32(dqedItem[1]) + 1;
                if (wordToProcess == endWord)
                    return Convert.ToInt32(dqedItem[1]);

                visited.Add(wordToProcess);
                for (int i = 0; i < _wordLength; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < _wordLength; j++)
                    {
                        if (i == j)
                            sb.Append('*');
                        else
                            sb.Append(wordToProcess[j]);
                    }

                    string nw = sb.ToString();
                    if (_graph.ContainsKey(nw))
                    {
                        IList<string> neighbours = _graph[nw];
                        foreach (var n in neighbours)
                        {
                            if (!visited.Contains(n))
                            {
                                queue.Enqueue(new string[2] { n, Convert.ToString(nextLevel) });
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }
}
