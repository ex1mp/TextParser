using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Texts.TextItems.Sentences.SentenceItems;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations.ImplementingClasses;

namespace TextParser.TextCreation.TextItemsCreation.ImplementingClasses
{
    public class PunctuationFactory : ISentenceItemFactory
    {
        IDictionary<string, ISentenceItem> cachedItems;

        public ISentenceItem Create(string chars)
        {
            return cachedItems.ContainsKey(chars) ? cachedItems[chars] : null;
        }

        public PunctuationFactory(SeparatorContainer separatorContainer)
        {
            this.cachedItems = new Dictionary<string, ISentenceItem>();
            foreach (var c in separatorContainer.All())
            {
                this.cachedItems.Add(c, new Punctuation(c));
            }
        }
    }
}
