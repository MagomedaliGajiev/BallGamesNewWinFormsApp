using Balls.Common;

namespace SalutGame
{
    public class SalutBall : MoveBall
    {
        private float _g = 0.2f;
        public SalutBall(Form form, Point point) : base(form)
        {
            _radius = 7;
            _centerX = point.X;
            _centerY = point.Y;
            _vY = -Math.Abs(_vY);
        }

        public override void Move()
        {
            base.Move();
            _vY += _g;
        }
    }
}
