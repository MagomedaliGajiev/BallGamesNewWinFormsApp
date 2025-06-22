namespace Balls.Common
{
    public class Ball
    {
        protected Form _form;
        protected int _vX = 3;
        protected int _vY = 3;
        protected int _x;
        protected int _y;
        protected int _size;
        protected Color _color = Color.Aqua;

        public Rectangle Bounds => new Rectangle(_x, _y, _size, _size);
        public Ball(Form form)
        {
            _form = form;
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
            _x += _vX;
            _y += _vY;

            //// Обработка столкновений с границами
            //if (_x <= 0 || _x + _size >= _form.ClientSize.Width)
            //{
            //    _vX = -_vX;
            //}

            //if (_x <= 0 || _x + _size >= _form.ClientSize.Height)
            //{
            //    _vY = -_vY;
            //}
        }

        public virtual void EnsureOnForm(Size clientSize)
        {
            _x = Math.Max(0, Math.Min(_x, clientSize.Width - _size));
            _y = Math.Max(0, Math.Min(_y, clientSize.Height - _size));
        }

        public void Show()
        {
            var graphics = _form.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(_x, _y, _size, _size);
            graphics.FillEllipse(brush, rectangle);
        }

        public virtual bool IsOnForm()
        {
            return _x > 0 &&
                   _y > 0 &&
                   _x + _size < _form.ClientSize.Width &&
                   _y + _size < _form.ClientSize.Height;
        }

        public bool Contains(Point point)
        {
            // Проверка попадания точки в шарик
            var centerX = _x + _size / 2;
            var centerY = _y + _size / 2;
            var radius = _size / 2;

            return (point.X - centerX) * (point.X - centerX) +
                   (point.Y - centerY) * (point.Y - centerY) <=
                   radius * radius;
        }



    }
}
