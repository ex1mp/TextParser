using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Texts;
using System.IO;
using TextParser.Texts.TextItems.Sentences.SentenceItems.ImplementingClasses.Punctuations;
using TextParser.TextCreation.TextParsing;
using System.Security;

namespace TextParser.TextCreation
{
    public class TextConverter
    {
        private string editFilePath;
        private string changedFilePath;
        private Parser parser;
        public TextConverter()
        {
            editFilePath = ConfigurationManager.AppSettings.Get("editFilePath");
            changedFilePath = ConfigurationManager.AppSettings.Get("changedFilePath");
            parser = new Parser(new SeparatorContainer());
        }
        public Text CreateText()
        {
           
            Text text=null;
            try
            {
                using (StreamReader textFile = new StreamReader(editFilePath))
                {
                    text = parser.Parse(textFile);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found: " + e.Message);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine("Invalid file path: " + e.Message);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("File path not specified: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(
                    "{0}: The write operation could not " +
                    "be performed because the specified " +
                    "part of the file is locked.",
                    e.GetType().Name);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

            return text;
        }
        public void SaveText(Text text)
        {
            try
            {
                using (StreamWriter textFile = new StreamWriter(changedFilePath))
                {
                    foreach (var sentence in text.Sentences)
                    {
                        textFile.WriteLine(sentence.SentenceInStringFormat());
                    }

                }
            }
            catch (UnauthorizedAccessException)
            {
                FileAttributes attr = (new FileInfo(changedFilePath)).Attributes;
                Console.Write("UnAuthorizedAccessException: Unable to access file. ");
                if ((attr & FileAttributes.ReadOnly) > 0)
                    Console.Write("The file is read-only.");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Invalid file path: " + e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("File path not specified: " + e.Message);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("path or fully qualified file name is longer than the system-defined maximum length");
            }
            catch (IOException e)
            {
                Console.WriteLine(
                    "{0}: The write operation could not " +
                    "be performed because the specified " +
                    "part of the file is locked.",
                    e.GetType().Name);
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Security Exception:\n\n{0}", e.Message);
            }


        }
    }
}
