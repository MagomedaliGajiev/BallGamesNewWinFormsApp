using Balls.Common;

namespace BiliyardBallsGame
{
    public class BillyardBall : MoveBall
    {
        public event EventHandler<HitEventArgs> OnHited;
        public BillyardBall(Form form) : base(form)
        {
        }

        public override void Move()
        {

            Clear();
            Go();
            Show();

            // Обработка столкновений с границами
            if (_centerX <= LeftSide())
            {
                _vX = -_vX;
                OnHited.Invoke(this, new HitEventArgs(Side.Left));
            }
            if (_centerX >= RightSide())
            {
                _vX = -_vX;
                OnHited.Invoke(this, new HitEventArgs(Side.Right));
            }
            if (_centerY <= TopSide())
            {
                _vY = -_vY;
                OnHited.Invoke(this, new HitEventArgs(Side.Top));
            }
            if ( _centerY >= DownSide())
            {
                _vY = -_vY;
                OnHited.Invoke(this, new HitEventArgs(Side.Bottom));
            }
        }


    }
}
