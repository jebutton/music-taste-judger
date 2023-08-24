using System.CodeDom.Compiler;
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
        public static void Main()
        {
            WriteLine("Hello Cyberpunk Boy, Girl, or Hacker");
            bool bandFound = false;
            // Generate the list of artists for Testing.
            Dictionary<string, MusicalArtist> artists = GenerateArtists();
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
                    try
                    {
                        MusicalArtist searchResult = artists[band.ToLower()];
                        WriteLine(searchResult.GetFullReview());
                        bandFound = true;
                    }
                    catch (KeyNotFoundException)
                    {
                        WriteLine("Artist / Band is not found. Try again.");
                    }
                }
            } while (!bandFound);
            Console.ReadKey();
        }
        /// <summary>
        /// This is a temporary method to generate a dictionary of artists. 
        /// Eventually this will be replaced by pulling the artists from a file.
        /// </summary>
        /// <returns>A Dictionary Collection of MusicalArtist objects with a string key representing the band name.</returns>
        private static Dictionary<string, MusicalArtist> GenerateArtists()
        {
            Dictionary<string, MusicalArtist> artists = new ();
            try
            {
                artists.Add("carpenter brut", new MusicalArtist("Carpenter Brut", 9.0m, "Very good, very aggressive and clearly an genre leader."));
                artists.Add("scandroid", new MusicalArtist("Scandroid", 8.0m, "First two albums are incredible, but I fell off after that"));
                artists.Add("dance with the dead", new MusicalArtist("Dance With The Dead", 8.0m, "First few albums were great. I Fell off after that."));
                artists.Add("twrp", new MusicalArtist("TWRP", 9.0m, "Amazing Live, Very Talented Musicians."));
                artists.Add("magic sword", new MusicalArtist("Magic Sword", 6.0m, "They put on a surprisingly good live show."));
                artists.Add("michael oakley", new MusicalArtist("Michael Oakley", 7.0m, "Has some really good tracks, Reminds me of George Michael."));
                artists.Add("lazerhawk", new MusicalArtist("LazerHawk", 4.0m, "Not a big fan of their music."));
                artists.Add("timecop1983", new MusicalArtist("TimeCop1983", 1.0m, "Never listened to their stuff much."));
                artists.Add("d.notive", new MusicalArtist("d.notive", 9.0m, "Pretty good, some catchy stuff for an indie synthwave artist. Personable as well."));
                artists.Add("jamievx", new MusicalArtist("JAMIEvx", 8.0m, "Another good indie synthwave artist I discovered through bandcamp."));
            }
            catch (ArgumentException)
            {
                WriteLine("There is a duplicate key in your list.");
            }
            return artists;
        } 
    }
    /// <summary>
    /// This is a class to repressent a Musical Artist. It contains some key values about them.
    /// </summary>
    public class MusicalArtist
    {
        private string? artistName;
        private decimal artistScore;
        private string? artistReview;
        /// <summary>
        /// Constructor with all private fields.
        /// </summary>
        /// <param name="name">The Name of the Artist</param>
        /// <param name="score">The Score of the Artist</param>
        /// <param name="review"> The Review of the Artist</param>
        public MusicalArtist(string name, decimal score, string review) { 
            artistName = name;
            artistScore = score;
            artistReview = review;
        }
        /// <summary>
        /// Constructor without the review.
        /// </summary>
        /// <param name="name">The Name of the Artist</param>
        /// <param name="score">The Score of the Artist</param>
        public MusicalArtist(string name, decimal score)
        {
            artistName = name;
            artistScore = score;
            GenerateReview();
        }
        /// <summary>
        /// For expansion later. This will eventually generate a review
        /// for artists that I don't know about.
        /// </summary>
        private void GenerateReview()
        {
            artistReview = "This will be Expanded Later";
        }
        /// <summary>
        /// Returns a well structured review.
        /// </summary>
        /// <returns>A string containing a review.</returns>
        public string GetFullReview()
        {
            string fullReview = $"The artist {artistName} has an index score of {artistScore} and my opinion of them is: {artistReview}";
            return fullReview;
        }
    }
}