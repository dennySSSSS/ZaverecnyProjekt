using System.Windows.Media;

namespace ZaverecnyProjekt
{
    public class RenderSettings
    {
        public int CellSize { get; set; } = 50;
        public int WallWidth { get; set; } = 5;
        public Color BackgroundColour { get; set; } = Color.FromArgb(255, 242, 242, 242);
        public Color WallColour { get; set; } = Colors.Black;
        public bool FillBackGround { get; set; }
    }
}
