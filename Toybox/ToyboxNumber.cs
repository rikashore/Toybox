namespace Toybox
{
    public class ToyboxNumber : Token<double>
    {
        public ToyboxNumber(double value)
            : base(value)
        { }

        public override string ToString()
            => Value.ToString();
    }
}