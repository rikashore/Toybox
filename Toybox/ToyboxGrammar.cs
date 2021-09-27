using System.Collections.Generic;
using System.Globalization;
using Sprache;

namespace Toybox
{
    public static class ToyboxGrammar
    {
        private static readonly Parser<ToyboxIdentifier> Identifier =
            from id in Parse.Identifier(Parse.Letter, Parse.LetterOrDigit)
            select new ToyboxIdentifier(id);

        private static readonly Parser<ToyboxString> ToyboxString =
            from open in Parse.Char('"')
            from value in Parse.CharExcept('"').Many().Text()
            from close in Parse.Char('"')
            select new ToyboxString(value);

        private static readonly Parser<ToyboxNumber> ToyboxNumber =
            Parse.DecimalInvariant
                .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                .Select(v => new ToyboxNumber(v));

        private static readonly Parser<ToyboxVariable> ToyboxVariable =
            from key in Identifier.Contained(Parse.String("in").Token(), Parse.String("place").Token())
            from value in ToyboxString.Or<Token>(ToyboxNumber)
            select new ToyboxVariable(key, value);

        private static readonly Parser<Toybox> OpenToybox =
            from name in Parse.String("open toybox").Token().Then(_ => Identifier)
            select new Toybox(name, new Stack<Token>());

        private static readonly Parser<ToyboxIdentifier> CloseToybox =
            Parse.String("close toybox").Token().Then(_ => Identifier);

        private static readonly Parser<ToyboxPush> Push =
            from identifier in Parse.String("into").Token().Then(_ => Identifier).Token()
            from variable in Parse.String("push").Token().Then(_ => ToyboxString.Or<Token>(ToyboxNumber).Or(Identifier).Token())
            select new ToyboxPush(identifier, variable);

        private static readonly Parser<ToyboxPop> Pop =
            from identifier in Identifier.Contained(Parse.String("from").Token(), Parse.String("pop").Token())
            select new ToyboxPop(identifier);

        private static readonly Parser<ToyboxWriteLine> WriteLine =
            Parse.String("writel").Token().Return(new ToyboxWriteLine());

        private static readonly Parser<ToyboxWrite> Write =
            Parse.String("write").Token().Return(new ToyboxWrite());

        private static readonly Parser<ToyboxWriteLine> WriteLineAction =
            from obj in WriteLine.Then(_ => ToyboxString.Or<Token>(ToyboxNumber).Or(Identifier))
            select new ToyboxWriteLine(obj);

        private static readonly Parser<ToyboxWrite> WriteAction =
            from obj in Write.Then(_ => ToyboxString.Or<Token>(ToyboxNumber).Or(Identifier))
            select new ToyboxWrite(obj);

        private static readonly Parser<ToyboxLoop> ToyboxLoop =
            from identifier in Parse.String("loop through").Token().Then(_ => Identifier).Token()
            from action in Parse.String("and").Token().Then(_ => WriteLine.Or<FunctionToken>(Write))
            select new ToyboxLoop(identifier, action);

        public static readonly Parser<Token> Token =
            ToyboxVariable
                .Or<Token>(WriteLineAction)
                .Or(Push)
                .Or(Pop)
                .Or(WriteAction)
                .Or(OpenToybox)
                .Or(CloseToybox)
                .Or(ToyboxLoop);
    }
}