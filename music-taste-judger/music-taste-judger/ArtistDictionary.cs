using static System.Console;
using Newtonsoft.Json;
namespace MusicTasteJudger
{
    /// <summary>
    /// A class to generate and encapsulate an Diciontary of artists.
    /// </summary>
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
        /// <summary>
        /// Default Constructor for the ArtistDictionary class.
        /// </summary>
        public ArtistDictionary ()
        {
            _artistsDict = new();
            _artistList = new();
            _jsonFilePath = @"..\..\..\test_json.json";
            ReadJSONFile();
            BuildArtistDictionary();
            
        }
        /// <summary>
        /// This method reads the JSON file.
        /// </summary>
        public void ReadJSONFile()
        {
            var jsonFileSerializer = new JsonSerializer();
            using var jsonStreamReader = new StreamReader(_jsonFilePath);
            using var jsonDataReader = new JsonTextReader(jsonStreamReader);
            _artistList = jsonFileSerializer.Deserialize<List<MusicalArtist>>(jsonDataReader);
        }
        /// <summary>
        /// This method builds the actual dictionary of artists.
        /// </summary>
        /// <exception cref="Exception">An exception thrown if an artist or list of artists is null.</exception>
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
                            // WriteLine($"Loading Artist: {artist}");
                            _artistsDict.Add(artist.ExpectedKey, artist);
                        }
                        catch (NullReferenceException)
                        {
                            WriteLine($"Artist is skipped because artist name is null. \n {artist}");
                        }
                        catch (ArgumentException)
                        {
                            WriteLine("There is a duplicate key in your list.");
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
        /// <summary>
        /// This is a temporary method to generate a dictionary of artists. Useful for testing.
        /// </summary>
        /// <returns>A Dictionary Collection of MusicalArtist objects with a string key representing the band name.</returns>
        public Dictionary<string, MusicalArtist> GenerateTestArtists()
        {
            Dictionary<string, MusicalArtist> testArtists = new();
            try
            {
                testArtists.Add("carpenter brut", new MusicalArtist("Carpenter Brut", 9.0m, "Very good, very aggressive and clearly an genre leader."));
                testArtists.Add("scandroid", new MusicalArtist("Scandroid", 8.0m, "First two albums are incredible, but I fell off after that"));
                testArtists.Add("dance with the dead", new MusicalArtist("Dance With The Dead", 8.0m, "First few albums were great. I Fell off after that."));
                testArtists.Add("twrp", new MusicalArtist("TWRP", 9.0m, "Amazing Live, Very Talented Musicians."));
                testArtists.Add("magic sword", new MusicalArtist("Magic Sword", 6.0m, "They put on a surprisingly good live show."));
                testArtists.Add("michael oakley", new MusicalArtist("Michael Oakley", 7.0m, "Has some really good tracks, Reminds me of George Michael."));
                testArtists.Add("lazerhawk", new MusicalArtist("LazerHawk", 4.0m, "Not a big fan of their music."));
                testArtists.Add("timecop1983", new MusicalArtist("TimeCop1983", 1.0m, "Never listened to their stuff much."));
                testArtists.Add("d.notive", new MusicalArtist("d.notive", 9.0m, "Pretty good, some catchy stuff for an indie synthwave artist. Personable as well."));
                testArtists.Add("jamievx", new MusicalArtist("JAMIEvx", 8.0m, "Another good indie synthwave artist I discovered through bandcamp."));
            }
            catch (ArgumentException)
            {
                WriteLine("There is a duplicate key in your list.");
            }
            return testArtists;
        }
    }
}