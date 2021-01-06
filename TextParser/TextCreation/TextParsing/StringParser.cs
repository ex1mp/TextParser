using System;
using System.Collections.Generic;
using System.Text;
using TextParser.TextCreation.TextItemsCreation.ImplementingClasses;
using TextParser.Texts.TextItems.Sentences.ImplementingClasses;
using TextParser.Texts.TextItems.Sentences.SentenceItems;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;

namespace TextParser.TextCreation.TextParsing
{
        public class StringParser
        {
            private SeparatorContainer separatorContainer { get; set; }
            private SentenceItemFactory sentenceItemFactory { get; set; }
            public StringParser(SeparatorContainer separatorContainer)
            {
                this.separatorContainer = separatorContainer;
                sentenceItemFactory = new SentenceItemFactory(new PunctuationFactory(separatorContainer), new WordFactory());
            }
            public Sentence ParseSentence(string sentence)
            {
                return new Sentence(stringParse(sentence));
                //Sentence parcedSentece = new Sentence();
                //foreach (var item in ElementSeparator(sentence))
                //{
                //    parcedSentece.Add(sentenceItemFactory.Create(item));
                //}
                //return parcedSentece;
            }
            private string[] ElementSeparator(string sentence)
            {
                foreach (var item in separatorContainer.All())
                {
                    sentence = sentence.Replace(item, " " + item + " ");
                }
                return sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            public List<ISentenceItem> stringParse(string expression)
            {
                var parsedExpression = new List<ISentenceItem>();
                foreach (var item in ElementSeparator(expression))
                {
                    parsedExpression.Add(sentenceItemFactory.Create(item));
                }
                return parsedExpression;
            }
        }
}
