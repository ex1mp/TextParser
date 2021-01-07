using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextParser.Texts.TextItems.Sentences.SentenceItems;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations.ImplementingClasses;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Words.ImplementingClasses;

namespace TextParser.Texts.TextItems.Sentences.ImplementingClasses
{
    public class Sentence : ISentence
    {
        public List<ISentenceItem> sentenceItems { get; set; }
        public Sentence()
        {
            sentenceItems = new List<ISentenceItem>();
        }

        public Sentence(List<ISentenceItem> source)
        {
            sentenceItems = source;
        }

        public void Add(ISentenceItem item)
        {
            if (item != null)
            {
                sentenceItems.Add(item);
            }
            else
            {
                throw new NullReferenceException("");
            }
        }
        public string SentenceInStringFormat()
        {
            string sentence = "";
            foreach (var item in sentenceItems)
            {
                if (item is Word)
                {
                    sentence += " " + item.Chars ;
                }
                if (item is Punctuation)
                {
                    sentence +=item.Chars;
                } 
            }
            return sentence;
        }

        public bool Remove(ISentenceItem item)
        {
            var container = sentenceItems.ToList();
            var res = container.RemoveAll(x => x.Chars == item.Chars);
            sentenceItems = container;
            return res != 0;
        }
        public int Count
        {
            get { return sentenceItems.OfType<Word>().Count(); }
        }

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return sentenceItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
