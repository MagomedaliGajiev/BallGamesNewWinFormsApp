namespace BiliyardBallsGame
{
    public partial class BillyardForm : Form
    {
        private const int BallCount = 10;
        private readonly List<BillyardBall> _redBalls = new();
        private readonly List<BillyardBall> _blueBalls = new();
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
                ball.OnHited += RedBall_OnHited;
                _redBalls.Add(ball);
            }

            // Синие шарики в правой половине
            for (int i = 0; i < BallCount; i++)
            {
                var ball = new BillyardBall(this, Color.Blue);
                ball.SetStartPositionInRightHalf();
                ball.OnHited += BlueBall_OnHited;
                _blueBalls.Add(ball);
            }

            _allBalls.AddRange(_redBalls);
            _allBalls.AddRange(_blueBalls);
        }

        private void BilliardForm_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void RedBall_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    redBallLeftLabel.Text = (Convert.ToInt32(redBallLeftLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    redBallRightLabel.Text = (Convert.ToInt32(redBallRightLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    redBallTopLabel.Text = (Convert.ToInt32(redBallTopLabel.Text) + 1).ToString();
                    break;
                case Side.Bottom:
                    redBallBottomLabel.Text = (Convert.ToInt32(redBallBottomLabel.Text) + 1).ToString();
                    break;
            }
        }

        private void BlueBall_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    blueBallLeftLabel.Text = (Convert.ToInt32(blueBallLeftLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    blueBallRightLabel.Text = (Convert.ToInt32(blueBallRightLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    blueBallTopLabel.Text = (Convert.ToInt32(blueBallTopLabel.Text) + 1).ToString();
                    break;
                case Side.Bottom:
                    blueBallBottomLabel.Text = (Convert.ToInt32(blueBallBottomLabel.Text) + 1).ToString();
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
            var redInRight = _redBalls.Count(b => b.GetCenterX() - b.GetRadius() > ClientSize.Width / 2);
            var blueInLeft = _blueBalls.Count(b => b.GetCenterX() + b.GetRadius() < ClientSize.Width / 2);
            var redInLeft = _redBalls.Count(b => b.GetCenterX() + b.GetRadius() < ClientSize.Width / 2);
            var blueInRight = _blueBalls.Count(b => b.GetCenterX() - b.GetRadius() > ClientSize.Width / 2);
            return redInRight >= BallCount / 2 &&
                   redInLeft >= BallCount / 2 &&
                   blueInLeft >= BallCount / 2 &&
                   blueInRight >= BallCount / 2;
        }
    }
}
