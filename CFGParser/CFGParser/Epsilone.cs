using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Epsilone<T> : IParser<T>
    {
        private readonly T _defaultValue;

        public Epsilone(T defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public List<Tuple<string, T>> Parse(string s)
        {
            return new List<Tuple<string, T>>
                   {
                       new Tuple<string, T>(s, _defaultValue)
                   };
        }
    }
}