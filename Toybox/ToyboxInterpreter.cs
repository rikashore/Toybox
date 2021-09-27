using System;
using System.Collections.Generic;

namespace Toybox
{
    public class ToyboxInterpreter
    {
        private readonly Dictionary<string, Token> _variables;
        private readonly Dictionary<string, Toybox> _toyboxes;

        private readonly List<Token> _tokens;

        public ToyboxInterpreter(List<Token> tokens)
        {
            _tokens = tokens;
            _variables = new Dictionary<string, Token>();
            _toyboxes = new Dictionary<string, Toybox>();
        }

        public void Interpret()
        {
            foreach (var token in _tokens)
            {
                switch (token)
                {

                    case ToyboxVariable variable:
                        HandleVariableAssignment(variable);
                        break;

                    case ToyboxWriteLine writeLine:
                        HandleWriteLine(writeLine);
                        break;

                    case ToyboxWrite write:
                        HandleWrite(write);
                        break;

                    case Toybox toybox:
                        HandleToybox(toybox);
                        break;

                    case ToyboxIdentifier identifier:
                        CloseToybox(identifier);
                        break;

                    case ToyboxPush push:
                        HandlePush(push);
                        break;

                    case ToyboxPop pop:
                        HandlePop(pop);
                        break;

                    case ToyboxLoop loop:
                        HandleToyboxLoop(loop);
                        break;

                    default:
                        throw new ArgumentException("Invalid token");
                }
            }
        }

        private void HandleWriteLine(ToyboxWriteLine writeLine)
        {
            if (writeLine.ItemToWrite is ToyboxIdentifier identifier)
            {
                writeLine.Apply(_variables[identifier.Value]);
                return;
            }

            writeLine.Apply();
        }

        private void HandleWrite(ToyboxWrite write)
        {
            if (write.ItemToWrite is ToyboxIdentifier identifier)
            {
                write.Apply(_variables[identifier.Value]);
                return;
            }

            write.Apply();
        }

        private void HandleVariableAssignment(ToyboxVariable variable)
            => _variables[variable.Identifier.Value] = variable.Token;

        private void HandleToybox(Toybox toybox)
            => _toyboxes[toybox.Name.Value] = toybox;

        private void CloseToybox(ToyboxIdentifier identifier)
            => _toyboxes.Remove(identifier.Value);

        private void HandlePush(ToyboxPush push)
        {
            var toybox = _toyboxes[push.Identifier.Value];

            toybox.Children.Push(push.Variable);
        }

        private void HandlePop(ToyboxPop pop)
        {
            var toybox = _toyboxes[pop.Identifier.Value];

            toybox.Children.Pop();
        }

        private void HandleToyboxLoop(ToyboxLoop loop)
        {
            var toybox = _toyboxes[loop.Identifier.Value];

            foreach (var child in toybox.Children)
                loop.Action.Apply(child);
        }
    }
}