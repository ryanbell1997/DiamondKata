using DiamondKata.Interfaces;
using DiamondKata.Validators;
using FluentAssertions;
using Xunit;

namespace DiamondKata.Tests
{
    public class InputValidatorTests
    {
        private readonly IInputValidator _subject = new InputValidator();

        [Theory]
        [InlineData("")]
        [InlineData("ABC")]
        [InlineData("1")]
        [InlineData(null)]
        public void IsValid_ReturnsInvalidAndNullWhenProvidedBadInput(string input)
        {
            _subject.IsValid(input).Should().Be((false, null));
        }

        [Fact]
        public void IsValid_ReturnsIsValidWhenProvidedGoodInput()
        {
            _subject.IsValid("H").Should().Be((true, 'H'));
        }

    }
}
