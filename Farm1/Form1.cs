using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Farm1.Classes;

namespace Farm1
{
    public partial class Form1 : Form
    {
        private Bitmap GeneralBitmap;
        private Graphics Graphics;

        public Random rnd = new Random();
        
        public Brush color;

        public int date = 0;
 
        public bool eat = false;

        private void InitializeMap()
        {
            GeneralBitmap = new Bitmap(Map.Width * Map.CellSize, Map.Height * Map.CellSize);
            pictureBox.Size = GeneralBitmap.Size;
            pictureBox.Image = GeneralBitmap;
            Graphics = Graphics.FromImage(pictureBox.Image);
        }

        public Form1()
        {
            InitializeComponent();
            InitializeMap();

            PaintingSimulationObjects(LifeSimulation.InitializeLifeSimulation());
        }

        private void PaintingLines()
        {  
            for (int i = 0; i <= Map.Width; i++)
                Graphics.DrawLine(Pens.Black, 1, i * Map.CellSize + 1, Map.Width * Map.CellSize, i * Map.CellSize + 1);
            for (int i = 0; i <= Map.Height; i++)
                Graphics.DrawLine(Pens.Black, i * Map.CellSize + 1, 1, i * Map.CellSize + 1, Map.Height * Map.CellSize);
        }

        private void PaintingSimulationObjects(List<Point> cells)
        {
            foreach (var cell in cells)
            {
                if (Map.Area[cell.Y * Map.Width + cell.X].Objects.Count != 0)
                {
                    SolidBrush solidBrush = new SolidBrush(Map.Area[cell.Y * Map.Width + cell.X].Objects.Last().Color);
                    DrawRectangle(solidBrush, cell);
                }
                else
                {
                    SolidBrush solidBrush = new SolidBrush(Color.White);
                    DrawRectangle(solidBrush, cell);
                }
            }
        }

        private void DrawRectangle(SolidBrush solidBrush, Point point)
        {
            Graphics.FillRectangle(solidBrush, Map.CellSize * point.X, Map.CellSize * point.Y, Map.CellSize, Map.CellSize);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PaintingLines();
            PaintingSimulationObjects(LifeSimulation.UpdateSimulation());
            pictureBox.Refresh();

            date++;
            labelDay.Text = "Day: " + date;
            labelAnimals.Text = "Animals: ";
            labelPlants.Text = "Plants: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = 101 - (int)numericUpDown1.Value;
            timer1.Interval = r;
        }
    }
}
