
using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace SalutGame
{
    public partial class MainForm : Form
    {
        private List<Ball> _balls = new List<Ball>();
        private Timer _timer = new();
        private List<RocketBall> _explodingRockets = new List<RocketBall>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object? sender, PaintEventArgs e)
        {
            // ��������� ������� �����������
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            DoubleBuffered = true;



            foreach (var ball in _balls)
            {
                ball.Draw(e.Graphics);
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var random = new Random();
            var count = random.Next(1, 11);
            for (int i = 0; i < count; i++)
            {
                var salutBall = new SalutBall(this, e.Location);
                _balls.Add(salutBall);
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Paint += MainForm_Paint;

            // ��������� �������
            _timer.Interval = 20;
            _timer.Tick += _timer_Tick;
            _timer.Start();

        }

        private void LaunchRocket()
        {
            var rockket = new RocketBall(this);
            rockket.Exploded += Rockket_Exploded;
            _balls.Add(rockket);
        }

        private void Rockket_Exploded(object? sender, EventArgs e)
        {
            if (sender is RocketBall rocket)
            {
                _explodingRockets.Add(rocket);
            }
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            // ��������� �������
            foreach (var rocket in _explodingRockets)
            {
                _balls.Remove(rocket);
                CreateSalut(rocket.GetCenterX(), rocket.GetCenterY());
            }
            _explodingRockets.Clear();

            // �������� �����
            foreach (var ball in _balls.ToList())
            {
                ball.Move();

                // �������� ������� �����
                if (ball.IsOutOfForm())
                {
                    _balls.Remove(ball);
                }
            }
            Invalidate();
        }

        private void CreateSalut(float centerX, float centerY)
        {
            var random = new Random();
            int count = random.Next(5, 15);

            for (int i = 0; i < count; i++)
            {
                var salutBall = new SalutBall(this, new Point((int)centerX, (int)centerY));
                _balls.Add(salutBall);
            }
        }

        private void launchRocketButton_Click(object sender, EventArgs e)
        {
            LaunchRocket();
        }
    }
}
