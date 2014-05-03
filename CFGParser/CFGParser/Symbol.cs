using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Symbol : IParser<char>
    {
        private readonly char _symbol;

        public Symbol(char symbol)
        {
            _symbol = symbol;
        }

        public List<Tuple<string, char>> Parse(string s)
        {
            if(s.Length == 0 || s[0] != _symbol)
                return new List<Tuple<string, char>>();
            return new List<Tuple<string, char>>
                {
                    new Tuple<string, char>(s.Remove(0, 1), _symbol)
                };
        }
    }
}