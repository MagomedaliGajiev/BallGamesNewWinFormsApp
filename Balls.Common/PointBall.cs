namespace Balls.Common
{
    public class PointBall : Ball
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            _centerX = x - _radius / 2;
            _centerY = y - _radius / 2;
            _radius = 50;
        }
    }
}
