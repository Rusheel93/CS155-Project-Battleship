using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Board
    {

        public void displayBoard(char[,] Board)
        {
            int Rows = 4;
            int Colums = 4;

            Console.WriteLine("   |1|2|3|4");
            for (int Row = 1; Row <= Rows; Row++)
            {
                Console.Write((Row).ToString() + " ¦ ");
                for (int Colum = 1; Colum <= Colums; Colum++)
                {
                    Console.Write(Board[Colum - 1, Row - 1] + "" + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
