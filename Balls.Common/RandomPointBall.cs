using Balls.Common;

namespace BallGamesNewWinFormsApp
{
    public class RandomPointBall : Ball
    {
        public RandomPointBall(Form form) : base(form)
        {
            _centerX = _random.Next(LeftSide() + 50, RightSide() - 50);
            _centerY = _random.Next(TopSide() +50, DownSide() - 50);
        }
    }
}
