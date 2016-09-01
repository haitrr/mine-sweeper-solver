using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tessnet2;

namespace MineSweeperSolver
{
    public partial class MainForm : Form
    {
        Color mapPanelColor = Color.Gray;
        Solver solver;
        int maxRank = 30;
        int maxColumn = 30;
        int defaultRank=8;
        int defaultColumn=8;
        int squareSize = 20;
        public MainForm()
        {
            InitializeComponent();
            Square.size = squareSize;
            Square.font=new Font("Arial", squareSize/2);
            setMap(defaultRank, defaultColumn);
            inputColumnTextBox.Text = defaultColumn.ToString();
            inputRankTextBox.Text = defaultRank.ToString();
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty(
"DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(mapPanel, true, null);
        }

        private void onMapPanelPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(mapPanelColor);
            solver.draw(e.Graphics);
        }
        private void onSolveButtonClick(object sender, EventArgs e)
        {
            solver.solve();
            mapPanel.Invalidate();
        }
        private void onInputRankTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void onInputColumnTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void onApplyButtonClick(object sender, EventArgs e)
        {
            int numberOfRank;
            Int32.TryParse(inputRankTextBox.Text,out numberOfRank);
            int numberOfColumn;
            Int32.TryParse(inputColumnTextBox.Text,out numberOfColumn);
            if (numberOfRank > maxRank || numberOfColumn > maxColumn||numberOfColumn<6||numberOfRank<6)
            {
                MessageBox.Show("Number of rank or column to big or too small.");
                return;
            }
            setMap(numberOfRank, numberOfColumn);
            mapPanel.Invalidate();
        }
        private void onMapPanelClick(object sender, MouseEventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Input value", "Title", "0", -1, -1);
            int value;
            Int32.TryParse(input, out value);
            if (value > 8 || value < -1) return;
            solver.mapClick(e.X, e.Y,value);
            mapPanel.Invalidate();
        }
        public void setMap(int rank,int column)
        {
            mapPanel.Width = squareSize * column;
            mapPanel.Height = squareSize * rank;
            this.Width = mapPanel.Width + 120;
            this.Height = mapPanel.Height + 50;
            solveButton.Location = new Point(mapPanel.Right + 10, mapPanel.Top);
            rankLable.Location = new Point(mapPanel.Right + 10, solveButton.Bottom + 20);
            inputRankTextBox.Location = new Point(mapPanel.Right + 10, rankLable.Bottom + 5);
            columnLable.Location = new Point(mapPanel.Right + 10, inputRankTextBox.Bottom + 10);
            inputColumnTextBox.Location = new Point(mapPanel.Right + 10, columnLable.Bottom + 5);
            applyButton.Location = new Point(mapPanel.Right + 10, inputColumnTextBox.Bottom + 5);
            solver = new Solver(mapPanel.Width, mapPanel.Height, rank, column);
        }
    }
}
