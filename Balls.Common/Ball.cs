namespace Balls.Common
{
    public class Ball
    {
        private Form _form;
        private int _vX = 3;
        private int _vY = 3;
        protected int _x = 150;
        protected int _y = 150;
        protected int _size = 50;
        public Ball(Form form)
        {
            _form = form;
        }

        public void Show()
        {
            var graphics = _form.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(_x, _y, _size, _size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        private void Go()
        {
            _x += _vX;
            _y += _vY;
        }

        private void Clear()
        {
            var graphics = _form.CreateGraphics();
            var brush = Brushes.White;
            var rectangle = new Rectangle(_x, _y, _size, _size);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
