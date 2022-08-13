namespace Domain.Carpiler.Lexical
{
    public class ReservedWord : Token
    {
        public ReservedWord(string value) : base(value, TokenType.ReservedWord)
        {
        }
    }
}