using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser.ArithmeticExpression
{
    //Fact -> Term
    //Fact -> Term*Fact*Fact*...
    //Fact -> Term/Fact/Fact/...
    public class Fact : IParser<IExpression>
    {
        public List<Tuple<string, IExpression>> Parse(string s)
        {
            return new Parallel<IExpression>(
                new Term(),
                new Change<Tuple<IExpression, IExpression[]>, IExpression>(
                    new Successively<IExpression, IExpression[]>(
                        new Term(),
                        new AlLeastOnce<IExpression>(
                            new SuccessivelyRight<char, IExpression>(
                                new Symbol('*'),
                                new Fact()
                                )
                            )
                        ),
                    tuple => new Multiple(new[] {tuple.Item1}.Union(tuple.Item2).ToArray())),
                new Change<Tuple<IExpression, IExpression[]>, IExpression>(
                    new Successively<IExpression, IExpression[]>(
                        new Term(),
                        new AlLeastOnce<IExpression>(
                            new SuccessivelyRight<char, IExpression>(
                                new Symbol('/'),
                                new Fact()
                                )
                            )
                        ),
                    tuple => new Division(new[] {tuple.Item1}.Union(tuple.Item2).ToArray()))
                ).Parse(s);
        }
    }
}