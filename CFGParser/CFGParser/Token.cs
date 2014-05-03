using System;
using System.Collections.Generic;

namespace CFGParser
{
    public class Token : IParser<string>
    {
        private readonly string _token;

        public Token(string token)
        {
            _token = token;
        }

        public List<Tuple<string, string>> Parse(string s)
        {
            if(s.StartsWith(_token))
                return new List<Tuple<string, string>>
                       {
                           new Tuple<string, string>(s.Remove(0, _token.Length), _token)
                       };
            return new List<Tuple<string, string>>();
        }
    }
}