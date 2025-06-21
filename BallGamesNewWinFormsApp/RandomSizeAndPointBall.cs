namespace BallGamesNewWinFormsApp
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(MainForm form) : base(form)
        {
            _size = _random.Next(30, 80);
        }
    }
}
