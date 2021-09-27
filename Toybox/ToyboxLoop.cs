namespace Toybox
{
    public class ToyboxLoop : Token
    {
        public ToyboxIdentifier Identifier { get; }
        public FunctionToken Action { get; }


        public ToyboxLoop(ToyboxIdentifier identifier, FunctionToken action)
        {
            Identifier = identifier;
            Action = action;
        }
    }
}