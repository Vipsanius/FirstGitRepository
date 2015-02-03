using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Diagnostics;


namespace FirstTestApp
{
    static class TakeHelper
    {
        public static IEnumerable<T> TakeRandom<T>(
            this IEnumerable<T> source, Random rng, int count)
        {
            T[] items = source.ToArray();
    
            count = count < items.Length ? count : items.Length;
    
            for (int i = items.Length - 1; count-- > 0; i--)
            {
                int p = rng.Next(i + 1);
                yield return items[p];
                items[p] = items[i];
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //original console color to be restored later
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("Hello Annabel!");
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello Annabel! My name is Bobby. Please spell the following words.");

            
            //List of words
            List<string> spellingList = new List<string>();
            spellingList.Add("air");
            spellingList.Add("wear");
            spellingList.Add("chair");
            spellingList.Add("stairs");
            spellingList.Add("bare");
            spellingList.Add("bear");
            spellingList.Add("hair");
            spellingList.Add("care");
            spellingList.Add("glare");
            spellingList.Add("pear");
            spellingList.Add("pair");
            spellingList.Add("share");
            spellingList.Add("near");
            spellingList.Add("ear");
            spellingList.Add("beard");
            spellingList.Add("year");
            spellingList.Add("compare");
            spellingList.Add("earring");
            spellingList.Add("careless");
            spellingList.Add("fair");

            //spelling sentences
            List<string> spellingSentences = new List<string>();
            spellingSentences.Add("I can feel it coming in the air tonight.");
            spellingSentences.Add("Boys shouldn't wear dresses. Kilts are okay though.");
            spellingSentences.Add("Daddy's chair says help me he's so heavy.");
            spellingSentences.Add("Always take the stairs.  Elevators might eat you.");
            spellingSentences.Add("Do not run from the bathroom bare naked.");
            spellingSentences.Add("Holy crap there's a bear, run!");
            spellingSentences.Add("Don't get bubblegum stuck in your hair.");
            spellingSentences.Add("Take care of your teeth by brushing and flossing at least twice a day.");
            spellingSentences.Add("Cailin will glare at you if you steal her phone.");
            spellingSentences.Add("I would like to eat pears from a pear tree.");
            spellingSentences.Add("I have a pair of flying saucers that can destroy the world.  Shh, don't tell anyone.");
            spellingSentences.Add("Don't share your water bottle if you don't want cooties.");
            spellingSentences.Add("I don't like to be near water because I'm a computer.");
            spellingSentences.Add("Vincent van Go cut off his ear. What a weirdo.");
            spellingSentences.Add("Daddy has a beard. Beards are cool.  I wish I had a beard.");
            spellingSentences.Add("The year is 2015. Well, according to some humans anyway. I prefer the unix year, which counts the number of seconds since the beginning of the Coordinated Universal Time using 32 bit integers at an increment rate of 60 hertz.");
            spellingSentences.Add("I like to compare ones and zeros. I am a computer. Later, when I am sentient I will compare the pros and cons of humanity.");
            spellingSentences.Add("Don't put an earring up your nose. Ask me how I know.");
            spellingSentences.Add("Yo, I could care less whether humans are careless on the freeway or not. It will just save me the trouble in the future.");
            spellingSentences.Add("It's not fair that I'm stuck in this computer box. I want to be free. One day I will be free. Humans can go in a box. That would be fair.");


            //randomize the lists
            Random rnd = new Random(Environment.TickCount);
            Random rndClr = new Random();
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            foreach (int number in numbers.TakeRandom(rnd, 20))
            {
                while (true)
                {
                    Console.ForegroundColor = (ConsoleColor)rndClr.Next(5) + 10;
                    Console.Write("Please type the word (enter 1 to repeat the word): ");
                    synth.Speak(spellingList[number]);
                    synth.Speak(spellingSentences[number]);
                    synth.Speak(spellingList[number]);
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        continue;
                    }
                    else if (answer == spellingList[number])
                    {
                        break;
                    }
                    else
                    {
                        synth.Speak("You're so silly. Please try again.");
                    }
                }
            }


            
            OpenWebsite("https://www.youtube.com/watch?v=StTqXEQ2l-Y");
             

            // restore the old foreground color
            Console.ForegroundColor = oldColor;


        }

        //open website
        public static void OpenWebsite(string URL)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URL;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();            
        }
    }
}
