using DiamondKata.Creators;
using DiamondKata.Interfaces;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace DiamondKata.Tests
{
    public class ShapeCreatorTests
    {
        private readonly IShapeCreator _subject;
        public ShapeCreatorTests()
        {
            _subject = new DiamondCreator();
        }

        [Fact]
        public void AddChar_AddsToLineDictionary()
        {
            //Act
            _subject.AddChar('H');

            //Assert
            _subject.LineDictionary.Should().NotBeNull();
            _subject.LineDictionary.Count.Should().NotBe(0);
            _subject.LineDictionary[1].Should().Be("H");
        }

        [Fact]
        public void AddChar_AddsMultipleLinesCorrectly()
        {
            var dataList = new List<CharAndExepected>()
            {
                new(){ Character = 'H', Expected = "   H   "},
                new(){ Character = 'B', Expected = "  B B  "},
                new(){ Character = 'C', Expected = " C   C "},
                new(){ Character = 'D', Expected = "D     D"}
            };

            foreach(var data in dataList)
            {
                _subject.AddChar(data.Character);
            }

            _subject.LineDictionary[1].Should().Be(dataList[0].Expected);
            _subject.LineDictionary[2].Should().Be(dataList[1].Expected);
            _subject.LineDictionary[3].Should().Be(dataList[2].Expected);
            _subject.LineDictionary[4].Should().Be(dataList[3].Expected);
        }

        [Fact]
        public void CreateLine_FirstEntryShouldBeTheString()
        {
            //Act
            var result = _subject.CreateLine('H');

            //Assert
            result.Should().Be("H");
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData('C', 2, "C   C")]
        [InlineData('C', 3, "C     C")]
        [InlineData('D', 4, "D       D")]
        [InlineData('A', 1, "A A")]
        public void CreateLine_CreatesStringCorrectly(char character, int dictionarySetupLength, string expected)
        {
            for(int i = 0; i < dictionarySetupLength; i++)
            {
                _subject.LineDictionary.Add(i, "Anything");
            }

           var result = _subject.CreateLine(character);

            result.Should().Be(expected);
        }

        private class CharAndExepected
        {
            public char Character { get; set; }
            public string Expected { get; set; } = string.Empty;
        }
    }
}
