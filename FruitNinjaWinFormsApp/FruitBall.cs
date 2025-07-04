using Balls.Common;

namespace FruitNinjaWinFormsApp
{
    public class FruitBall : MoveBall
    {
        protected float _g = 0.2f;
        protected bool _isSliced = false;
        protected float _originalVX;
        protected float _originalVY;
        public FruitBall(Form form) : base(form)
        {
            _radius = _random.Next(20, 40);
            _centerX = _random.Next(LeftSide(), RightSide());
            _centerY = _form.ClientSize.Height + _radius;
            _vY = -_random.Next(10, 20);
            _vX = -_random.Next(-4, 5);
            _originalVX = _vX;
            _originalVY = _vY;
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

        public void SlowDown(float multiplier)
        {
            _vX = _originalVX * multiplier;
            _vY -= _originalVY * multiplier;
        }

        public void RestoreSpeed()
        {
            _vX = _originalVX;
            _vY = _originalVY;
        }
    }
}
