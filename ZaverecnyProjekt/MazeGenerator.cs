using System;
using System.Collections.Generic;
using System.Linq;

namespace ZaverecnyProjekt
{
    internal class MazeGenerator
    {
        private const Direction AllDirections = Direction.E | Direction.S | Direction.W | Direction.N;
        readonly Dictionary<Direction, int> DX = new Dictionary<Direction, int>() {
                { Direction.E , 1},
                { Direction.N , 0},
                { Direction.W , -1},
                { Direction.S , 0}
            };

        readonly Dictionary<Direction, int> DY = new Dictionary<Direction, int>() {
                { Direction.E , 0},
                { Direction.N , -1},
                { Direction.W , 0},
                { Direction.S , 1}
            };

        readonly Dictionary<Direction, Direction> Reverse = new Dictionary<Direction, Direction>() {
                { Direction.E , Direction.W},
                { Direction.N , Direction.S},
                { Direction.W , Direction.E},
                { Direction.S , Direction.N}

            };
        protected Random random = new Random();
        public int Height { get; private set; }
        public int Width { get; private set; }

        /// <summary>
        /// Generates a maze with set height and width.
        /// </summary>
        /// <param name="height">Height of the maze.</param>
        /// <param name="width">Width of the maze.</param>
        /// <returns>Maze array.</returns>
        public Direction[,] Generate(int height, int width)
        {
            Direction[,] grid = new Direction[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = AllDirections;
                }
            }

            Height = grid.GetLength(0);
            Width = grid.GetLength(1);

            Coordinate start = FindStart(grid);
            //Coordinate start = new Coordinate(3, 5);
            Coordinate end = FindEnd(grid);

            grid = MoveFrom(start.Y, start.X, grid);

            grid[start.Y, start.X] &= ~Direction.W;
            grid[end.Y, end.X] &= ~Direction.E;

            return grid;
        }

        private Coordinate FindStart(Direction[,] grid)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (grid[i, j].HasFlag(AllDirections))
                        return new Coordinate(j, i);
                }
            }

            return new Coordinate(0, 0);
        }

        private Coordinate FindEnd(Direction[,] grid)
        {
            for (int i = Height - 1; i > 0; i--)
            {
                for (int j = Width - 1; j > 0; j--)
                {
                    if (grid[i, j].HasFlag(AllDirections))
                        return new Coordinate(j, i);
                }
            }

            return new Coordinate(0, 0);
        }

        private Direction[,] MoveFrom(int row, int col, Direction[,] grid)
        {
            var directions = GetDirections();

            foreach (Direction direction in directions)
            {
                int newCol = col + DX[direction];
                int newRow = row + DY[direction];

                if (IsAvailable(grid, newCol, newRow))
                {

                    grid[row, col] &= ~direction;
                    grid[newRow, newCol] &= ~Reverse[direction];

                    grid = MoveFrom(newRow, newCol, grid);
                }
            }
            return grid;
        }

        private IOrderedEnumerable<Direction> GetDirections()
        {
            return new[] { Direction.E, Direction.S, Direction.W, Direction.N }
                            .OrderBy(a => random.Next());
        }

        private bool IsAvailable(Direction[,] grid, int newCol, int newRow)
        {
            return newCol <= Width - 1 && newCol >= 0 && newRow <= Height - 1 && newRow >= 0 && grid[newRow, newCol] == AllDirections;
        }
    }
}
