using static System.Formats.Asn1.AsnWriter;
using Timer = System.Windows.Forms.Timer;

namespace FruitNinjaWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<FruitBall> _fruits = new List<FruitBall>();
        private Timer _spawnTimer = new Timer();
        private Timer _updateTimer = new Timer();
        private int _score = 0;
        private Label _scoreLabel;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // Настройка таймеров
            _spawnTimer.Interval = 1000;
            _spawnTimer.Tick += SpawnTimer_Tick;

            _updateTimer.Interval = 20;
            _updateTimer.Tick += UpdateTimer_Tick;

            // Создание счетчика очков
            _scoreLabel = new Label
            {
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Text = "Очки: 0"
            };
            Controls.Add(_scoreLabel);

            // Запуск игры
            _spawnTimer.Start();
            _updateTimer.Start();
        }

        private void SpawnTimer_Tick(object? sender, EventArgs e)
        {
            _fruits.Add(new FruitBall(this));
        }
        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            for (int i = _fruits.Count - 1; i >= 0; i--)
            {
                var fruit = _fruits[i];
                fruit.Move();

                if (fruit.IsOutOfForm() || fruit.IsSliced)
                {
                    _fruits.RemoveAt(i);
                }
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var fruit in _fruits)
            {
                fruit.Draw(e.Graphics);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = _fruits.Count - 1; i >= 0; i--)
            {
                if (_fruits[i].Contains(e.Location))
                {
                    _fruits[i].Slice();
                    _score += 10;
                    _scoreLabel.Text = $"Очки: {_score}";
                }
            }
        }
    }
}
