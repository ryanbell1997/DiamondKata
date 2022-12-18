namespace DiamondKata.Interfaces
{
    public interface IInputValidator
    {
        public (bool isValid, char? character) IsValid(string? input);
    }
}
