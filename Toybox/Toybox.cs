using System.Collections.Generic;
using System.Linq;

namespace Toybox
{
    public class Toybox : Token
    {
        public ToyboxIdentifier Name { get; }
        public Stack<Token> Children { get; }

        public Toybox(ToyboxIdentifier name, Stack<Token> children)
        {
            Name = name;
            Children = children;
        }

        public override string ToString()
        {
            return $"{Name} - [ {string.Join(", ", Children)} ]";
        }
    }
}