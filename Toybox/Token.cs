namespace Toybox
{
    public abstract class Token
    { }

    public abstract class Token<TValue> : Token
    {
        public TValue Value { get; }

        protected Token(TValue value)
        {
            Value = value;
        }
    }
}