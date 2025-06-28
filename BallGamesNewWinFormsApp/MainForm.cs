using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace BallGamesNewWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<MoveBall> _moveBalls = new List<MoveBall>();
        private PointBall _pointBall;
        private Timer _timer;
        private BufferedGraphicsContext _context;
        private BufferedGraphics _buffer;

        public MainForm()
        {
            InitializeComponent();
            // Включение двойной буферизации для устранения мерцания
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            // Обновление стилей
            UpdateStyles();

            SetupDoubleBuffering();
            InitializeTimer();
        }

        private void SetupDoubleBuffering()
        {
            _context = BufferedGraphicsManager.Current;
            _context.MaximumBuffer = new Size(ClientSize.Width + 1, ClientSize.Height + 1);
            _buffer = _context.Allocate(CreateGraphics(), ClientRectangle);
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Tick += (s, e) =>
            {
                UpdateBalls();
                DrawAll();
            };
        }

        private void UpdateBalls()
        {
            if (_moveBalls != null)
            {
                foreach (var ball in _moveBalls)
                {
                    ball.Move();
                }
            }
        }

        private void DrawAll()
        {
            _buffer.Graphics.Clear(BackColor);

            if (_pointBall != null)
            {
                _pointBall.Draw(_buffer.Graphics);
            }

            if (_moveBalls != null)
            {
                foreach (var ball in _moveBalls)
                {
                    ball.Draw(_buffer.Graphics);
                }
            }
            _buffer.Render();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawAll();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Пересоздаем буфер при изменении размера
            if (_buffer != null)
            {
                _buffer.Dispose();
                _buffer = null;
            }
            SetupDoubleBuffering();

            // Обновляем шарики при изменении размера
            if (_moveBalls != null)
            {
                foreach (var ball in _moveBalls)
                {
                    // Корректируем положение шариков, если они вышли за границы
                    ball.EnsureOnForm(ClientSize);
                }
            }

            Refresh();
        }

        private void movingButton_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            _pointBall = new PointBall(this, e.X, e.Y);
            DrawAll();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _timer.Stop();

            var caughtBallsCount = 0;
            foreach (var ball in _moveBalls)
            {
                if (ball.IsOnForm())
                {
                    caughtBallsCount++;
                }
            }
            MessageBox.Show($"Поймано шариков: {caughtBallsCount} из {_moveBalls.Count}");
        }

        private void createBallsButton_Click(object sender, EventArgs e)
        {
            _timer.Stop();

            if (_moveBalls != null)
            {
                // Просто очищаем список, без вызова Dispose()
                _moveBalls.Clear();
            }
            else
            {
                _moveBalls = new List<MoveBall>();
            }

            for (int i = 0; i < 15; i++)
            {
                _moveBalls.Add(new MoveBall(this));
            }

            _timer.Start();
        }

        private void randomPointDrawingButton_Click(object sender, EventArgs e)
        {

        }
    }
}
