using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Fail<T> : IParser<T>
    {
        public List<Tuple<string, T>> Parse(string s)
        {
            return new List<Tuple<string, T>>();
        }
    }
}