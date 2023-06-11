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
        MazeGenerator mazeGenerator;
        MazeRenderer renderer;
        RenderSettings renderSettings;

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();

            mazeGenerator = new MazeGenerator();
            renderer = new MazeRenderer(myCanvas);
            renderSettings = new RenderSettings();

            grid = mazeGenerator.Generate((int)SliderHeight.Value, (int)SliderWidth.Value);
            renderer.DrawMaze(grid, renderSettings);
        }
    }
}