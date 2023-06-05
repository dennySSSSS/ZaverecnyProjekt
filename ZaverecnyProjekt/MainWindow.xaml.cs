using System.Windows;

namespace ZaverecnyProjekt
{
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {
            InitializeComponent();
        }

        Direction[,] grid;
        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();

            MazeGenerator mazeGenerator = new MazeGenerator();
            MazeRenderer renderer = new MazeRenderer(myCanvas);
            RenderSettings renderSettings = new RenderSettings();

            grid = mazeGenerator.Generate(15, 10);
            renderer.DrawMaze(grid, renderSettings);
        }

        private void solveButton_Click(object sender, RoutedEventArgs e)
        {
            MazeSolver mazeSolver = new MazeSolver(grid);
            mazeSolver.ShowPath();
        }
    }
}
