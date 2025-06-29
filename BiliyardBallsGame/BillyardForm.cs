namespace BiliyardBallsGame
{
    public partial class BillyardForm : Form
    {
        private const int BallCount = 10;
        private readonly List<BillyardBall> _leftBalls = new();
        private readonly List<BillyardBall> _rightBalls = new();
        private readonly List<BillyardBall> _allBalls = new();
        private readonly System.Windows.Forms.Timer timer = new();
        public BillyardForm()
        {
            InitializeComponent();
        }

        private void InitializeGame()
        {
            // Настройка таймера
            timer.Interval = 20;
            timer.Tick += Timer_Tick;

            // Создание шариков
            CreateBalls();
            Paint += MainForm_Paint;
            MouseClick += MainForm_MouseClick;
        }

        private void MainForm_MouseClick(object? sender, MouseEventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        private void CreateBalls()
        {
            // Красные шарики в левой половине
            for (int i = 0; i < BallCount; i++)
            {
                var ball = new BillyardBall(this, Color.Red);
                ball.SetStartPositionInLeftHalf();
                ball.OnHited += Ball_OnHited;
                _leftBalls.Add(ball);
            }

            // Синие шарики в правой половине
            for (int i = 0; i < BallCount; i++)
            {
                var ball = new BillyardBall(this, Color.Blue);
                ball.SetStartPositionInRightHalf();
                ball.OnHited += Ball_OnHited;
                _rightBalls.Add(ball);
            }

            _allBalls.AddRange(_leftBalls);
            _allBalls.AddRange(_rightBalls);
        }

        private void BilliardForm_Load(object sender, EventArgs e)
        {
            InitializeGame();
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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Настройка двойной буферизации
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // Разделительная линия
            e.Graphics.DrawLine(Pens.Black,
                ClientSize.Width / 2, 0,
                ClientSize.Width / 2, ClientSize.Height);

            // Отрисовка шариков
            foreach (var ball in _allBalls)
            {
                ball.Draw(e.Graphics);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var ball in _allBalls)
            {
                ball.Move();
            }

            if (CheckFullMixing())
            {
                timer.Stop();
            }

            Invalidate();
        }

        private bool CheckFullMixing()
        {
            var redInRight = _leftBalls.Count(b => b.GetCenterX() > ClientSize.Width / 2);
            var blueInLeft = _rightBalls.Count(b => b.GetCenterX() < ClientSize.Width / 2);
            var redInLeft = _leftBalls.Count(b => b.GetCenterX() < ClientSize.Width / 2);
            var blueInRight = _rightBalls.Count(b => b.GetCenterX() > ClientSize.Width / 2);
            return redInRight >= BallCount / 2 &&
                   redInLeft >= BallCount / 2 &&
                   blueInLeft >= BallCount / 2 &&
                   blueInRight >= BallCount / 2;
        }
    }
}
