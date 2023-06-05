﻿using System.Windows;

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
            solveButton.IsEnabled = true;

            mazeGenerator = new MazeGenerator();
            renderer = new MazeRenderer(myCanvas);
            renderSettings = new RenderSettings();

            grid = mazeGenerator.Generate(15, 10);
            renderer.DrawMaze(grid, renderSettings);
        }

        private void solveButton_Click(object sender, RoutedEventArgs e)
        {
            MazeSolver mazeSolver = new MazeSolver(grid, renderSettings);
            mazeSolver.ShowPath();
        }
    }
}
