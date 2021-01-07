using System;
using System.Collections.Generic;
using System.Text;
using TextParser.TextCreation;
using TextParser.TextProcessing;
using TextParser.Texts;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;


namespace TextParser.UserInteraction
{
    class MainControl
    {
        private TextConverter textConverter;
        private TextHandler textHandler;
        private Text text;
        public MainControl ()
        {
            textConverter = new TextConverter();
            textHandler = new TextHandler(new SeparatorContainer());
            text = textConverter.CreateText();
            MainMenu();
        }
        private int InputValidation(string message)
        {
            bool result = false;
            int item = 0;
            while (!result)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                result = int.TryParse(input, out item);
                if (!result)
                {
                    Console.WriteLine("Invalid value, please try again");
                }
                return item;

            }
            return 0;

        }
        public void Menu(ref bool isContine)
        {
            Console.WriteLine(" \r\n Choose one of the options below: ");
            Console.WriteLine(" 1. Output of text sentences by word count" +
                " \r\n 2. Find words of a given length in interrogative sentences" +
                " \r\n 3. Delete all words of a given length beginning with a consonant" +
                " \r\n 4. Replace words in the prefix with the specified substring " +
                " \r\n 5. Show Text" +
                " \r\n 7. Exit");
            switch (InputValidation(" Choose one of the items above"))
            {
                case 1:
                    foreach (var item in textHandler.SortSentencesByWordCount(text))
                    {
                        Console.WriteLine(item.SentenceInStringFormat());
                    }
                    break;
                case 2:
                    foreach (var item in textHandler.WordsInInterrogativeSentence(text, InputValidation("enter word length")))
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 3:
                    bool res = textHandler.StartWithConsonantDelite(ref text, InputValidation("enter word length"));
                    if (res)
                    {
                        Console.WriteLine(" Words found and deleted");
                    }
                    else
                    {
                        Console.WriteLine(" No matching words found");
                    }
                    break;
                case 4:
                    for (int i = 0; i < text.Sentences.Count; i++)
                    {
                        Console.WriteLine(i + text.Sentences[i].SentenceInStringFormat());
                    }
                    Console.WriteLine(" Enter an expression to replace the words");
                    var expr = Console.ReadLine();
                    var num = InputValidation(" Enther thr number of thr sentence");
                    text.Sentences[num] = textHandler.WordReplacing(text.Sentences[num],InputValidation(" Enter the length of the words to be replaced"), expr);
                    break;
                case 5:
                    foreach (var item in text.Sentences)
                    {
                        Console.WriteLine(item.SentenceInStringFormat());
                    }
                    break;
                case 6:
                    isContine = false;
                    break;
                default:
                    Console.WriteLine(" Command not recognized, please try again.");
                    break;

            }
        }
        public void MainMenu()
        {
            bool isContine = true;
            Console.WriteLine(" Welcome to the text editor menu. ");
            while (isContine)
            {
                Menu(ref isContine);
            }

        }
    }
}
