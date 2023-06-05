using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnyProjekt
{
    internal class MazeSolver
    {
        Stack<Coordinate> stack = new Stack<Coordinate>();
        Direction[,] grid;
        RenderSettings renderSettings;

        public MazeSolver(Direction[,] grid, RenderSettings renderSettings)
        {
            this.grid = grid;
            this.renderSettings = renderSettings;
        }

        public Stack<Coordinate> ShowPath()
        {
            stack.Push(new Coordinate(0, 0));

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (!grid[i, j].HasFlag(Direction.S))
                    {
                        stack.Push(new Coordinate(i++, j));
                    }
                    if (!grid[i, j].HasFlag(Direction.E))
                    {
                        stack.Push(new Coordinate(i, j++));
                    }
                    if(!grid[i, j].HasFlag(Direction.N))
                    {
                        stack.Push(new Coordinate(i--, j));
                    }
                    if (!grid[i, j].HasFlag(Direction.W))
                    {
                        stack.Push(new Coordinate(i, j--));
                    }
                }
            }
            return stack;
        }

    }
}
