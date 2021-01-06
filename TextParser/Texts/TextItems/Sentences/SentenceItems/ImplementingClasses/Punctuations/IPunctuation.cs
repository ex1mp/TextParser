using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations
{
    public interface IPunctuation : ISentenceItem
    {
        Symbol Value { get; }
    }
}
