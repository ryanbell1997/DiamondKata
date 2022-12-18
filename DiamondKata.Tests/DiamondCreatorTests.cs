using DiamondKata.Creators;
using FluentAssertions;
using Xunit;

namespace DiamondKata.Tests
{
    public class DiamondCreatorTests
    {
        DiamondCreator subject = new();

        [Theory]
        [InlineData("_BAAAB_", "AAA")]
        [InlineData(" C   C ", "   ")]
        [InlineData(" L     A         A         L ", "     A         A         ")]
        public void GetPreviousStringCentreSpaces_CorrectlyReturnsCentralSpace(string input, string expected)
        {
            var res = subject.GetPreviousStringCentreSpaces(input);

            res.Should().Be(expected);
        }

        [Fact]
        public void AmmendPreviousDiamondLines_ShouldCorrectlyPrefixAndSuffixWithSpaces()
        {
            subject.LineDictionary.Add(1, "B");

            subject.AmmendPreviousDiamondLines();

            subject.LineDictionary[1].Should().Be(" B ");
            subject.LineDictionary.Count.Should().Be(1);
        }

        [Theory]
        [InlineData(" B   B ", 'H', "H     H")]
        [InlineData(" C       C ", 'H', "H         H")]
        public void CreateLineUsingDictionaryLength_ShouldCreateLineCorrectly(string dictionaryInput, char character, string expected)
        {
            subject.LineDictionary.Add(1, dictionaryInput);

            var res  = subject.CreateLineUsingDictionaryLength(character);

            res.Should().Be(expected);
        }
    }
}
