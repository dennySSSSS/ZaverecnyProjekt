using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace ZaverecnyProjekt
{
    internal class MazeSolver
    {
        Stack<Coordinate> stack = new Stack<Coordinate>();
        Coordinate startPoint = new Coordinate();
        //Coordinate currentPoint = new Coordinate();
        Coordinate endPoint = new Coordinate(0, 0);
        public int mazeHeight;
        public int mazeWidth;
        RichTextBox debugTextBox;
        public MazeSolver(RichTextBox debugTextBox)
        {
            this.debugTextBox = debugTextBox;
            debugTextBox.Visibility = Visibility.Visible;
        }

        public Stack<Coordinate> FindPath(Direction[,] grid)
        {
            mazeHeight = grid.GetLength(0);
            mazeWidth = grid.GetLength(1);

            startPoint = new Coordinate(0, 0);
            endPoint = new Coordinate(mazeHeight - 1, mazeWidth - 1);

            bool FoundPath = Move(grid, startPoint, endPoint, stack);

            if (FoundPath) return stack;
            else return null;
        }

        private bool Move(Direction[,] grid, Coordinate currentPoint, Coordinate endPoint, Stack<Coordinate> stack)
        {
            if (currentPoint.Equals(endPoint))
            {
                stack.Push(currentPoint);
                
                debugTextBox.AppendText(stack.Peek().X.ToString() + ", " + stack.Peek().Y.ToString() + "\n");
                return true;
            }

            // Nechá původní vlajky a přidá VISITED
            grid[currentPoint.X, currentPoint.Y] |= Direction.VISITED;

            foreach(Coordinate neighbor in GetNeighbors(currentPoint))
            {
                if (!grid[neighbor.X, neighbor.Y].HasFlag(Direction.VISITED))
                {
                    if(Move(grid, neighbor, endPoint, stack))
                    {
                        stack.Push(currentPoint);
                        debugTextBox.AppendText(stack.Peek().X.ToString() + ", " + stack.Peek().Y.ToString() + "\n");
                        return true;
                    }
                }
            }
            grid[currentPoint.X, currentPoint.Y] &= ~Direction.VISITED;
            stack.Pop();
            return false;
        }

        private List<Coordinate> GetNeighbors(Coordinate coordinate)
        {
            List<Coordinate> neighbors = new List<Coordinate>();

            // Získání souřadnic sousedů
            int x = coordinate.X;
            int y = coordinate.Y;

            // Přidáme sousední souřadnice pouze pokud jsou v platném rozsahu pole
            if (x + 1 < mazeWidth)
                neighbors.Add(new Coordinate(x + 1, y)); // Např. pravo
            if (x - 1 >= 0)
                neighbors.Add(new Coordinate(x - 1, y)); // Např. levo
            if (y + 1 < mazeHeight)
                neighbors.Add(new Coordinate(x, y + 1)); // Např. nahoru
            if (y - 1 >= 0)
                neighbors.Add(new Coordinate(x, y - 1)); // Např. dolu

            return neighbors;
        }

    }
}
