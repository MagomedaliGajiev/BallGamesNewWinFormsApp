namespace Balls.Common
{
    public class PointBall : Ball
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            _x = x - _size / 2;
            _y = y - _size / 2;
            _size = 50;
        }
    }
}
