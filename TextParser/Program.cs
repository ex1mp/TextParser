using System;
using System.Collections.Generic;
using System.IO;
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

            string path = "C:/Users/Niko/Desktop/file.txt";
            FileInfo myFile = new FileInfo(path);
            FileStream fs = myFile.OpenRead();
            TextReader myReader = new StreamReader(fs);
            SeparatorContainer cont = new SeparatorContainer();

            Parser pars = new Parser(cont);
            Text text = pars.Parse(myReader);
            foreach (var item in text.Sentences)
            {
                foreach (var it in item)
                {
                    Console.Write(it.Chars + " ");
                }
                Console.WriteLine("\r\n+++++++++++");
            }
            TextHandler th = new TextHandler(cont);
            text.Sentences[5] = th.WordReplacing(text.Sentences[7], 1, "*не, ну а что такое, а*");
            foreach (var item in text.Sentences.ToArray())
            {
                Console.WriteLine("\r\n**************");
                foreach (var it in item)
                {
                    Console.Write(it.Chars + " ");
                }
                Console.WriteLine("\r\n************************");
            }
            foreach (var items in th.SortSentencesByWordCount(text))
            {
                foreach (var item in items.sentenceItems)
                {
                    Console.Write(item.Chars + " ");
                }
                Console.WriteLine("\r\n==================");
            }
            th.StartWithConsonantDelite(ref text, 6);
            foreach (var item in text.Sentences.ToArray())
            {
                foreach (var it in item)
                {
                    Console.Write(it.Chars + " ");
                }
                Console.WriteLine("\r\n+++++++++++");
            }
            text.RemoveEmtySentences();
            foreach (var item in text.Sentences.ToArray())
            {
                Console.WriteLine("\r\n^^^^^^^^^^^^^^^");
                foreach (var it in item)
                {
                    Console.Write(it.Chars + " ");
                }
                Console.WriteLine("\r\n^^^^^^^^^^^^^^^");
            }

            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            List<int> ll = new List<int>();
            ll.Add(0);
            ll.Add(0);
            ll.Add(0);
            ll.Add(0);
            //for (int i  = l.Count-1; i>=0 ; i--)
            //{
            //    Console.WriteLine(l[i]);
            //}
            l.RemoveAt(2);
            l.InsertRange(2, ll);
            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i]);
            }
            Console.ReadLine();

        }
    }
}
