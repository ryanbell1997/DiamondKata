using DiamondKata.Creators;
using FluentAssertions;
using Xunit;

namespace DiamondKata.Tests
{
    public class DiamondCreatorTests
    {
        private readonly DiamondCreator _subject = new();

        [Theory]
        [InlineData("_BAAAB_", "AAA")]
        [InlineData(" C   C ", "   ")]
        [InlineData(" L     A         A         L ", "     A         A         ")]
        public void GetPreviousStringCentreSpaces_CorrectlyReturnsCentralSpace(string input, string expected)
        {
            var res = _subject.GetPreviousStringCentreSpaces(input);

            res.Should().Be(expected);
        }

        [Fact]
        public void AmmendPreviousDiamondLines_ShouldCorrectlyPrefixAndSuffixWithSpaces()
        {
            _subject.LineDictionary.Add(1, "B");

            _subject.AmendPreviousDiamondLines();

            _subject.LineDictionary[1].Should().Be(" B ");
            _subject.LineDictionary.Count.Should().Be(1);
        }

        [Theory]
        [InlineData(" B   B ", 'H', "H     H")]
        [InlineData(" C       C ", 'H', "H         H")]
        public void CreateLineUsingDictionaryLength_ShouldCreateLineCorrectly(string dictionaryInput, char character, string expected)
        {
            _subject.LineDictionary.Add(1, "A");
            _subject.LineDictionary.Add(2, "B B");

            var res  = _subject.CreateLineUsingDictionaryLength('H');

            res.Should().Be(expected);
        }
    }
}
