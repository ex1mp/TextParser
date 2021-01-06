using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Texts.TextItems.Sentences.SentenceItems;

namespace TextParser.TextCreation.TextItemsCreation
{
    public interface ISentenceItemFactory
    {
        ISentenceItem Create(string chars);
    }
}
