using System.Linq;

namespace CFGParser.ArithmeticExpression
{
    public class Multiple : IExpression
    {
        private readonly IExpression[] _expressions;

        public Multiple(params IExpression[] expressions)
        {
            _expressions = expressions;
        }

        public int Eval()
        {
            return _expressions.Aggregate(1, (i, expression) => i * expression.Eval());
        }
    }
}