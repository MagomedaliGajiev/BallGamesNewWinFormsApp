namespace Balls.Common
{
    public class CatchableBall : MoveBall
    {
        public bool IsCaught { get; set; }

        public CatchableBall(Form form) : base(form)
        {
            _radius = _random.Next(15, 35);
            _centerX = _random.Next(_radius, _form.ClientSize.Width - _radius);
            _centerY = _random.Next(_radius, _form.ClientSize.Height - _radius);
        }
    }
}