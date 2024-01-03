using MusicTasteJudger;

namespace music_taste_judger_tests
{
    /// <summary>
    /// An nunit class to test the ArtistDictionary Type.
    /// </summary>
    public class ArtistDictionaryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test to verify that an AritstDictionary can be built
        /// with its Dictionary inside of it.
        /// </summary>
        [Test]
        public void TestArtistDictionaryInstantiationDefault()
        {
            ArtistDictionary testArtistDictionary = new(@"..\..\..\test_data\test_json.json");
            Dictionary<string, MusicalArtist> artists = testArtistDictionary.Artists;
            Assert.Multiple(() =>
            {
                Assert.That(testArtistDictionary, Is.InstanceOf<ArtistDictionary>());
                Assert.That(artists, Is.InstanceOf<Dictionary<string, MusicalArtist>>());
            });
        }
    }
}