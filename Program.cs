using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;


namespace Lab1
{
    class Program
    {
        public static List<string> Ilist = new List<string>();
        public static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            bool t = true;
            do
            {

                Console.WriteLine("Hello World!!! My First C# App");
                Console.WriteLine("Options");
                Console.WriteLine("------------");
                Console.WriteLine("1 - Import Words from File");
                Console.WriteLine("2 - Bubble Sort words");
                Console.WriteLine("3 - LINQ/Lambda sort words");
                Console.WriteLine("4 - Count the Distinct Words");
                Console.WriteLine("5 - Take the first 10 words");
                Console.WriteLine("6 - Get the number of words that start with 'j' and display the count");
                Console.WriteLine("7 - Get and display of words that end with 'd' and display the count");
                Console.WriteLine("8 - Get and display of words that are greater than 4 characters long, and display the count");
                Console.WriteLine("9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count");
                Console.WriteLine("x - Exit");

                Console.Write("Make a selection:");
                string selection = Console.ReadLine();

                Console.Clear();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Reading Words");
                        Console.WriteLine("Reading Words complete");
                        Console.WriteLine("Number of words found: " + wordcount() + "\n");
                        break;
                    case "2":
                        Ilist.Clear();
                        readFile();
                        bubbleSort(Ilist);
                        // Ilist.ForEach(Console.WriteLine);
                        break;
                    case "3":
                        Ilist.Clear();
                        readFile();
                        LambdaSort();
                        break;
                    case "4":
                        Ilist.Clear();
                        readFile();
                        Distinctwords();
                        break;
                    case "5":
                        Ilist.Clear();
                        readFile();
                        FirstTenWords();
                        break;
                    case "6":
                        Ilist.Clear();
                        readFile();
                        JWords();
                        break;
                    case "7":
                        Ilist.Clear();
                        readFile();
                        DWords();
                        break;
                    case "8":
                        Ilist.Clear();
                        readFile();
                        FourChars();
                        break;
                    case "9":
                        Ilist.Clear();
                        readFile();
                        ThreeChars();
                        break;
                    case "x":
                        t = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input" + "\r\n\r\n");
                        break;
                }

            }
            while (t);

            //Import words from the file
            void readFile()
            {
                //ArrayList Ilist = new ArrayList();
                String line;
                int numwords = 0;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader("C:\\Words.txt");
                    //Read the first line of text
                    line = sr.ReadLine();

                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        //Console.WriteLine(line);   //prints words to screen!!!
                        //Read the next line
                        Ilist.Add(line);
                        line = sr.ReadLine();

                        numwords++;

                    }
                    //close the file
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

            }
            //Return the number of words from the words.txt
            int wordcount()
            {
                //ArrayList Ilist = new ArrayList();
                String line;
                int numwords = 0;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader("C:\\Words.txt");
                    //Read the first line of text
                    line = sr.ReadLine();

                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        //Console.WriteLine(line);   //prints words to screen!!!
                        //Read the next line
                        Ilist.Add(line);
                        line = sr.ReadLine();

                        numwords++;

                    }
                    //close the file
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                return numwords;
            }

            //Bubble Sort for the  Words.txt
            static string[] bubbleSort(List<string> words)
            {
                stopwatch.Start();

                for (int i = 1; i < words.Count; i++)
                {
                    for (int j = 0; j < (words.Count - i); j++)
                    {
                        if (words[j + 1].CompareTo(words[j]) < 0)
                        {
                            string temp = words[j + 1];
                            words[j + 1] = words[j];
                            words[j] = temp;
                        }
                    }
                }
                stopwatch.Stop();
                Console.Write("Time elapsed: " + stopwatch.ElapsedMilliseconds + "ms" + "\r\n\r\n");
                return words.ToArray();

            }

            //LINQ/Lambda sort words using in a built C# sort method
            void LambdaSort()
            {
                stopwatch.Start();
                new List<string>(Ilist).Sort();
                stopwatch.Stop();
                Console.Write("Time elapsed: " + stopwatch.ElapsedMilliseconds + "ms" + "\r\n\r\n");
            }

            //Count the distinct words in the words.txt
            void Distinctwords()
            {
                Console.WriteLine("The number of distinct words is: " + Ilist.Distinct<string>().Count<string>() + "\r\n\r\n");
            }

            //Return the first 10 words in words.txt
            void FirstTenWords()
            {
                var words = Ilist.Take(10);
                foreach (var topWords in words)
                {
                    Console.WriteLine(topWords);
                }
                Console.WriteLine("\r\n\r\n");
            }

            //Return the number of words with the letter 'J' 
            void JWords()
            {
                var temp = from wList in Ilist where wList.StartsWith("j") select wList;
                int count = 0;
                foreach (var tWords in temp)
                {
                    Console.WriteLine(tWords);
                    count++;
                }
                Console.WriteLine("Number of words that start with 'j': " + count + "\r\n\r\n");
            }

            //Return the number of words with the letter 'D'
            void DWords()
            {
                var temp = from wList in Ilist where wList.EndsWith("d") select wList;
                int count = 0;
                foreach (var tWords in temp)
                {
                    Console.WriteLine(tWords);
                    count++;
                }
                Console.WriteLine("Number of words that start with 'd': " + count + "\r\n\r\n");
            }

            //Return words that are greater than 4 characters 
            void FourChars()
            {
                var temp = Ilist.Where(w => w.Length > 4);
                int count = 0;
                foreach (var tWords in temp)
                {
                    Console.WriteLine(tWords);
                    count++;
                }
                Console.WriteLine("Number of words that are greater than 4 characters long: " + count + "\r\n\r\n");
            }

            //Return words that are less than 3 characters
            void ThreeChars()
            {
                var temp = from tWords in Ilist where tWords.Length < 3 && tWords.StartsWith("a") select tWords;
                int count = 0;

                foreach (var a in temp)
                {
                    Console.WriteLine(a);
                    count++;
                }
                Console.WriteLine("Number of words that are less than 3 characters long and start with 'a': " + count + "\r\n\r\n");
            }
        }
    }

}
