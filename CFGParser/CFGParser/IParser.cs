using System;
using System.Collections.Generic;

namespace CFGParser
{
    public interface IParser<T>
    {
        List<Tuple<string, T>> Parse(string s);
    }
}