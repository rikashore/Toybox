using System;

namespace Toybox
{
    public class ToyboxWriteLine : FunctionToken
    {
        public Token ItemToWrite { get; }

        public ToyboxWriteLine(Token itemToWrite = null)
        {
            ItemToWrite = itemToWrite;
        }

        public override void Apply(Token token = null)
            => Console.WriteLine(token ?? ItemToWrite);
    }
}