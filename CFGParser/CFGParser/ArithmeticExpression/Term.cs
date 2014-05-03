using System;
using System.Collections.Generic;

namespace CFGParser.ArithmeticExpression
{
    //Term -> n
    //Term -> (Expr)
    public class Term : IParser<IExpression>
    {
        public List<Tuple<string, IExpression>> Parse(string s)
        {
            return new Parallel<IExpression>(
                new Change<int, IExpression>(
                    new Natural(), 
                    i => new DigitEx(i)
                    ),
                new SuccessivelyRight<char, IExpression>(
                    new Symbol('('),
                    new SuccessivelyLeft<IExpression, char>(
                        new Expr(),
                        new Symbol(')')
                        )
                    )
                ).Parse(s);
        }
    }
}