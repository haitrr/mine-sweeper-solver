using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MineSweeperSolver
{
    class Square
    {
        private int x;
        private int y;
        public static int size;
        public bool isExplored;
        public bool isMine;
        public bool isSafe;
        public int value;
        public int minValue;
        public int maxValue;
        public List<List<Square>> sum;
        public List<int> sumValue;
        private static Image mine=Properties.Resources.mine;
        private static Image square = Properties.Resources.square;
        private static Image safe = Properties.Resources.safe;
        public static Font font;
        private static SolidBrush brush=new SolidBrush(Color.Black);
        private static StringFormat stringFormat = new StringFormat { Alignment = StringAlignment.Center,LineAlignment=StringAlignment.Center};
        public Square(int X,int Y)
        {
            x = X;
            y = Y;
            value = -1;
            minValue = 0;
            maxValue = 8;
            sum = new List<List<Square>>();
            sumValue = new List<int>();
        }
        public void draw(Graphics graphics)
        {
            if (isMine) graphics.DrawImage(mine, x, y, size, size);
            else if (isSafe) graphics.DrawImage(safe, x, y, size, size);
            else if (isExplored)
            {
                if (value!=0) graphics.DrawString(value.ToString(), font, brush, x + size / 2, y + size / 2, stringFormat);
            }
            else graphics.DrawImage(square, x, y, size, size);
        }
    }
}
