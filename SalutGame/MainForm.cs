
using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace SalutGame
{
    public partial class MainForm : Form
    {
        private List<Ball> _balls = new List<Ball>();
        private Timer _timer = new();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object? sender, PaintEventArgs e)
        {
            // Настройка двойной буферизации
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            

            foreach (var ball in _balls)
            {
                ball.Draw(e.Graphics);
            }
            _timer.Start();

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

        private void _timer_Tick(object? sender, EventArgs e)
        {
            foreach (var ball in _balls)
            {
                ball.Move();
            }

            Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Paint += MainForm_Paint;

            // Настройка таймера
            _timer.Interval = 20;
            _timer.Tick += _timer_Tick;

            _timer.Start();
        }
    }
}
