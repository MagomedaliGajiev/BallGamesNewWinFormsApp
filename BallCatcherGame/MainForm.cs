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
            // ��������� ������� �����������
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            // ������������� �������
            _gameTimer = new Timer();
            _gameTimer.Interval = 20;
            _gameTimer.Tick += _gameTimer_Tick;

            // ������������� ������ �������
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
            // ������� ���������� ����
            _balls.Clear();
            _caughtCount = 0;
            UpdateScoreLabel();

            // �������� ����� �������
            for (int i = 0; i < _totalBalls; i++)
            {
                _balls.Add(new CatchableBall(this));
            }

            _gameTimer.Start();
            createButton.Enabled = false;
        }

        private void _gameTimer_Tick(object? sender, EventArgs e)
        {
            // ��������� ������� ������ �� ��������� �������
            foreach (var ball in _balls.Where(b => !b.IsCaught))
            {
                ball.Move();
            }

            // ���������, �� ������� �� ��� ������
            CheckForGameOver();

            // ����������� �����
            Invalidate();
        }

        // �������� ������� ���������� ����
        private void CheckForGameOver()
        {
            // ��� ������ �������
            if (_balls.Count == 0)
            {
                EndGame("�����������! �� ������� ��� ������!");
                return;
            }

            // ���������, �������� �� ������ ��������� ������
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
                EndGame("���� ��������! ��� ������ �������!");
            }
        }

        private void EndGame(string message)
        {
            _gameTimer.Stop();
            createButton.Enabled = true;
            MessageBox.Show($"{message}\n��� ���������: {_caughtCount} �� {_totalBalls}");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // ������� ���
            e.Graphics.Clear(BackColor);

            // ������ ������ �� ��������� ������, ������� ��� � ����
            foreach (var ball in _balls)
            {
                if (!ball.IsCaught)
                {
                    ball.Draw(e.Graphics);
                }
            }

            // ����� ������ UI �������� (������, ������)
            base.OnPaint(e);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // ���������� �������� ���� ��� ����������� �������� ���������
            for (int i = _balls.Count - 1; i >= 0; i--)
            {
                var ball = _balls[i];

                if (!ball.IsCaught && ball.Contains(e.Location))
                {
                    ball.IsCaught = true;
                    _caughtCount++;
                    UpdateScoreLabel();

                    // ������� ����� �� ������ ����� ����� ������
                    _balls.RemoveAt(i);

                    // �������������� �����, ����� ������ �����
                    Invalidate();

                    // ��������� ���������� ���� ����� ������
                    CheckForGameOver();
                    break;
                }
            }
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"�������: {_caughtCount} / {_totalBalls}";
        }
    }
}
