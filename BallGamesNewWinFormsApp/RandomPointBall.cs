namespace BallGamesNewWinFormsApp
{
    public class RandomPointBall
    {
        private static Random _random = new Random();

        public RandomPointBall(MainForm form)
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.Aqua;
            var x = _random.Next(0, form.ClientSize.Width);
            var y = _random.Next(0, form.ClientSize.Height);
            var rectangle = new Rectangle(x, y, 100, 100);
            graphics.FillEllipse(brush, rectangle);
        }
    }

}
