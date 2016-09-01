using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MineSweeperSolver
{
    class Map
    {
        int width;
        int height;
        public int numberOfRank;
        public int numberOfColumn;
        public Square[,] squares;
        public Map(int Width,int Height,int NumberOfRank,int NumberOfColumn)
        {
            width = Width;
            height = Height;
            numberOfRank = NumberOfRank;
            numberOfColumn = NumberOfColumn;
            squares = new Square[numberOfRank, numberOfColumn];
            initSquares();
        }
        public void initSquares()
        {
            for(int i=0;i<numberOfRank;i++)
                for(int j=0;j<numberOfColumn;j++)
                {
                    squares[i, j] = new Square(j * Square.size, i * Square.size);
                }
        }
        public void draw(Graphics graphics)
        {
            Pen pen=new Pen(Color.Black,1);
            foreach (Square s in squares) s.draw(graphics);
            for (int i = 0; i < numberOfRank; i++) graphics.DrawLine(pen, 0, i * Square.size, width-1, i * Square.size);
            for (int i = 0; i < numberOfColumn; i++) graphics.DrawLine(pen, i*Square.size, 0, i*Square.size, height-1);
        }
    }
}
