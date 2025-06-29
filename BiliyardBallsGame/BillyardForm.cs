namespace BiliyardBallsGame
{
    public partial class BillyardForm : Form
    {
        public BillyardForm()
        {
            InitializeComponent();
        }

        private void BilliardForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var ball = new BillyardBall(this);
                ball.OnHited += Ball_OnHited;
                ball.Start();
            }
        }

        private void Ball_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftLabel.Text = (Convert.ToInt32(leftLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightLabel.Text = (Convert.ToInt32(rightLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topLabel.Text = (Convert.ToInt32(topLabel.Text) + 1).ToString();
                    break;
                case Side.Bottom:
                    bottomLabel.Text = (Convert.ToInt32(bottomLabel.Text) + 1).ToString();
                    break;
            }
        }
    }
}
