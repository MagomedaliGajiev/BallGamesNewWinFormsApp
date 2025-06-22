using Balls.Common;

namespace BallGamesNewWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<MoveBall> _moveBalls = new List<MoveBall>();
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
            var caughtBallsCount = 0;
            foreach (var ball in _moveBalls)
            {
                ball.Stop();
                if (ball.IsOnForm())
                {
                    caughtBallsCount++;
                }
            }
            MessageBox.Show($"Поймано шариков: {caughtBallsCount} из {_moveBalls.Count}");
        }

        private void createBallsButton_Click(object sender, EventArgs e)
        {
            // Остановить и очистить предыдущие шарики
            foreach (var ball in _moveBalls)
            {
                ball.Stop();
            }
            _moveBalls.Clear();

            // Создать новые шарики (15 штук)
            for (int i = 0; i < 15; i++)
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
