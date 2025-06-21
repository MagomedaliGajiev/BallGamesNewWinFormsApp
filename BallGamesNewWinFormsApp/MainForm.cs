namespace BallGamesNewWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void drawingButton_Click(object sender, EventArgs e)
        {
            var ball = new Ball(this);
            ball.Show();
        }

        private void randomPointDrawingButton_Click(object sender, EventArgs e)
        {
            var randomPointBall = new RandomSizeAndPointBall(this);
            randomPointBall.Show();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var pointBall = new PointBall(this, e.X, e.Y);
            pointBall.Show();
        }
    }
}
