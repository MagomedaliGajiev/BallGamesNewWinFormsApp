using Timer = System.Windows.Forms.Timer;

namespace BallGamesNewWinFormsApp
{
    public class MoveBall : RandomSizeAndPointBall
    {
        private Timer _timer;
        public MoveBall(MainForm form) : base(form)
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
