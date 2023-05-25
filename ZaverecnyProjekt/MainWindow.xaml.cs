using System.Windows;
using System.Windows.Shapes;

namespace ZaverecnyProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Line line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Red;
            line.X1 = 1;
            line.X2 = 50;
            line.Y1 = 1;
            line.Y2 = 50;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;
            line.StrokeThickness = 2;
            myCanvas.Children.Add(line);

        }

        void drawArray()
        {
            
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
