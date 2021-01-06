using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Texts.TextItems.Sentences.SentenceItems;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Words.ImplementingClasses;

namespace TextParser.TextCreation.TextItemsCreation.ImplementingClasses
{
    public class WordFactory : ISentenceItemFactory
    {
        public ISentenceItem Create(string chars)
        {
            return new Word(chars);
        }
    }
}
