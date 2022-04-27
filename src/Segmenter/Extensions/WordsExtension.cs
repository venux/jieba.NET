using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiebaNet.Segmenter
{
    public static class WordsExtension
    {
        public static IEnumerable<string> RemoveUnusefulWords(this IEnumerable<string> words)
        {
            if (words == null || words.Any() == false)
            {
                return words;
            }

            return words.RemoveStopWords()
                .RemoveEmptyWord();
        }

        public static IEnumerable<string> RemoveStopWords(this IEnumerable<string> words)
        {
            if (words == null || words.Any() == false)
            {
                return words;
            }

            var result = words.Except(StopWordHelp.StopWords);
            return result;
        }

        public static IEnumerable<string> RemoveEmptyWord(this IEnumerable<string> words)
        {
            if (words == null || words.Any() == false)
            {
                return words;
            }

            var result = words.Except(new List<string> { "", " " });
            return result;
        }
    }
}
