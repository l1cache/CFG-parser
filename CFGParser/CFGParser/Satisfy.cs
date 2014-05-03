using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Satisfy : IParser<char>
    {
        private readonly Func<char, bool> _predicate;

        public Satisfy(Func<char, bool> predicate)
        {
            _predicate = predicate;
        }

        public List<Tuple<string, char>> Parse(string s)
        {
            if(s.Length == 0 || !_predicate(s[0]))
            {
                return new List<Tuple<string, char>>();
            }
            return new List<Tuple<string, char>>
                {
                    new Tuple<string, char>(s.Remove(0, 1), s[0])
                };
        }
    }
}