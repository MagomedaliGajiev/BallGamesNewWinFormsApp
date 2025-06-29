using BallGamesNewWinFormsApp;

namespace Balls.Common
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            _radius = _random.Next(15, 40);
        }

        public RandomSizeAndPointBall(Form form, Color color) : base(form, color)
        {
            _radius = _random.Next(15, 40);
        }
    }
}
