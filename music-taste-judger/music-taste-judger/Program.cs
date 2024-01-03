using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using static System.Console;
namespace MusicTasteJudger
{
    /// <summary>
    /// This is a program to judge someone's taste in synthwave music via an interactive console app.
    /// </summary>
    /// <remarks>
    /// This is a program created by Jacqueline Button 
    /// to allow her to work on implementing features of C# into a working program
    /// that isn't just a set of individual Exercises. 
    /// This code will be improved overtime as she learns more.
    /// </remarks>
    class Program
    {
        /// <summary>
        /// Main Method When Executed.
        /// </summary>
        public static void Main()
        {
            WriteLine("Hello Cyberpunk Boy, Girl, or Hacker");
            bool bandFound = false;
            // Generate the list of artists for Testing.
            //Dictionary<string, MusicalArtist> artists = GenerateArtists();
            ArtistDictionary artistDictionary = new(@"..\..\..\test_json.json");
            Dictionary<string, MusicalArtist> artists = artistDictionary.Artists;
            do
            {
                Write("Please Enter A Good Synthwave Artist: ");
                string? band = ReadLine();
                if (band == null)
                {
                    WriteLine("Response is empty or null");
                }
                else if (band == "load_test_data")
                {
                    artists = artistDictionary.GenerateTestArtists();
                }
                else
                {
                    try
                    {
                        MusicalArtist searchResult = artists[band.ToLower()];
 
                        WriteLine(searchResult.GetFullReview());
                        bandFound = true;
                    }
                    catch (KeyNotFoundException)
                    {
                        WriteLine("Artist / Band is not found. Try again or enter load_test_data to load standard sample data");
                    }
                }
            } while (!bandFound);
            Console.ReadKey();
        }
    }
}