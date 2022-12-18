using DiamondKata.Interfaces;

namespace DiamondKata.Creators
{
    public class DiamondCreator : IShapeCreator
    {
        public Dictionary<int, string> LineDictionary { get; set; } = new();


        public void AddChar(char ch)
        {
            var newDictionaryLineIndex = LineDictionary.Count + 1;
            LineDictionary.Add(newDictionaryLineIndex, CreateLine(ch));

            Print();
        }

        public string CreateLine(char ch)
        {
            AmmendPreviousDiamondLines();

            return LineDictionary.Count switch
            {
                0 => $"{ch}",
                1 => $"{ch} {ch}",
                2 => $"{ch}   {ch}",
                _ => CreateLineUsingDictionaryLength(ch)
            };
        }

        internal string CreateLineUsingDictionaryLength(char ch)
        {
            var returnString = LineDictionary.Last().Value;

            returnString = $"{ch}{GetPreviousStringCentreSpaces(returnString)}";
            returnString += $"  {ch}";

            return returnString;
        }

        public void Print()
        {
            for (int i = 1; i <= LineDictionary.Count; i++)
            {
                Console.WriteLine(LineDictionary[i]);
            }

            for (int i = LineDictionary.Count - 1; i > 0; i--)
            {
                Console.WriteLine(LineDictionary[i]);
            }
        }

        internal void AmmendPreviousDiamondLines()
        {
            foreach (var line in LineDictionary)
            {
                LineDictionary[line.Key] = $" {line.Value} ";
            }
        }

        public string GetPreviousStringCentreSpaces(string returnString)
            => returnString.Substring(2, returnString.Length - 4);
    }
}
