namespace DiamondKata.Interfaces
{
    public interface IShapeCreator
    {
        Dictionary<int, string> LineDictionary { get; set; }
        public Action PrintAction { get; }
        public void AddChar(char ch);
        public string CreateLine(char ch);
    }
}
