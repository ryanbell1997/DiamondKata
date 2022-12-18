using DiamondKata.Creators;
using DiamondKata.Interfaces;

namespace DiamondKata
{
    public class ConsoleWriter
    {
        IShapeCreator ShapeCreator { get; set; }
        public ConsoleWriter()
        {
            ShapeCreator = new DiamondCreator();
        }

        public void ReadCharacter()
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
                        PrintShape(ShapeCreator, character);
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
                ShapeCreator.LineDictionary.Clear();
                ReadCharacter();
            }
        }

        public void PrintShape(IShapeCreator creator, char character)
        {
            creator.AddChar(character);
        }
    }
}
