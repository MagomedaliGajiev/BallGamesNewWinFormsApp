namespace BallGamesNewWinFormsApp
{
    public class Ball
    {
        private MainForm _form;
        protected int _x = 150;
        protected int _y = 150;
        protected int _size = 50;
        public Ball(MainForm form)
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
    }
}
