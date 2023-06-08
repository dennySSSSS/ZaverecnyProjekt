using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ZaverecnyProjekt
{
    internal class MazeRenderer
    {
        private Canvas myCanvas; // Členská proměnná pro uchování odkazu na myCanvas

        public MazeRenderer(Canvas canvas)
        {
            myCanvas = canvas; // Uložení odkazu na myCanvas do členské proměnné
        }


        /// <summary>
        /// Funkce která vykreslí bludiště.
        /// </summary>
        /// <param name="grid">Pole bludiště</param>
        /// <param name="settings">Nastavení</param>
        /// <returns>Vratí true, když namaluje bludiště.</returns>
        public bool DrawMaze(Direction[,] grid, RenderSettings settings)
        {
            int mazeHeight = grid.GetLength(0);
            int mazeWidth = grid.GetLength(1);

            for (int row = 0; row < mazeHeight; row++)
            {
                for (int col = 0; col < mazeWidth; col++)
                {
                    DrawCell(grid, row, col, settings);
                }
            }

            return true;
        }

        public bool DrawPath(Stack<Coordinate> stack, RenderSettings settings)
        {

            //stack.Peek();

            return true;
        }


        /// <summary>
        /// Nakreslí stěny jednotlivých buněk
        /// </summary>
        /// <param name="grid">Pole bludiště</param>
        /// <param name="row">Aktuální řada</param>
        /// <param name="col">Aktuální sloupec</param>
        /// <param name="settings">Nastavení</param>
        private void DrawCell(Direction[,] grid, int row, int col, RenderSettings settings)
        {
            int cellSize = settings.CellSize;
            int wallWidth = settings.WallWidth;

            SolidColorBrush WallBrush = new SolidColorBrush(settings.WallColour);
            SolidColorBrush CellBrush = new SolidColorBrush(settings.BackgroundColour);

            int xOffset = col * cellSize + settings.WallWidth / 2 + cellSize;
            int yOffset = row * cellSize + settings.WallWidth / 2 + cellSize;

            if (settings.FillBackGround)
                drawSquare(xOffset, yOffset, cellSize, CellBrush);

            if (grid[row, col].HasFlag(Direction.N))
                DrawLine(new Point(xOffset, yOffset), new Point(xOffset + cellSize, yOffset), WallBrush.Color, wallWidth);

            if (grid[row, col].HasFlag(Direction.S))
                DrawLine(new Point(xOffset, yOffset + cellSize), new Point(xOffset + cellSize, yOffset + cellSize), WallBrush.Color, wallWidth);

            if (grid[row, col].HasFlag(Direction.E))
                DrawLine(new Point(xOffset + cellSize, yOffset), new Point(xOffset + cellSize, yOffset + cellSize), WallBrush.Color, wallWidth);

            if (grid[row, col].HasFlag(Direction.W))
                DrawLine(new Point(xOffset, yOffset), new Point(xOffset, yOffset + cellSize), WallBrush.Color, wallWidth);
        }


        private void drawSquare(int x, int y, int squareSize, Brush brush)
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

        private void DrawLine(Point startPoint, Point endPoint, Color color, double thickness)
        {

            Line line = new Line
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = thickness,
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = endPoint.X,
                Y2 = endPoint.Y
            };

            myCanvas.Children.Add(line);
        }
    }
}
