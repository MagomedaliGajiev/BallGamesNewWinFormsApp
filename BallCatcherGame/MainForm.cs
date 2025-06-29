using Balls.Common;
using Timer = System.Windows.Forms.Timer;

namespace BallCatcherGame
{
    public partial class MainForm : Form
    {
        private List<CatchableBall> _balls;
        private Timer _gameTimer;
        private int _caughtCount;
        private int _totalBalls = 10;
        public MainForm()
        {
            InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            // Настройка двойной буферизации
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // Инициализация таймера
            _gameTimer = new Timer();
            _gameTimer.Interval = 20;
            _gameTimer.Tick += _gameTimer_Tick;

            // Инициализация списка шариков
            _balls = new List<CatchableBall>();
            _caughtCount = 0;
            UpdateScoreLabel();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            // Очистка предыдущей игры
            _balls.Clear();
            _caughtCount = 0;
            UpdateScoreLabel();

            // Создание новых шариков
            for (int i = 0; i < _totalBalls; i++)
            {
                _balls.Add(new CatchableBall(this));
            }

            _gameTimer.Start();
            createButton.Enabled = false;
        }

        private void _gameTimer_Tick(object? sender, EventArgs e)
        {
            // Обновляем позиции только не пойманных шариков
            foreach (var ball in _balls.Where(b => !b.IsCaught))
            {
                ball.Move();
            }

            // Проверяем, не улетели ли все шарики
            CheckForGameOver();

            // Перерисовка формы
            Invalidate();
        }

        // Проверка условий завершения игры
        private void CheckForGameOver()
        {
            // Все шарики пойманы
            if (_balls.Count == 0)
            {
                EndGame("Поздравляем! Вы поймали все шарики!");
                return;
            }

            // Проверяем, остались ли только улетевшие шарики
            var allBallsOut = true;
            foreach (var ball in _balls)
            {
                if (!ball.IsCaught && !ball.IsOutOfForm())
                {
                    allBallsOut = false;
                    break;
                }
            }

            if (allBallsOut)
            {
                EndGame("Игра окончена! Все шарики улетели!");
            }
        }

        private void EndGame(string message)
        {
            _gameTimer.Stop();
            createButton.Enabled = true;
            MessageBox.Show($"{message}\nВаш результат: {_caughtCount} из {_totalBalls}");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Очищаем фон
            e.Graphics.Clear(BackColor);

            // Рисуем только не пойманные шарики, которые еще в игре
            foreach (var ball in _balls)
            {
                if (!ball.IsCaught)
                {
                    ball.Draw(e.Graphics);
                }
            }

            // Также рисуем UI элементы (кнопки, лейблы)
            base.OnPaint(e);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Используем обратный цикл для безопасного удаления элементов
            for (int i = _balls.Count - 1; i >= 0; i--)
            {
                var ball = _balls[i];

                if (!ball.IsCaught && ball.Contains(e.Location))
                {
                    ball.IsCaught = true;
                    _caughtCount++;
                    UpdateScoreLabel();

                    // Удаляем шарик из списка сразу после поимки
                    _balls.RemoveAt(i);

                    // Перерисовываем форму, чтобы убрать шарик
                    Invalidate();

                    // Проверить завершение игры после поимки
                    CheckForGameOver();
                    break;
                }
            }
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Поймано: {_caughtCount} / {_totalBalls}";
        }
    }
}
