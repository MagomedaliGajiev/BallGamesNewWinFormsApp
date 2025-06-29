using Balls.Common;

namespace BiliyardBallsGame
{
    public class BillyardBall : MoveBall
    {
        public event EventHandler<HitEventArgs> OnHited;
        public BillyardBall(Form form) : base(form)
        {
            _radius = 15;
        }

        public BillyardBall(Form form, Color color) : base(form, color)
        {
            _radius = 15;
        }

        public void SetStartPositionInLeftHalf()
        {
            _centerX = _random.Next(LeftSide(), _form.ClientSize.Width / 2);
            _centerY = _random.Next(TopSide(), DownSide());
        }

        public void SetStartPositionInRightHalf()
        {
            _centerX = _random.Next(_form.ClientSize.Width / 2, RightSide());
            _centerY = _random.Next(TopSide(), DownSide());
        }

        public override void Move()
        {

            base.Move();

            // Обработка столкновений с границами
            if (_centerX <= LeftSide())
            {
                _centerX = LeftSide();
                _vX = -_vX;
                OnHited.Invoke(this, new HitEventArgs(Side.Left));
            }
            if (_centerX >= RightSide())
            {
                _centerX = RightSide();
                _vX = -_vX;
                OnHited.Invoke(this, new HitEventArgs(Side.Right));
            }
            if (_centerY <= TopSide())
            {
                _centerY = TopSide();
                _vY = -_vY;
                OnHited.Invoke(this, new HitEventArgs(Side.Top));
            }
            if ( _centerY >= DownSide())
            {
                _centerY = DownSide();
                _vY = -_vY;
                OnHited.Invoke(this, new HitEventArgs(Side.Bottom));
            }
        }


    }
}
