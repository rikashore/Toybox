namespace Toybox
{
    public class ToyboxVariable : Token
    {
        public ToyboxIdentifier Identifier { get; }
        public Token Token { get; }

        public ToyboxVariable(ToyboxIdentifier identifier, Token token)
        {
            Identifier = identifier;
            Token = token;
        }
    }
}