namespace BallGamesNewWinFormsApp
{
    public class Ball
    {
        public Ball(MainForm form)
        {
            var graphics = form.CreateGraphics();

            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(150, 150, 100, 100);
            graphics.FillEllipse(brush, rectangle);
        }
    }

    public class RandomPointBall
    {
        private static Random _random = new Random();

        public RandomPointBall(MainForm form)
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.Aqua;

            var rectangle = new Rectangle(150, 150, 100, 100);
            graphics.FillEllipse(brush, rectangle);
        }
    }

}
