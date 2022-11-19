using Domain.Carpiler.Infra;
using Domain.Carpiler.Lexical;
using System;
using System.Collections.Generic;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class FunctionCall : Statement, IValuable
    {
        public FunctionCall(Identifier identifier, List<IValuable> parameters)
        {
            Identifier = identifier;
            Parameters = parameters;
        }

        public Identifier Identifier { get; }
        public List<IValuable> Parameters { get; }

        public override object Run(Interpreter interpreter)
        {
            throw new NotImplementedException();
        }

        public object ToValue()
        {
            throw new NotImplementedException();
        }
    }
}