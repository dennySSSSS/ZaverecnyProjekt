using System.Windows;

namespace ZaverecnyProjekt
{
    public partial class MainWindow : Window
    {
        private const Direction AllDirections = Direction.E | Direction.S | Direction.W | Direction.N;


        

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();

            MazeGenerator mazeGenerator = new MazeGenerator();
            //mazeGenerator.Generate();


            MazeRenderer renderer = new MazeRenderer(myCanvas);
            RenderSettings renderSettings = new RenderSettings();
            renderer.DrawMaze(mazeGenerator.Generate(5, 10), renderSettings);

        }
    }
}
