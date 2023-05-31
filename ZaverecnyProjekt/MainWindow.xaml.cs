using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ZaverecnyProjekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random random = new Random();
        

        int width = 5;
        int height = 5;
        int squareSize = 20;
        public void drawArray()
        {
            Color[,] colors = new Color[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    byte red = (byte)random.Next(256); // Náhodná hodnota pro červenou složku
                    byte green = (byte)random.Next(256); // Náhodná hodnota pro zelenou složku
                    byte blue = (byte)random.Next(256); // Náhodná hodnota pro modrou složku

                    colors[i, j] = Color.FromArgb(255, red, green, blue); // Vytvoření barevné struktury
                    SolidColorBrush solidColorBrush = new SolidColorBrush(colors[i, j]);
                    drawSquare(i * squareSize, j * squareSize, squareSize, solidColorBrush);
                    //drawSquare(0, 0, squareSize, Brushes.Red);
                }
            }
        }
        public void drawSquare(int x, int y, int squareSize, Brush brush)
        {
            Rectangle rect = new Rectangle();
            TransformGroup transformGroup = new TransformGroup();

            rect.Width = squareSize;
            rect.Height = squareSize;
            rect.Fill = brush;

            
            transformGroup.Children.Add(new TranslateTransform(x, y));
            rect.RenderTransform = transformGroup;

            myCanvas.Children.Add(rect);
        }

        private bool[,] maze;
        private int mazeWidth;
        private int mazeHeight;
        public void GenerateMaze(int width, int height)
        {
            mazeWidth = width;
            mazeHeight = height;
            maze = new bool[mazeWidth, mazeHeight];

            // Inicializace bludiště s vnějšími stěnami
            for (int i = 0; i < mazeWidth; i++)
            {
                for (int j = 0; j < mazeHeight; j++)
                {
                    if (i == 0 || j == 0 || i == mazeWidth - 1 || j == mazeHeight - 1)
                        maze[i, j] = true;
                }
            }

            // Generování bludiště
            GenerateMazeRecursive(2, 2);

            // Vykreslení bludiště na Canvas
            DrawMaze();
        }

        private bool[,] visited;
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        private int[] dx = { 0, 0, -1, 1 }; // Změna souřadnice x pro směry: Up, Down, Left, Right
        private int[] dy = { -1, 1, 0, 0 }; // Změna souřadnice y pro směry: Up, Down, Left, Right
        private bool IsInsideMaze(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
        private Rectangle GetCellAtPosition(int x, int y)
        {
            Rectangle cell = new Rectangle();
            cell.Width = squareSize;
            cell.Height = squareSize;
            Canvas.SetLeft(cell, x * squareSize);
            Canvas.SetTop(cell, y * squareSize);
            // Další nastavení vlastností buňky, např. barva, okraj atd.
            return cell;
        }

        private void RemoveWallBetweenCells(int x, int y, Direction direction)
        {
            // Implementace logiky pro odstranění stěny mezi dvěma buňkami
            // Zde můžete například nastavit barvu odpovídající průchodu mezi buňkami nebo
            // upravit nějakou vlastnost buňky, která reprezentuje stěnu

            // Příklad: Nastavení průchodu mezi buňkami na prázdnou barvu
            int newX = x + dx[(int)direction];
            int newY = y + dy[(int)direction];
            Rectangle cell = GetCellAtPosition(newX, newY);
            cell.Fill = Brushes.White;
        }

        private void GenerateMazeRecursive(int x, int y)
        {
            visited[x, y] = true;

            List<Direction> directions = new List<Direction>
            {
                Direction.Up,
                Direction.Down,
                Direction.Left,
                Direction.Right
            };

            ShuffleList(directions); // Náhodné zamíchání seznamu směrů

            foreach (Direction direction in directions)
            {
                int newX = x + dx[(int)direction];
                int newY = y + dy[(int)direction];

                if (IsInsideMaze(newX, newY) && !visited[newX, newY])
                {
                    RemoveWallBetweenCells(x, y, direction);

                    GenerateMazeRecursive(newX, newY);
                }
            }
        }

        private void DrawMaze()
        {
            myCanvas.Children.Clear();

            int squareSize = 20; // Velikost jednoho čtverce v bludišti

            for (int i = 0; i < mazeWidth; i++)
            {
                for (int j = 0; j < mazeHeight; j++)
                {
                    if (maze[i, j])
                    {
                        SolidColorBrush wallBrush = new SolidColorBrush(Colors.Black);
                        drawSquare(i * squareSize, j * squareSize, squareSize, wallBrush);
                    }
                    else
                    {
                        SolidColorBrush pathBrush = new SolidColorBrush(Colors.White);
                        drawSquare(i * squareSize, j * squareSize, squareSize, pathBrush);
                    }
                }
            }
        }
        private void ShuffleList<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            //drawArray();
            GenerateMaze(20, 20);
        }
    }
}
