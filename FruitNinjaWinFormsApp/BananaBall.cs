
namespace FruitNinjaWinFormsApp
{
    public class BananaBall : FruitBall
    {
        public BananaBall(Form form) : base(form)
        {
            _color = Color.Yellow;
            _radius = _random.Next(25, 36);
        }
    }
}
