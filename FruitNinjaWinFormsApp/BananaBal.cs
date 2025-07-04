
namespace FruitNinjaWinFormsApp
{
    public class BananaBal : FruitBall
    {
        public BananaBal(Form form) : base(form)
        {
            _color = Color.Yellow;
            _radius = _random.Next(25, 36);
        }
    }
}
