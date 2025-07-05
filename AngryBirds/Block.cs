namespace AngryBirds
{
    public class Block
    {
        public Rectangle Bounds { get; private set; }
        public int Health { get; private set; } = 100;
        private readonly Brush _brush;
        private readonly Pen _pen;

        public Block(int x, int y, int width, int height)
        {
            Bounds = new Rectangle(x, y, width, height);
            _brush = new SolidBrush(Color.SaddleBrown);
            _pen = new Pen(Color.Black, 2);
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(_brush, Bounds);
            graphics.DrawRectangle(_pen, Bounds);
        }

        public bool IntersectsWith(BirdBall bird)
        {
            var birdBounds = new RectangleF(
                bird.GetCenterX() - bird.GetRadius(),
                bird.GetCenterY() - bird.GetRadius(),
                bird.GetRadius() * 2,
                bird.GetRadius() * 2
                );

            return birdBounds.IntersectsWith(Rectangle.Round(birdBounds));
        }

        public void TakeDamage(int demage)
        {
            Health -= demage;
        }
    }
}
