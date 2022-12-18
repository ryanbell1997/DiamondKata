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
        }

        public string CreateLine(char ch)
        {
            AmendPreviousDiamondLines();

            if (LineDictionary.Count == 0) return ch.ToString();

            return CreateLineUsingDictionaryLength(ch);
        }

        internal string CreateLineUsingDictionaryLength(char ch)
        {
            var characterString = ch.ToString();
            var returnString = characterString;

            for(int i = 0; i < (LineDictionary.Count * 2) - 1; i++)
            {
                returnString += " ";
            }
            returnString += characterString;

            return returnString;
        }

        public Action PrintAction {
            get
            {
                return () =>
                {
                    for (int i = 1; i <= LineDictionary.Count; i++)
                    {
                        Console.WriteLine(LineDictionary[i]);
                    }

                    for (int i = LineDictionary.Count - 1; i > 0; i--)
                    {
                        Console.WriteLine(LineDictionary[i]);
                    }
                };
            }
        }

        internal void AmendPreviousDiamondLines()
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
