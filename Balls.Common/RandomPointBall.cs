using Balls.Common;

namespace BallGamesNewWinFormsApp
{
    public class RandomPointBall : Ball
    {
        public RandomPointBall(Form form) : base(form)
        {
            _centerX = _random.Next(LeftSide(), RightSide());
            _centerY = _random.Next(TopSide(), DownSide());
        }

        public RandomPointBall(Form form, Color color) : base(form, color)
        {
            _centerX = _random.Next(LeftSide(), RightSide());
            _centerY = _random.Next(TopSide(), DownSide());
        }
    }
}
