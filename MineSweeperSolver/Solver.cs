using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace MineSweeperSolver
{
    class Solver
    {
        private Map map;
        public Solver(int Width,int Height,int NumberOfRank,int NumberOfColumn)
        {
            map=new Map(Width, Height,NumberOfRank,NumberOfColumn);
        }
        public void draw(Graphics graphics)
        {
            map.draw(graphics);
        }
        public void mapClick(int x,int y,int value)
        {
            int rank = y / Square.size;
            int column = x / Square.size;
            if (value == -1) map.squares[rank, column].isExplored = false;
            else
            map.squares[rank, column].isExplored = true;
            map.squares[rank, column].isSafe = false;
            map.squares[rank, column].value = value;
        }
        public void solve()
        {
            List<Square> safe = new List<Square>();
            foreach(Square s in map.squares)
            {
                s.sum = new List<List<Square>>();
                s.sumValue = new List<int>();
            }
            for(int i=0;i<map.numberOfRank;i++)
                for(int j=0;j<map.numberOfColumn;j++)
                {
                    Square s = map.squares[i, j];
                    if (!s.isExplored || s.value ==0 || s.isMine || s.isSafe) continue;
                    int value = s.value;
                    List<Square> arround = getAround(i, j);
                    foreach (Square a in arround)
                    {
                        List<Square> sum = new List<Square>();
                        foreach (Square t in arround)
                        {
                            sum.Add(t);
                        }
                        a.sum.Add(sum);
                        a.sumValue.Add(value-getNumberOfMineAround(i,j));
                    }
                }
            foreach(Square s in map.squares)
            {
                if (s.isExplored || s.isMine|| s.isSafe) continue;
                List<List<Square>> sumToAdd = new List<List<Square>>();
                List<int> sumValueToAdd = new List<int>();
                foreach(List<Square> l in s.sum)
                {
                    foreach(List<Square> l2 in s.sum)
                    {
                        if (l == l2||l.Count<l2.Count) continue;
                        if (!l2.All(k => l.Contains(k))) continue;
                        List<Square> l3 = l.Except(l2).ToList();
                        foreach(List<Square> l4 in s.sum)
                        {
                            if (l3.Except(l4).ToList().Count > 0)
                            {
                                sumToAdd.Add(l3);
                                sumValueToAdd.Add(s.sumValue[s.sum.IndexOf(l)] - s.sumValue[s.sum.IndexOf(l2)]);
                            }
                        }
                    }
                }
                foreach (List<Square> l in sumToAdd) s.sum.Add(l);
                foreach (int val in sumValueToAdd) s.sumValue.Add(val);
                for(int i=0;i<s.sum.Count;i++)
                {
                    if (s.sumValue[i] == 0) foreach (Square k in s.sum[i])
                        {
                            if(!safe.Contains(k)) safe.Add(k);
                            k.isSafe = true;
                        }
                    if (s.sumValue[i] == s.sum[i].Count) foreach (Square k in s.sum[i]) k.isMine=true;
                }
            }
            foreach (Square s in safe)
            {
                for (int i = 0; i < map.numberOfRank; i++)
                    for (int j = 0; j < map.numberOfColumn; j++)
                    {
                        if(map.squares[i,j]==s)
                        {
                            if(getAround(i,j).Count==0)
                            {
                                s.isExplored = true;
                                s.isSafe = false;
                                s.value = getNumberOfMineAround(i, j);
                            }
                        }
                    }
            }
        }

        private int getNumberOfMineAround(int x, int y)
        {
            List<Square> around = new List<Square>();
            if (x > 0)
            {
                around.Add(map.squares[x - 1, y]);
                if (y > 0)
                {
                    around.Add(map.squares[x - 1, y - 1]);
                }
                if (y < map.numberOfColumn - 1)
                {
                    around.Add(map.squares[x - 1, y + 1]);
                }
            }
            if (x < map.numberOfRank - 1)
            {
                around.Add(map.squares[x + 1, y]);
                if (y > 0)
                {
                    around.Add(map.squares[x + 1, y - 1]);
                }
                if (y < map.numberOfColumn - 1)
                {
                    around.Add(map.squares[x + 1, y + 1]);
                }
            }
            if (y > 0)
            {
                around.Add(map.squares[x, y - 1]);
            }
            if (y < map.numberOfColumn - 1)
            {
                around.Add(map.squares[x, y + 1]);
            }
            int count=0;
            for (int i = 0; i < around.Count; i++)
            {
                if (around[i].isMine) count++;
            }
            return count;
        }
        public List<Square> getAround(int x,int y)
        {
            List<Square> around = new List<Square>();
            if(x>0)
            {
                around.Add(map.squares[x - 1, y]);
                if (y > 0)
                {
                    around.Add(map.squares[x - 1, y-1]);
                }
                if (y < map.numberOfColumn - 1)
                {
                    around.Add(map.squares[x - 1, y + 1]);
                }
            }
            if(x<map.numberOfRank-1)
            {
                around.Add(map.squares[x + 1, y]);
                if (y > 0)
                {
                    around.Add(map.squares[x +1 , y - 1]);
                }
                if (y < map.numberOfColumn - 1)
                {
                    around.Add(map.squares[x + 1, y + 1]);
                }
            }
            if(y>0)
            {
                around.Add(map.squares[x, y - 1]);
            }
            if(y<map.numberOfColumn - 1)
            {
                around.Add(map.squares[x, y + 1]);
            }
            List<Square> explored=new List<Square>();
            for (int i = 0; i < around.Count;i++)
            {
                if (around[i].isExplored) explored.Add(around[i]);
                else
                if (around[i].isMine) explored.Add(around[i]);
                else
                if (around[i].isSafe) explored.Add(around[i]);
            }
            foreach (Square s in explored) around.Remove(s);
            return around;
        }
    }
}
