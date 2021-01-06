using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Texts.TextItems.Sentences.SentenceItems;

namespace TextParser.Texts.TextItems.Sentences
{
    public interface ISentence : IEnumerable<ISentenceItem>
    {
        void Add(ISentenceItem item);
        bool Remove(ISentenceItem item);
        List<ISentenceItem> sentenceItems { get; set; }
        int Count { get; }
    }
}
