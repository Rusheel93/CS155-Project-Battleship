using System;

namespace Battleship
{
  

class Program
    {
        static void Main(string[] args)
        {
            Board player = new Board();
            Board comp = new Board();

            Player p1 = new Player();
            Player comp1 = new Player();

            bool win = false;
            string input;
            char[,] winstate = new char[4,4 ];

            
            int x;
            int y;


            comp1.popGrid();

            
            winstate[0, 0] = '0';
            winstate[0, 1] = '0';
            winstate[0, 2] = '0';
            winstate[0, 3] = '0';
            winstate[1, 0] = '0';
            winstate[1, 1] = '1';
            winstate[1, 2] = '1';
            winstate[1, 3] = '0';
            winstate[2, 0] = '0';
            winstate[2, 1] = '0';
            winstate[2, 2] = '0';
            winstate[2, 3] = '0';
            winstate[3, 0] = '0';
            winstate[3, 1] = '0';
            winstate[3, 2] = '0';
            winstate[3, 3] = '0';

          

            /*** build NPC board ***/
           for(int i = 1; i <= 4; i++)
            {
                for(int j = 1; j <= 4; j++)
                {
                    if (!comp1.getValue(i-1,j-1).Equals(winstate[i-1,j-1]))
                    {
                        comp1.setGrid(i - 1, j - 1);
                    }
                    
                }
            }

            

            Console.WriteLine("NPC BOARD");
            comp.displayBoard(comp1.getGrid());            
            
            p1.popGrid();
            player.displayBoard(p1.getGrid());
            Console.WriteLine("Populate your board using 2 sets of coordinates you are alloted 2 ships");
            Console.WriteLine("Enter the X of your first ship: ");

            input = Console.ReadLine();
            x = Convert.ToInt32(input) -1;
            Console.WriteLine("Enter the Y of your first ship: ");
            input = Console.ReadLine();
            y = Convert.ToInt32(input) -1;

            p1.setGrid(x, y);
            

            

            Console.WriteLine("Enter the X of your second ship: ");
            input = Console.ReadLine();
            x = Convert.ToInt32(input) -1;
            Console.WriteLine("Enter the Y of your second ship: ");
            input = Console.ReadLine();
            y = Convert.ToInt32(input)-1;
           
            
            p1.setGrid(x, y);
            Console.WriteLine("Final Player Board do you accept?");
            player.displayBoard(p1.getGrid());

            Console.WriteLine("Proceed to game: ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("NPC BOARD");
            comp.displayBoard(comp1.getGrid());


            while (!win)
            {
                comp.displayBoard(comp1.getGrid());
                comp1.selection();
                Console.Clear();
                
                
            
                if(Convert.ToChar(comp1.getValue(1,1) -23).Equals(winstate[1,1]) && (Convert.ToChar(comp1.getValue(1, 2)-23).Equals(winstate[1, 2])))
                {
                    Console.WriteLine("Congrats");
                    win = true;
                }


            }
            Console.ReadLine();
        }
    }
}
