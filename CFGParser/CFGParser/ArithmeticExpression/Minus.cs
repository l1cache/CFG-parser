using System.Linq;

namespace CFGParser.ArithmeticExpression
{
    public class Minus : IExpression
    {
        private readonly IExpression[] _expressions;

        public Minus(params IExpression[] expressions)
        {
            _expressions = expressions;
        }

        public int Eval()
        {
            return _expressions.Skip(1).Aggregate(_expressions[0].Eval(), (i, expression) => i - expression.Eval());
        }
    }
}