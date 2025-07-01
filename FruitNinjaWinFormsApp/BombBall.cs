using Balls.Common;
using System;
using System.Drawing;

namespace FruitNinjaWinFormsApp
{
    public class BombBall : MoveBall
    {
        private float _g = 0.2f;

        public BombBall(Form form) : base(form)
        {
            _radius = _random.Next(20, 30);
            _centerX = _random.Next(LeftSide(), RightSide());
            _centerY = form.ClientSize.Height + _radius;
            _vY = -_random.Next(5, 10);
            _vX = _random.Next(-3, 4);
            _color = Color.Black;

        }

        public override void Move()
        {
            base.Move();
            _vY += _g;
        }

        public void DrawExplosion(Graphics graphics)
        {
            var brush = new SolidBrush(Color.Red);
            graphics.FillEllipse(brush, _centerX - 10, _centerY - 10, 20, 20);
            brush.Dispose();
        }
    }
}
