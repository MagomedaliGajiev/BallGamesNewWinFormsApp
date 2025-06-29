namespace Balls.Common
{
    public class MoveBall : RandomSizeAndPointBall
    {
        public MoveBall(Form form) : base(form)
        {
            _vX = GenerateRandomProjection();
            _vY = GenerateRandomProjection();
        }

        public MoveBall(Form form, Color color) : base(form, color)
        {
            _vX = GenerateRandomProjection();
            _vY = GenerateRandomProjection();
        }

        private int GenerateRandomProjection()
        {
            var randomDouble = _random.NextDouble();
            var sign = 1;
            if (randomDouble < 0.5)
                sign = -1;
            return _random.Next(2, 5) * sign;
        }
    }
}
