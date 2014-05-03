using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGParser
{
    public class Natural : IParser<int>
    {
        public List<Tuple<string, int>> Parse(string s)
        {
            return new Change<int[], int>(new Many<int>(new Digit()),
                                                ints => ints.Aggregate(0, (i, i1) => i * 10 + i1)).Parse(s);
        }
    }
}