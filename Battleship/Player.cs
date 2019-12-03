using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{

    class Player
    {
        char[,] Grid = new char[4, 4];
        int x = 1;
        int y = 1;
        string input;
        int count = 0;
       

       

        public void selection()
        {
            bool win = true ;
            Console.WriteLine("Enter X coordinate: ");
            input = Console.ReadLine();
            x = Convert.ToInt32(input) -1;

            Console.WriteLine("Enter Y coordinate: ");
            input = Console.ReadLine();
            y = Convert.ToInt32(input) -1;

            if(Grid[x,y].Equals('1'))
            {
                Grid[x, y] = 'H';
                Console.WriteLine("you Hit");
                count++;
                if(count == 2)
                {
                    Console.WriteLine("Game won!");
                    
                }

            }
            else
            {
                Grid[x, y] = 'X';
                Console.WriteLine("you missed");
            }
        }
        public char[,] getGrid()
        {
            return Grid;
        }
        public void setGrid(int i, int j)
        {
            Grid[i, j] = '1';
        }
        public char getValue(int i, int j)
        {
            char value = Grid[i, j];
            return value;
        }
        public void popGrid()
        {

            Grid[0, 0] = '0';
            Grid[0, 1] = '0';
            Grid[0, 2] = '0';
            Grid[0, 3] = '0';
            Grid[1, 0] = '0';
            Grid[1, 1] = '0';
            Grid[1, 2] = '0';
            Grid[1, 3] = '0';
            Grid[2, 0] = '0';
            Grid[2, 1] = '0';
            Grid[2, 2] = '0';
            Grid[2, 3] = '0';
            Grid[3, 0] = '0';
            Grid[3, 1] = '0';
            Grid[3, 2] = '0';
            Grid[3, 3] = '0';
        }


    }
}
