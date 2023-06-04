using System.Windows;

namespace ZaverecnyProjekt
{
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();

            MazeGenerator mazeGenerator = new MazeGenerator();
            MazeRenderer renderer = new MazeRenderer(myCanvas);
            RenderSettings renderSettings = new RenderSettings();

            renderer.DrawMaze(mazeGenerator.Generate(15, 10), renderSettings);
        }
    }
}
