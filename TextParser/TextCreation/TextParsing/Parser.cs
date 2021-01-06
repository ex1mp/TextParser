using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TextParser.Texts;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;

namespace TextParser.TextCreation.TextParsing
{
        public class Parser
        {
            private SeparatorContainer separatorContainer;

            protected SeparatorContainer SeparatorContainer
            {
                get { return separatorContainer; }
                set { separatorContainer = value; }
            }
            private StringParser sentenceParser;
            protected StringParser SentenceParser
            {
                get { return sentenceParser; }
                set { sentenceParser = value; }
            }
            public Parser(SeparatorContainer separatorContainer)
            {
                this.SeparatorContainer = separatorContainer;
                this.SentenceParser = new StringParser(separatorContainer);
            }

            public Text Parse(TextReader reader)
            {
                var orderedSentenceSeparators = SeparatorContainer.SentenceSeparators().OrderByDescending(x => x.Length).ToArray();
                int bufferlength = 10000;
                Text textResult = new Text();
                StringBuilder buffer = new StringBuilder(bufferlength);

                buffer.Clear();
                string currentString = reader.ReadLine();
                while (currentString != null)
                {
                    int firstSentenceSeparatorOccurence = -1;
                    string firstSentenceSeparator = orderedSentenceSeparators.FirstOrDefault(
                        x =>
                        {
                            firstSentenceSeparatorOccurence = currentString.IndexOf(x);
                            return firstSentenceSeparatorOccurence >= 0;
                        });
                    if (firstSentenceSeparator != null)
                    {
                        buffer.Append(currentString.Substring(0, firstSentenceSeparatorOccurence + firstSentenceSeparator.Length));
                        textResult.Sentences.Add(SentenceParser.ParseSentence(buffer.ToString()));
                        buffer.Clear();
                        buffer.Append(currentString.Substring(firstSentenceSeparatorOccurence + firstSentenceSeparator.Length - 1, currentString.Length - 1 - firstSentenceSeparatorOccurence + firstSentenceSeparator.Length - 1));
                    }
                    else
                    {
                        buffer.Append(" ");
                        buffer.Append(currentString);
                        buffer.Append(" ");
                    }
                    currentString = reader.ReadLine();
                }
                return textResult;
            }

        }
}
