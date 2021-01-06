using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Words
{
    public interface IWord : ISentenceItem, IEnumerable<Symbol>
    {
        Symbol this[int index] { get; }
        int Length { get; }
    }
}
