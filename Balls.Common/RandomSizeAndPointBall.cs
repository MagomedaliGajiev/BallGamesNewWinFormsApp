using BallGamesNewWinFormsApp;

namespace Balls.Common
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            _radius = _random.Next(15, 40);
        }
    }
}
