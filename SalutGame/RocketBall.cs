using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace SalutGame
{
    public class RocketBall : MoveBall
    {
        public event EventHandler Exploded;
        private Timer _explodeTimer;
        private bool _isExploded = false;
        public RocketBall(Form form) : base(form)
        {
            _radius = 15;
            _color = Color.White;

            // Старт с нижней части экрана
            _centerX = _random.Next(LeftSide(), RightSide());
            _centerY = DownSide();

            // Движение вверх
            _vY = _random.Next(-10, -6);
            _vX = _random.Next(-2, 3); // Небольшое случайное смещение вбок

            // Таймер взрыва (1-3 секунды)
            _explodeTimer = new Timer();
            _explodeTimer.Interval = _random.Next(1000, 3000);
            _explodeTimer.Tick += ExplodeTimer_Tick;
            _explodeTimer.Start();
        }

        public override void Move()
        {
            base.Move();

            // Взрыв при достижении верха экрана
            if (_centerY < TopSide() / 2 && !_isExploded)
            {
                Explode();
            }
        }

        private void ExplodeTimer_Tick(object? sender, EventArgs e)
        {
            Explode();
        }

        private void Explode()
        {
            if (_isExploded) return;
            
            _isExploded = true;
            _explodeTimer.Stop();
            Exploded?.Invoke(this, EventArgs.Empty);
        }
    }
}
