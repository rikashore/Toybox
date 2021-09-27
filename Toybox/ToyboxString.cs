namespace Toybox
{
    public class ToyboxString : Token<string>
    {
        public ToyboxString(string value)
            : base(value)
        { }

        public override string ToString()
            => Value;
    }
}