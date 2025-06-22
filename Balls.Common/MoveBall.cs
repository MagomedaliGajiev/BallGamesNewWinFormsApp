using Timer = System.Windows.Forms.Timer;

namespace Balls.Common
{
    public class MoveBall : RandomSizeAndPointBall
    {
        public MoveBall(Form form) : base(form)
        {
            _vX = _random.Next(-20, 21);
            _vY = _random.Next(-20, 21);

            // Гарантируем, что шарик движется
            while (_vX == 0 && _vY == 0)
            {
                _vX = _random.Next(-20, 21);
                _vY = _random.Next(-20, 21);
            }
        }
    }
}
