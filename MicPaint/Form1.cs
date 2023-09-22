using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicPaint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool IsMoving = false;
        Pen p;
        public Form1()
        {
            InitializeComponent();
            g = DrawingCanvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            p = new Pen(Color.Black, 2);
            p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawingCanvas.Dock = DockStyle.Fill;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.BackColor = System.Drawing.Color.Purple;
            numericUpDown1.ForeColor = System.Drawing.Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
            p.Color = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Width = float.Parse(numericUpDown1.Value.ToString());
            numericUpDown1.BackColor = System.Drawing.SystemColors.Window;
            numericUpDown1.ForeColor = System.Drawing.SystemColors.WindowText;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            IsMoving = true;
            x = e.X;
            y = e.Y;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMoving && x != -1 && y != -1)
            {
                g.DrawLine(p, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            IsMoving = false;
            x = -1;
            y = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
