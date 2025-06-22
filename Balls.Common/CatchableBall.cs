namespace Balls.Common
{
    public class CatchableBall : Ball
    {
        private static Random _random = new Random();
        public bool IsCaught { get; set; }

        public CatchableBall(Form form) : base(form)
        {
            _size = _random.Next(30, 70);
            _x = _random.Next(0, _form.ClientSize.Width - _size);
            _y = _random.Next(0, _form.ClientSize.Height - _size);
            _vX = _random.Next(-5, 6);
            _vY = _random.Next(-5, 6);

            // Гарантируем движение
            if (_vX == 0) _vX = 1;
            if (_vY == 0) _vY = -1;

            // Случайный цвет
            _color = Color.FromArgb(
                _random.Next(150, 256),
                _random.Next(150, 256),
                _random.Next(150, 256)
            );
        }
    }
}