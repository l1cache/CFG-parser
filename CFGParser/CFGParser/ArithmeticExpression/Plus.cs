using System.Linq;

namespace CFGParser.ArithmeticExpression
{
    public class Plus : IExpression
    {
        private readonly IExpression[] _expressions;

        public Plus(params IExpression[] expressions)
        {
            _expressions = expressions;
        }

        public int Eval()
        {
            return _expressions.Aggregate(0, (i, expression) => i + expression.Eval());
        }
    }
}