namespace CFGParser.ArithmeticExpression
{
    public class DigitEx : IExpression
    {
        private readonly int _digit;

        public DigitEx(int digit)
        {
            _digit = digit;
        }

        public int Eval()
        {
            return _digit;
        }
    }
}