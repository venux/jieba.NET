using System.Collections.Generic;
using System.IO;

namespace JiebaNet.Analyser
{
    public abstract class KeywordExtractor
    {      
        public abstract IEnumerable<string> ExtractTags(string text, int count = 20, IEnumerable<string> allowPos = null);
        public abstract IEnumerable<WordWeightPair> ExtractTagsWithWeight(string text, int count = 20, IEnumerable<string> allowPos = null);
    }
}