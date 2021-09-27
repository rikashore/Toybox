namespace Toybox
{
    public class ToyboxPop : Token
    {
        public ToyboxIdentifier Identifier { get; }

        public ToyboxPop(ToyboxIdentifier identifier)
        {
            Identifier = identifier;
        }
    }
}