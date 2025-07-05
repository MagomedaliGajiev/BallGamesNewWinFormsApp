using Balls.Common;

namespace AngryBirds
{
    public class PigBall : Ball
    {
        public PigBall(Form form, int centerX, int centerY) : base(form)
        {
            _centerX = centerX;
            _centerY = centerY;
            _radius = 15;
            _color = Color.Green;
        }
    }
}
