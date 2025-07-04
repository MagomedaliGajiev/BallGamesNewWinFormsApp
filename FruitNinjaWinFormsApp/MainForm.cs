using Timer = System.Windows.Forms.Timer;

namespace FruitNinjaWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<FruitBall> _fruits = new List<FruitBall>();
        private List<BombBall> _bombs = new List<BombBall>();
        private Timer _spawnTimer = new Timer();
        private Timer _updateTimer = new Timer();
        private Timer _slowowDownTimer = new Timer();
        private int _score = 0;
        private Label _scoreLabel;
        private Label _slowDownLabel;
        private bool _gameOver = false;
        private Point? _explosionPoint = null;
        private Timer _explosionTimer = new Timer();
        private int _explosionCounter = 0;
        private bool _isSlowed = false;
        private int _slowDownCounter = 0;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // ��������� ��������
            _spawnTimer.Interval = 1000;
            _spawnTimer.Tick += SpawnTimer_Tick;

            _updateTimer.Interval = 20;
            _updateTimer.Tick += UpdateTimer_Tick;

            _explosionTimer.Interval = 100;
            _explosionTimer.Tick += ExplosionTimer_Tick;

            _slowowDownTimer.Interval = 1000;
            _slowowDownTimer.Tick += SlowowDownTimer_Tick;

            // �������� �������� �����
            _scoreLabel = new Label
            {
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Text = "����: 0"
            };
            Controls.Add(_scoreLabel);

            // �������� ���������� ����������
            _slowDownLabel = new Label
            {
                Location = new Point(10, 70),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Text = "",
                Visible = false
            };
            Controls.Add(_slowDownLabel);

            // ������ ����
            _spawnTimer.Start();
            _updateTimer.Start();
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            if (_gameOver) return;

            var random = new Random();
            var type = random.Next(0, 100);

            // 5% - �����, 15% - �����, 80% - ������� ������
            if (type < 5)
            {
                _fruits.Add(new BananaBall(this));
            }
            else if (type < 20)
            {
                _bombs.Add(new BombBall(this));
            }
            else
            {
                _fruits.Add(new FruitBall(this));
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (_gameOver) return;

            // ���������� �������
            for (int i = _fruits.Count - 1; i >= 0; i--)
            {
                var fruit = _fruits[i];
                fruit.Move();

                if (fruit.IsOutOfForm() || fruit.IsSliced)
                {
                    _fruits.RemoveAt(i);
                }
            }

            // ���������� ���� � �������� ������������
            for (int i = _bombs.Count - 1; i >= 0; i--)
            {
                var bomb = _bombs[i];
                bomb.Move();

                // �������� ������������ � �����
                if (bomb.Contains(lastMousePosition))
                {
                    _explosionPoint = new Point((int)bomb.GetCenterX(), (int)bomb.GetCenterY());
                    _bombs.RemoveAt(i);
                    GameOver();
                    _explosionTimer.Start();
                    return;
                }

                if (bomb.IsOutOfForm())
                {
                    _bombs.RemoveAt(i);
                }
            }

            Invalidate();
        }

        private void ExplosionTimer_Tick(object? sender, EventArgs e)
        {
            _explosionCounter++;
            if (_explosionCounter > 5) // ���������� ����� 0.5 �������
            {
                _explosionTimer.Stop();
                _explosionPoint = null;
                _explosionCounter = 0;
            }
            Invalidate();
        }

        private void SlowowDownTimer_Tick(object? sender, EventArgs e)
        {
            _slowDownCounter--;

            _slowDownLabel.Text = $"����������: {_slowDownCounter} ���";

            if (_slowDownCounter <= 0)
            {
                EndSlowDownEffect();
            }
        }

        private void StartSlowDownEffect()
        {
            _isSlowed = true;
            _slowDownCounter = 5; // 5 ������ ����������
            _slowDownLabel.Text = $"����������: {_slowDownCounter} ���";
            _slowDownLabel.Visible = true;
            _slowowDownTimer.Start();

            // ��������� ��� ������������ ������
            foreach (var fruit in _fruits)
            {
                fruit.SlowDown(0.5f);
            }
        }

        private void EndSlowDownEffect()
        {
            _isSlowed = false;
            _slowowDownTimer.Stop();
            _slowDownLabel.Visible = false;

            foreach (var fruit in _fruits)
            {
                fruit.RestoreSpeed();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // ������ ������
            foreach (var fruit in _fruits)
            {
                fruit.Draw(e.Graphics);
            }

            // ������ �����
            foreach (var bomb in _bombs)
            {
                bomb.Draw(e.Graphics);
            }

            // ������ �����, ���� �� ����
            if (_explosionPoint.HasValue)
            {
                using (var brush = new SolidBrush(Color.Red))
                {
                    var size = 20 + _explosionCounter * 5;
                    e.Graphics.FillEllipse(brush,
                        _explosionPoint.Value.X - size / 2,
                        _explosionPoint.Value.Y - size / 2,
                        size, size);
                }
            }
        }

        private Point lastMousePosition;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_gameOver) return;

            lastMousePosition = e.Location;

            for (int i = _fruits.Count - 1; i >= 0; i--)
            {
                if (_fruits[i].Contains(e.Location))
                {
                    // ��������� ��� ������������ ������
                    if (_fruits[i] is BananaBall && !_isSlowed)
                    {
                        StartSlowDownEffect();
                    }

                    _fruits[i].Slice();
                    _score += 10;
                    _scoreLabel.Text = $"����: {_score}";
                }
            }
        }

        private void GameOver()
        {
            _gameOver = true;
            _spawnTimer.Stop();
            _updateTimer.Stop();
            _slowowDownTimer.Stop();

            MessageBox.Show($"���� ��������! ��� ����: {_score}", "Fruit Ninja",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Restart();
        }
    }
}
