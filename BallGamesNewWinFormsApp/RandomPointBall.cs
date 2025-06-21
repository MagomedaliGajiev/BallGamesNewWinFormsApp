namespace BallGamesNewWinFormsApp
{
    public class RandomPointBall : Ball
    {
        protected static Random _random = new Random();

        public RandomPointBall(MainForm form) : base(form)
        {
            _x = _random.Next(0, form.ClientSize.Width);
            _y = _random.Next(0, form.ClientSize.Height);
        }
    }
}
