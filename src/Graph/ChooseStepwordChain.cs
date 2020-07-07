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
    }
}
