using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser.ArithmeticExpression
{

    //Expr -> Fact
    //Expr -> Fact+Expr+Expr+...
    //Expr -> Fact-Expr-Expr-...
    public class Expr : IParser<IExpression>
    {
        public List<Tuple<string, IExpression>> Parse(string s)
        {
            return
                new Parallel<IExpression>(
                    new Fact(),
                    new Change<Tuple<IExpression, IExpression[]>, IExpression>(
                        new Successively<IExpression, IExpression[]>(
                            new Fact(),
                            new AlLeastOnce<IExpression>(
                                new SuccessivelyRight<char, IExpression>(
                                    new Symbol('+'),
                                    new Expr()
                                    )
                                )
                            ),
                        tuple => new Plus(new[] {tuple.Item1}.Union(tuple.Item2).ToArray())),
                    new Change<Tuple<IExpression, IExpression[]>, IExpression>(
                        new Successively<IExpression, IExpression[]>(
                            new Fact(),
                            new AlLeastOnce<IExpression>(
                                new SuccessivelyRight<char, IExpression>(
                                    new Symbol('-'),
                                    new Expr()
                                    )
                                )
                            ),
                        tuple => new Minus(new[] {tuple.Item1}.Union(tuple.Item2).ToArray()))
                    ).Parse(s);
        }
    }
}