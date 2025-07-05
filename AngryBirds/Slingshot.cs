namespace AngryBirds
{
    public class Slingshot
    {
        private Point _possition;
        private const int Width = 30;
        private const int Heigght = 100;
        private readonly Pen _pen = new Pen(Color.Brown, 5);

        public Slingshot(int x, int y)
        {
            _possition = new Point(x, y);
        }

        public void Draw(Graphics graphics)
        {
            // Рисуем рогатку
            graphics.DrawLine(_pen,
                _possition.X, _possition.Y + Heigght,
                _possition.X - Width, _possition.Y);

            graphics.DrawLine(_pen,
                _possition.X, _possition.Y + Heigght,
                _possition.X + Width, _possition.Y);
        }

        public Point GetPoint()
        {
            return new Point(_possition.X, _possition.Y);
        }
    }
}
