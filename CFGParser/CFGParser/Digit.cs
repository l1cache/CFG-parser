using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Digit : IParser<int>
    {
        public List<Tuple<string, int>> Parse(string s)
        {
            return new Change<char, int>(new Satisfy(c =>
                {
                    int value;
                    return int.TryParse(c.ToString(), out value);
                }), c => int.Parse(c.ToString())).Parse(s);
        }
    }
}