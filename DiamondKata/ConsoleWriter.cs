using DiamondKata.Interfaces;

namespace DiamondKata
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly IShapeCreator _shapeCreator;
        private readonly IInputValidator _inputValidator;

        public ConsoleWriter(IShapeCreator shapeCreator, IInputValidator inputValidator)
        {
            _shapeCreator = shapeCreator;
            _inputValidator = inputValidator;
        }

        public void PrintShape(Action printMethod)
            => printMethod();

        public void Start()
        {
            Console.WriteLine("Please type a letter from the alphabet, and press the enter key to add to the shape. Type \"Restart\" to restart the shape, or type \"Exit\" to quit");

            string? input;

            while((input = Console.ReadLine()) != "Exit")
            {
                CheckForRestart(input);

                var result = _inputValidator.IsValid(input);

                if (!result.isValid && result.character is null)
                {
                    continue;
                }

                _shapeCreator.AddChar(result.character.Value);

                PrintShape(_shapeCreator.PrintAction);

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
    }
}
