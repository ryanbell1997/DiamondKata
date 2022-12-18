using DiamondKata.Creators;
using FluentAssertions;
using Xunit;

namespace DiamondKata.Tests
{
    public class DiamondCreatorTests
    {
        private readonly DiamondCreator _subject = new();

        [Fact]
        public void AmmendPreviousDiamondLines_ShouldCorrectlyPrefixAndSuffixWithSpaces()
        {
            _subject.LineDictionary.Add(1, "B");

            _subject.AmendPreviousDiamondLines();

            _subject.LineDictionary[1].Should().Be(" B ");
            _subject.LineDictionary.Count.Should().Be(1);
        }

        [Fact]
        public void CreateLineUsingDictionaryLength_ShouldCreateLineCorrectly()
        {
            _subject.LineDictionary.Add(1, "A");
            _subject.LineDictionary.Add(2, "B B");

            var res  = _subject.CreateLineUsingDictionaryLength('H');

            res.Should().Be("H   H");
        }
    }
}
