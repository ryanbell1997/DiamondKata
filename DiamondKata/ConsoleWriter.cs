using DiamondKata.Creators;
using DiamondKata.Interfaces;

namespace DiamondKata
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly IShapeCreator _shapeCreator;

        public ConsoleWriter(IShapeCreator shapeCreator)
        {
            _shapeCreator = shapeCreator;
        }

        public void Start()
        {
            Console.WriteLine("Please type a letter from the alphabet, and press the enter key to add to the shape. Type \"Restart\" to restart the shape, or type \"Exit\" to quit");

            string? input;
            while((input = Console.ReadLine()) != "Exit")
            {
                CheckForRestart(input);


                if (char.TryParse(input, out char character))
                {
                    if (!Char.IsNumber(character))
                    {
                        PrintShape(character);
                    }
                    else
                    {
                        Console.WriteLine($"{character} is not in the alphabet. Please enter a different character");
                    }
                }
                else
                {
                    Console.WriteLine($"{input} was invalid. Please enter a valid character");
                }

                Console.WriteLine("Please type a letter from the alphabet to add to the shape.");
            }
        }

        private void CheckForRestart(string? input)
        {
            if (!string.IsNullOrEmpty(input) && input.Equals("Restart", StringComparison.CurrentCultureIgnoreCase))
            {
                _shapeCreator.LineDictionary.Clear();
                Start();
            }
        }

        public void PrintShape(char character)
        {
            _shapeCreator.AddChar(character);
        }
    }
}
