using System;

namespace ZaverecnyProjekt
{
    [Flags]
        public enum Direction
        {
            None = 1 << 0,
            N = 1 << 1,
            S = 1 << 2,
            E = 1 << 3,
            W = 1 << 4,
            F = 1 << 5
        }
}
