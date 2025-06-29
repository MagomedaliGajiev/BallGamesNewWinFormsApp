using Timer = System.Windows.Forms.Timer;

namespace Balls.Common
{
    public class Ball
    {
        protected Form _form;
        private Timer _timer;

        protected static Random _random = new ();
        protected int _vX = 3;
        protected int _vY = 3;
        protected int _centerX;
        protected int _centerY;
        protected int _radius;
        protected Color _color = Color.Aqua;

        public Rectangle Bounds => new Rectangle(_centerX - _radius, _centerY - _radius, 2 * _radius, 2 * _radius);
        public Ball(Form form)
        {
            _form = form;
            _timer = new Timer();
            _timer.Interval = 20;
            _timer.Tick += Timer_Tick;

            GenerateRandomColor();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }

        private bool IsMoveable()
        {
            return _timer.Enabled;
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }

        private void GenerateRandomColor()
        {
            // Случайный цвет
            _color = Color.FromArgb(
                _random.Next(150, 256),
                _random.Next(150, 256),
                _random.Next(150, 256)
            );
        }

        public virtual void Draw(Graphics graphics)
        {
            using (var brush = new SolidBrush(_color))
            {
                graphics.FillEllipse(brush, Bounds);
            }
        }

        public virtual void Move()
        {
            _centerX += _vX;
            _centerY += _vY;

            //// Обработка столкновений с границами
            //if (_centerX - _radius <= 0 || _centerX + _radius >= _form.ClientSize.Width)
            //{
            //    _vX = -_vX;
            //}

            //if (_centerY - _radius <= 0 || _centerY + _radius >= _form.ClientSize.Height)
            //{
            //    _vY = -_vY;
            //}
        }

        public virtual void EnsureOnForm(Size clientSize)
        {
            _centerX = Math.Max(_radius, Math.Min(_centerX, clientSize.Width - _radius));
            _centerY = Math.Max(_radius, Math.Min(_centerY, clientSize.Height - _radius));
        }

        public void Show()
        {
            var graphics = _form.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(_centerX, _centerY, _radius, _radius);
            graphics.FillEllipse(brush, rectangle);
        }

        public int LeftSide()
        {
            return _radius;
        }

        public int RightSide()
        {
            return _form.ClientSize.Width - _radius;
        }

        public int TopSide()
        {
            return _radius;
        }

        public int DownSide()
        {
            return _form.ClientSize.Height - _radius;
        } 

        public virtual bool IsOnForm()
        {
            return _centerX >= LeftSide() &&
                   _centerX <= RightSide() &&
                   _centerY >= TopSide() &&
                   _centerY <= DownSide();
        }

        // Проверяет, улетел ли шарик за пределы формы
        public virtual bool IsOutOfForm()
        {
            return _centerX + _radius < 0 ||
                   _centerY + _radius < 0 ||
                   _centerX - _radius > _form.ClientSize.Width ||
                   _centerY - _radius > _form.ClientSize.Height;
        }

        public virtual bool Contains(Point point)
        {
            return (point.X - _centerX) * (point.X - _centerX) +
                   (point.Y - _centerY) * (point.Y - _centerY) <=
                   _radius * _radius;
        }
    }
}
