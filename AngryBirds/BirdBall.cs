﻿using Balls.Common;

namespace AngryBirds
{
    public class BirdBall : MoveBall
    {
        private float _g = 0.2f;
        private float elastic = 0.4f;
        private bool _isLaunched = false;
        private int _maxX;
        private int _maxY;
        public BirdBall(Form form, int maxX, int maxY) : base(form)
        {
            _maxX = maxX;
            _maxY = maxY;

            _radius = 20;
            _centerX = maxX / 4;
            _centerY = maxY - 150;
            _color = Color.Red;
        }

        public void SetVelocity(float vX, float vY)
        {
            _vX = vX;
            _vY = vY;
            _isLaunched = true;
        }

        public override void Move()
        {
            if (!_isLaunched) return;
            base.Move();
            _vY += _g;

            // Проверка вылета за границы
            if (_centerY > DownSide())
            {
                _vY = -_vY;
                _centerY = DownSide();

                _vY = _vY * elastic;
                _vX = _vX * elastic;
            }
        }

        public bool IsOutOfField()
        {
            return _centerX > _maxX || _centerY > _maxY 
                || _centerX < LeftSide() || _centerY < TopSide();
        }

        public override void Stop()
        {
            _isLaunched = false;
            _vX = 0;
            _vY = 0;
        }

        public override int DownSide()
        {
            return _form.ClientSize.Height - 100 - _radius;
        }
    }
}
