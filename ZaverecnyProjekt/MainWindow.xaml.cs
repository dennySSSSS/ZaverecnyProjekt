using System.Windows;

namespace ZaverecnyProjekt
{
    public partial class MainWindow : Window
    {
        private const Direction AllDirections = Direction.E | Direction.S | Direction.W | Direction.N;
        Direction[,] grid = new Direction[5, 5]
        {
            { AllDirections, AllDirections, AllDirections, AllDirections, AllDirections },
            { AllDirections, AllDirections, AllDirections, AllDirections, AllDirections },
            { AllDirections, AllDirections, AllDirections, AllDirections, AllDirections },
            { AllDirections, AllDirections, AllDirections, AllDirections, AllDirections },
            { AllDirections, AllDirections, AllDirections, AllDirections, AllDirections }
        };

        public MainWindow()
        {
            InitializeComponent();

            MazeGenerator mazeGenerator = new MazeGenerator();
            mazeGenerator.Generate(grid);


            MazeRenderer renderer = new MazeRenderer(myCanvas);
            RenderSettings renderSettings = new RenderSettings();
            renderer.DrawMaze(grid, renderSettings);

        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            //drawArray();


        }
    }
}
