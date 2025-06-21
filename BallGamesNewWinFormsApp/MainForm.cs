namespace BallGamesNewWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void drawingButton_Click(object sender, EventArgs e)
        {
            var ball = new Ball(this);
        }

        private void randomPointDrawingButton_Click(object sender, EventArgs e)
        {
            var randomPointBall = new RandomPointBall(this);
        }
    }
}
