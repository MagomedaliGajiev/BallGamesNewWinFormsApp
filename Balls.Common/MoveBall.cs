using Timer = System.Windows.Forms.Timer;

namespace Balls.Common
{
    public class MoveBall : RandomSizeAndPointBall
    {
        private Timer _timer;
        public MoveBall(Form form) : base(form)
        {
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
