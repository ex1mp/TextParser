using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextParser.TextCreation.TextParsing;
using TextParser.Texts;
using TextParser.Texts.TextItems.Sentences;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Words.ImplementingClasses;

namespace TextParser.TextProcessing
{
    public class TextHandler
    {
        private StringParser sentenceParser;
        public TextHandler(SeparatorContainer separatorContainer)
        {
            this.sentenceParser = new StringParser(separatorContainer);
        }
        public IOrderedEnumerable<ISentence> SortSentencesByWordCount(Text text)
        {
            return text.Sentences.OrderBy(t => t.Count);
        }
        public IEnumerable<string> WordsInInterrogativeSentence(Text text, int wordLength)
        {
            var words = new List<string>();
            foreach (var sentence in text.Sentences)
            {
                if (sentence.sentenceItems.Last().Chars == "?")
                {
                    words.AddRange(sentence.Where(x => x.Chars.Length == wordLength).Select(x => x.Chars));
                }
            }

            return words.Distinct();

            //text.Sentences.
            //    Where(x => x.sentenceItems.Last().Chars == "?").
            //    SelectMany(sentence => sentence.Where(word => word.Chars.Length == wordLength).Select(x => x.Chars)).
            //    Distinct().
            //    OrderBy(x => x);
        }
        public bool StartWithConsonantDelite(ref Text text, int length)
        {
            string letters = "бвгджзклмнпрстфхцчщъыь";
            //string letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            bool sucess = false;
            foreach (var sentence in text.Sentences)
            {
                foreach (var item in sentence)
                {
                    if (letters.Contains(item.Chars.Substring(0, 1).ToLower()) && item.Chars.Length == length)
                    {
                        sentence.Remove(item);
                        sucess = true;
                    }
                }
            }
            return sucess;
        }
        public ISentence WordReplacing(ISentence sentence, int length, string expression)
        {
            var replIndexs = new List<int>();
            var replacementElements = sentenceParser.stringParse(expression);
            for (int i = 0; i < sentence.sentenceItems.Count; i++)
            {
                if (sentence.sentenceItems[i].Chars.Length == length && sentence.sentenceItems[i] is Word)
                {
                    replIndexs.Add(i);
                }
            }
            replIndexs.Reverse();
            for (int i = replIndexs.Count; i >= 0; i--)
            {

            }
            foreach (var num in replIndexs)
            {
                sentence.sentenceItems.RemoveAt(num);
                sentence.sentenceItems.InsertRange(num, replacementElements);
            }
            return sentence;
        }
    }
}
