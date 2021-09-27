namespace Toybox
{
    public abstract class FunctionToken : Token
    {
       public abstract void Apply(Token token = null);
    }
}