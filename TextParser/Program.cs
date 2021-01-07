using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.IO;
using TextParser.TextCreation;
using TextParser.TextCreation.TextParsing;
using TextParser.TextProcessing;
using TextParser.Texts;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
            TextConverter textConverter = new TextConverter();
            TextHandler textHandler = new TextHandler(new SeparatorContainer());
            var text =textConverter.CreateText();

            Console.ReadLine();
          
        }
    }
}
