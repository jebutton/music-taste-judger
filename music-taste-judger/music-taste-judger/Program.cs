/*
 * This is a program created by Jacqueline Button 
 * to allow her to work on implementing features of C#
 * into a working program that isn't just a set of individual
 * Exercises. This code will be improved overtime as she learns more.
 */
using static System.Console;
class Program
{
    public static void Main()
    {
        WriteLine("Hello Cyberpunk Boy, Girl, or Hacker");
        bool bandFound = false;
        do
        {
            Write("Please Enter A Good Synthwave Artist: ");
            string? band = ReadLine();
            if (band == null)
            {
                WriteLine("Response is empty or null");
            }
            else
            {
                switch (band.ToLower())
                {
                    case "carpenter brut":
                        Console.WriteLine("Very good, very aggressive and clearly an genre leader.");
                        bandFound = true;
                        break;
                    case "scandroid":
                        Console.WriteLine("First two albums are incredible, but I fell off after that");
                        bandFound = true;
                        break;
                    case "dance with the dead":
                        Console.WriteLine("First few albums were great. I Fell off after that.");
                        bandFound = true;
                        break;
                    case "twrp":
                        Console.WriteLine("Amazing Live, Very Talented Musicians.");
                        bandFound = true;
                        break;
                    case "magic sword":
                        Console.WriteLine("They put on a great live show.");
                        bandFound = true;
                        break;
                    case "michael oakley":
                        Console.WriteLine("Pretty good, very layered music, Reminds me of George Michael");
                        bandFound = true;
                        break;
                    case "lazerhawk":
                        Console.WriteLine("Music has too much vamping for my tastes.");
                        bandFound = true;
                        break;
                    case "timecop1983":
                        Console.WriteLine("Never Listened to their stuff much");
                        bandFound = true;
                        break;
                    case "d.notive":
                        Console.WriteLine("Pretty good, some catchy stuff for an indie synthwave artist. Personable as well.");
                        bandFound = true;
                        break;
                    case "jamievx":
                        Console.WriteLine("Another good indie synthwave artist I discovered through bandcamp.");
                        bandFound = true;
                        break;
                    default:
                        Console.WriteLine("Band not in the list. \n");
                        break;
                }
            }
        } while (!bandFound);
        Console.ReadKey();
    }
}


