using System;

namespace Toybox
{
    public class ToyboxWrite : FunctionToken
    {
        public Token ItemToWrite { get; }

        public ToyboxWrite(Token itemToWrite = null)
        {
            ItemToWrite = itemToWrite;
        }

        public override void Apply(Token token = null)
            => Console.Write(token ?? ItemToWrite);
    }
}