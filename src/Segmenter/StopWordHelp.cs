using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JiebaNet.Segmenter.Common;

namespace JiebaNet.Segmenter
{
    public static class StopWordHelp
    {
        private static readonly List<string> DefaultStopWords = new List<string>()
        {
            "the", "of", "is", "and", "to", "in", "that", "we", "for", "an", "are",
            "by", "be", "as", "on", "with", "can", "if", "from", "which", "you", "it",
            "this", "then", "at", "have", "all", "not", "one", "has", "or", "that"
        };

        static StopWordHelp()
        {
            SetStopWords(ConfigManager.StopWordsFile);

            if (StopWords.IsEmpty())
            {
                StopWords.UnionWith(DefaultStopWords);
            }
        }

        public static ISet<string> StopWords { get; set; } = new HashSet<string>();

        public static void SetStopWords(string stopWordsFile)
        {
            var path = Path.GetFullPath(stopWordsFile);
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    StopWords.Add(line.Trim());
                }
            }
        }

        public static void AddStopWord(string word)
        {
            if (!StopWords.Contains(word))
            {
                StopWords.Add(word.Trim());
            }
        }

        public static void AddStopWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                AddStopWord(word);
            }
        }

        public static bool Contains(string word)
        {
            return StopWords.Contains(word.ToLower());
        }
    }

    public static class StopWordExtension
    {
        public static IEnumerable<string> RemoveUnusefulWord(this IEnumerable<string> words)
        {
            if (words == null || words.Any() == false)
            {
                return words;
            }

            var result = words.Except(StopWordHelp.StopWords);
            return result;
        }
    }
}
