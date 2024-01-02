using static System.Console;
using Newtonsoft.Json;
namespace MusicTasteJudger
{
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