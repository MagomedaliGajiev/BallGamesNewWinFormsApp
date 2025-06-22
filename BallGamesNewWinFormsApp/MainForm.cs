using Balls.Common;

namespace BallGamesNewWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<MoveBall> _moveBalls;
        private PointBall _pointBall;
        public MainForm()
        {
            InitializeComponent();
        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            _pointBall = new PointBall(this, e.X, e.Y);
            _pointBall.Show();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (var ball in _moveBalls)
            {
                ball.Stop();
            }
        }

        private void CreateBallsButton_Click(object sender, EventArgs e)
        {
            _moveBalls = new List<MoveBall>();
            for (int i = 0; i < 10; i++)
            {
                var moveBall = new MoveBall(this);
                _moveBalls.Add(moveBall);
                moveBall.Start();
            }
        }

        private void randomPointDrawingButton_Click(object sender, EventArgs e)
        {

        }
    }
}
