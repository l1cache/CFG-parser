using System;
using System.Collections.Generic;

namespace CFGParser.ParensParser
{
    //Parens -> (Parens)Parens
    //Parens -> 
    public class Parens : IParser<ITree>
    {
        public List<Tuple<string, ITree>> Parse(string s)
        {
            return new Parallel<ITree>(new Change<Tuple<char, Tuple<ITree, Tuple<char, ITree>>>, ITree>(
                                           new Successively<char, Tuple<ITree, Tuple<char, ITree>>>(
                                               new Symbol('('),
                                               new Successively<ITree, Tuple<char, ITree>>(
                                                   new Parens(),
                                                   new Successively<char, ITree>(
                                                       new Symbol(')'),
                                                       new Parens()))),
                                           tuple => new Bin(tuple.Item2.Item1, tuple.Item2.Item2.Item2)),

                                       new Epsilone<ITree>(new Nil())).Parse(s);
        }
    }
}