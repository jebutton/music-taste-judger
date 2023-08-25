using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using static System.Console;
using Newtonsoft.Json;
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
            ArtistDictionary artistDictionary = new();
            Dictionary<string, MusicalArtist> artists = artistDictionary.Artists;

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
        private static Dictionary<string, MusicalArtist> GenerateArtistsFromJSON()
        {
            Dictionary<string, MusicalArtist> artists = new();
           
            return artists;
        }
    }
    public class ArtistDictionary
    {
        private Dictionary<string, MusicalArtist> _artistsDict;
        private List<MusicalArtist>? _artistList;
        private readonly string _jsonFilePath;
        public Dictionary<string, MusicalArtist> Artists
        {
            get => _artistsDict;
            set => _artistsDict = value;
        }
        public ArtistDictionary ()
        {
            _artistsDict = new();
            _artistList = new();
            _jsonFilePath = @"..\..\..\test_json.json";
            ReadJSONFile();
            BuildArtistDictionary();
            
        }
        public void ReadJSONFile()
        {
            var jsonFileSerializer = new JsonSerializer();
            using var jsonStreamReader = new StreamReader(_jsonFilePath);
            using var jsonDataReader = new JsonTextReader(jsonStreamReader);
            _artistList = jsonFileSerializer.Deserialize<List<MusicalArtist>>(jsonDataReader);
        }
        public void BuildArtistDictionary()
        {
            if (_artistList != null)
            {
                foreach (var artist in _artistList)
                {
                    if (artist.ExpectedKey != null)
                    {
                        try
                        {
                            WriteLine($"Loading Artist: {artist}");
                            _artistsDict.Add(artist.ExpectedKey, artist);
                        }
                        catch (NullReferenceException)
                        {
                            WriteLine($"Artist is skipped because artist name is null. \n {artist}");
                        }
                    }
                }
            }
            else
            {
                WriteLine("Error Loading JSON File into Artists. The data is null.");
                throw new Exception("Artist List is null");
            }
        }

    }
    /// <summary>
    /// This is a class to repressent a Musical Artist. It contains some key values about them.
    /// </summary>
    public class MusicalArtist
    {
        private string? _artistName;
        private decimal _artistScore;
        private string? _artistReview;
        public string? ArtistName
        {
            get => _artistName; 
            set => _artistName = value;
        }
        public decimal ArtistScore
        {
            get => _artistScore; 
            set => _artistScore = value;
        }
        public string? ArtistReview
        {
            get => _artistReview;
            set =>  _artistReview = value;
        }
        public string? ExpectedKey;
        /// <summary>
        /// Constructor with all private fields.
        /// </summary>
        /// <param name="name">The Name of the Artist</param>
        /// <param name="score">The Score of the Artist</param>
        /// <param name="review"> The Review of the Artist</param>
        [JsonConstructor]
        public MusicalArtist(string artistName, decimal artistScore, string artistReview) { 
            _artistName = artistName;
            _artistScore = artistScore;
            _artistReview = artistReview;
            GenerateExpectedKey();
        }
        /// <summary>
        /// Constructor without the review.
        /// </summary>
        /// <param name="name">The Name of the Artist</param>
        /// <param name="score">The Score of the Artist</param>
        public MusicalArtist(string name, decimal score)
        {
            _artistName = name;
            _artistScore = score;
            GenerateReview();
            GenerateExpectedKey();
        }
        /// <summary>
        /// For expansion later. This will eventually generate a review
        /// for artists that I don't know about.
        /// </summary>
        private void GenerateReview()
        {
            _artistReview = "This will be Expanded Later";
        }
        /// <summary>
        /// Returns a well structured review.
        /// </summary>
        /// <returns>A string containing a review.</returns>
        public string GetFullReview()
        {
            string fullReview = $"The artist {_artistName} has an index score of {_artistScore} and my opinion of them is: {_artistReview}";
            return fullReview;
        }
        public void GenerateExpectedKey()
        {
            if (_artistName != null)
            {
                ExpectedKey = _artistName.ToLower();
            }
            else
            {
                WriteLine("Artist name is null, can't generate key.");
            }
        }
        /// <summary>
        /// Just your standard Equals() method.
        /// </summary>
        /// <param name="obj">The object you're comparing against.</param>
        /// <returns>A bool representing whether it is equal or not.</returns>
        public override bool Equals(object? obj)
        {
            return obj is MusicalArtist artist &&
                   _artistName == artist._artistName &&
                   _artistScore == artist._artistScore &&
                   _artistReview == artist._artistReview;
        }
        /// <summary>
        /// Just your standard GetHashCode() method. 
        /// </summary>
        /// <returns>An int representing the hashcode of the object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_artistName, _artistScore, _artistReview);
        }
        /// <summary>
        /// Standard ToString() method.
        /// </summary>
        /// <returns>A string representation of a Musical Artist</returns>
        public override string? ToString()
        {
            string stringRepresentation = $"| Type: MusicalArtist | Artist Name: {_artistName} | Artist Score: {_artistScore} | Artist Review: {_artistReview} |";
            return stringRepresentation;
        }
    }
}