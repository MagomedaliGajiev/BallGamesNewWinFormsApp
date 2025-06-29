namespace Balls.Common
{
    public class CatchableBall : MoveBall
    {
        public bool IsCaught { get; set; }

        public CatchableBall(Form form) : base(form)
        {
        }
    }
}