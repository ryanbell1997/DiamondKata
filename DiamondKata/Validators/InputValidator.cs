using DiamondKata.Interfaces;

namespace DiamondKata.Validators
{
    public class InputValidator : IInputValidator
    {
        public (bool isValid, char? character) IsValid(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid character");
                return (false, null);
            }

            if (!char.TryParse(input, out char character))
            {
                Console.WriteLine($"{input} was invalid. Please enter a valid character");
                return (false, null);
            }

            if (Char.IsNumber(character))
            {
                Console.WriteLine($"{character} is not in the alphabet. Please enter a different character");
                return (false, null);
            }

            return (true, character);
        }

        
    }
}
