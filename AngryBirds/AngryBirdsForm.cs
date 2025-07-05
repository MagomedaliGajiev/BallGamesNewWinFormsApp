using Timer = System.Windows.Forms.Timer;

namespace AngryBirds
{
    public partial class AngryBirdsForm : Form
    {
        private BirdBall _bird;
        private List<PigBall> _pigs = new List<PigBall>();
        private List<Block> _blocks = new List<Block>();
        private Slingshot _slingshot;
        private Timer _gameTimer;
        private bool _isDragging = false;
        private Point _dragStart;
        private Point _dragEnd;
        private Pen _trajectoryPen = new Pen(Color.LightGray, 1);
        private int _score = 0;
        private Label _scoreLabel;
        public AngryBirdsForm()
        {
            InitializeComponent();
            MouseDown += AngryBirdsForm_MouseDown;
            MouseMove += AngryBirdsForm_MouseMove;
            MouseUp += AngryBirdsForm_MouseUp;
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Настройка окна
            ClientSize = new Size(800, 600);
            DoubleBuffered = true;
            BackColor = Color.LightBlue;

            // Создание объектов
            _slingshot = new Slingshot(150, 450);
            _bird = new BirdBall(this, ClientSize.Width, ClientSize.Height);

            // Создание препятствий
            CreateLevel();

            // Создание счетчика
            _scoreLabel = new Label
            {
                Location = new Point(10, 10),
                ForeColor = Color.Black,
                Text = $"Очки: {_score}",
                AutoSize = true
            };
            Controls.Add(_scoreLabel);

            // Настройка таймера
            _gameTimer = new Timer();
            _gameTimer.Interval = 20;
            _gameTimer.Tick += GameTimer_Tick;
            _gameTimer.Start();
        }

        private void CreateLevel()
        {
            // Создание свиней
            _pigs.Add(new PigBall(this, 700, 450));
            _pigs.Add(new PigBall(this, 650, 450));

            // Создание блоков
            _blocks.Add(new Block(600, 400, 80, 20));
            _blocks.Add(new Block(650, 380, 80, 20));
            _blocks.Add(new Block(700, 360, 80, 20));
            _blocks.Add(new Block(620, 320, 30, 80));
            _blocks.Add(new Block(720, 320, 30, 80));
        }

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            _bird.Move();
            CheckCollisions();
            Invalidate();
        }

        private void CheckCollisions()
        {
            // Проверка столкновений с блоками
            for (int i = _blocks.Count - 1; i >= 0; i--)
            {
                if (_blocks[i].IntersectsWith(_bird))
                {
                    _blocks[i].TakeDamage(25);
                    if (_blocks[i].Health <= 0)
                    {
                        _blocks.RemoveAt(i);
                        _score += 50;
                    }
                    else
                    {
                        _score += 10;
                    }
                    UpdateScore();
                }
            }

            // Проверка столкновений со свиньями
            for (int i = _pigs.Count - 1; i >= 0; i--)
            {
                if (_pigs[i].Contains(_bird.GetCenterX(), _bird.GetCenterY()))
                {
                    _pigs.RemoveAt(i);
                    _score += 100;
                    UpdateScore();
                }
            }

            // Проверка завершения уровня
            if (_pigs.Count == 0)
            {
                _gameTimer.Stop();
                MessageBox.Show($"Уровень пройден! Ваш счет: {_score}", "Победа!");
                InitializeGame();
            }

            // Проверка вылета птицы
            if (_bird.IsOutOfField())
            {
                _bird.Stop();
                _bird = new BirdBall(this, ClientSize.Width, ClientSize.Height);
            }
        }

        private void UpdateScore()
        {
            _scoreLabel.Text = $"Очки: {_score}";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;

            // Отрисовка земли
            graphics.FillRectangle(Brushes.Green, 0, 500, ClientSize.Width, 100);

            // Отрисовка рогатки
            _slingshot.Draw(graphics);

            // Отрисовка птицы
            _bird.Draw(graphics);

            // Отрисовка свиней
            foreach (var pig in _pigs)
            {
                pig.Draw(graphics);
            }

            // Отрисовка блоков
            foreach (var block in _blocks)
            {
                block.Draw(graphics);
            }

            // Отрисовка траектории
            if (_isDragging)
            {
                DrawTrajectory(graphics);
            }
        }

        private void DrawTrajectory(Graphics graphics)
        {
            var dx = _dragStart.X - _dragEnd.X;
            var dy = _dragStart.Y - _dragEnd.Y;
            var vx = dx * 0.1f;
            var vy = dy * 0.1f;
            var x = _bird.GetCenterX();
            var y = _bird.GetCenterY();
            var g = 0.2f;

            for (int i = 0; i < 100; i++)
            {
                var nextX = x + vx;
                var nextY = y + vy;
                graphics.DrawLine(_trajectoryPen, x, y, nextX, nextY);
                x = nextX;
                y = nextY;
                vy += g;
            }
        }

        private void AngryBirdsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                Math.Sqrt(Math.Pow(e.X - _bird.GetCenterX(), 2) +
                          Math.Pow(e.Y - _bird.GetCenterY(), 2)) <= _bird.GetRadius())
            {
                _isDragging = true;
                _dragStart = new Point((int)_bird.GetCenterX(), (int)_bird.GetCenterY());
            }
        }

        private void AngryBirdsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                _dragEnd = e.Location;
                Invalidate();
            }
        }

        private void AngryBirdsForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                float dx = _dragStart.X - e.X;
                float dy = _dragStart.Y - e.Y;
                _bird.SetVelocity(dx * 0.1f, dy * 0.1f);
            }
        }
    }
}
