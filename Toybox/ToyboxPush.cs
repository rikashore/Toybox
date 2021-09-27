namespace Toybox
{
    public class ToyboxPush : Token
    {
        public ToyboxIdentifier Identifier { get; }
        public Token Variable { get; }

        public ToyboxPush(ToyboxIdentifier identifier, Token variable)
        {
            Identifier = identifier;
            Variable = variable;
        }
    }
}