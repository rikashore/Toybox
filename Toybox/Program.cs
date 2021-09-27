using System;
using System.Collections.Generic;
using System.IO;
using Sprache;

namespace Toybox
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("test.tbx");
            var tokensRaw = text.Split("\n");
            var tokens = new List<Token>();

            foreach (var rawToken in tokensRaw)
            {
                tokens.Add(ToyboxGrammar.Token.Parse(rawToken));
            }

            var interpreter = new ToyboxInterpreter(tokens);
            interpreter.Interpret();
        }
    }
}