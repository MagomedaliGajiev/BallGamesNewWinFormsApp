using Balls.Common;

namespace BallGamesNewWinFormsApp
{
    public class RandomPointBall : Ball
    {
        protected static Random _random = new Random();

        public RandomPointBall(Form form) : base(form)
        {
            _size = 50;
            _x = _random.Next(0, form.ClientSize.Width - _size);
            _y = _random.Next(0, form.ClientSize.Height - _size);
        }
    }
}
