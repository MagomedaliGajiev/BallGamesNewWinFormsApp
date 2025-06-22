using Timer = System.Windows.Forms.Timer;

namespace Balls.Common
{
    public class MoveBall : RandomSizeAndPointBall
    {
        private Timer _timer;
        public MoveBall(Form form) : base(form)
        {
            _vX = _random.Next(-10, 11);
            _vY = _random.Next(-10, 11);

            // Гарантируем, что шарик движется
            while (_vX == 0 && _vY == 0)
            {
                _vX = _random.Next(-10, 11);
                _vY = _random.Next(-10, 11);
            }

            _timer = new Timer();
            _timer.Interval = 20;
            _timer.Tick += _timer_Tick;

        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
    }
}
