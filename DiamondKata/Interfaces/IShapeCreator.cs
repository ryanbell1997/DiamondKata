namespace DiamondKata.Interfaces
{
    public interface IShapeCreator
    {
        Dictionary<int, string> LineDictionary { get; set; }
        public void AddChar(char ch);
        public string CreateLine(char ch);
        public void Print();
    }
}
