using Balls.Common;

namespace FruitNinjaWinFormsApp
{
    public class FruitBall : MoveBall
    {
        private float _g = 0.2f;
        private bool _isSliced = false;
        public FruitBall(Form form) : base(form)
        {
            _radius = _random.Next(20, 40);
            _centerX = _random.Next(LeftSide(), RightSide());
            _centerY = _form.ClientSize.Height + _radius;
            _vY = -_random.Next(10, 20);
            _vX = -_random.Next(-4, 5);
            GenerateRandomColor();
        }

        public bool IsSliced => _isSliced;

        public void Slice()
        {
            _isSliced = true;
        }

        public override void Move()
        {
            base.Move();
            _vY += _g;
        }
    }
}
