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

        [Fact]
        public void CreateLineUsingDictionaryLength_ShouldCreateLineCorrectly()
        {
            subject.LineDictionary.Add(1, "A");
            subject.LineDictionary.Add(2, "B B");

            var res  = subject.CreateLineUsingDictionaryLength('H');

            res.Should().Be("H   H");
        }
    }
}
