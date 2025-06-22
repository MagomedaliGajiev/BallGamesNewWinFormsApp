using BallGamesNewWinFormsApp;

namespace Balls.Common
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            _size = _random.Next(30, 80);
        }
    }
}
