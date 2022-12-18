using DiamondKata.Creators;
using DiamondKata.Interfaces;
using FluentAssertions;
using Xunit;

namespace DiamondKata.Tests
{
    public class ShapeCreatorTests
    {
        IShapeCreator subject;
        public ShapeCreatorTests()
        {
            subject = new DiamondCreator();
        }

        [Fact]
        public void AddChar_AddsToLineDictionary()
        {
            //Act
            subject.AddChar('H');

            //Assert
            subject.LineDictionary.Should().NotBeNull();
            subject.LineDictionary.Count.Should().NotBe(0);
        }

        [Fact]
        public void CreateLine_ReturnsAValidString()
        {
            //Act
            var result = subject.CreateLine('H');

            //Assert
            result.Should().NotBeNull();
        }

        
    }
}
