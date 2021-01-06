using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Texts.TextItems.Sentences;

namespace TextParser.Texts
{
    public class Text
    {
        public List<ISentence> Sentences { get; set; }
        public Text()
        {
            Sentences = new List<ISentence>();
        }
        public bool RemoveEmtySentences()
        {
            var res = Sentences.RemoveAll(x => x.Count == 0);
            return res != 0;
        }
    }
}
