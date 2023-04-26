using System;
using System.Threading;

class Program
{
    // This is the playfield that will be rendered on the console screen, will not use 0
    // this is so that the user uses the inputs 1 - 9 instead of 0 - 8 
    static char[] playField = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    // Using player as a counter, this is so that every even turn will be player 2's turn while player 1 will be odd numbers.
    static int player = 1;
    // This holds the markers, but will be set later
    static int choice;
    // Flag will be checking for who wins or if the game is a draw, as is, 0 will be game is ongoning, 1 is winner found, -1 is draw
    static int flag = 0;

    static void Main(string[] args)
    {
        do
        {
            // clears the screen whenever the loop starts
            Console.Clear();
            Console.WriteLine("Player 1 is X and Player 2 is O");
            Console.WriteLine("\n");

            if (player % 2 == 0)
            {
                Console.WriteLine("Player 2's turn");
            }
            else 
            {
                Console.WriteLine("Player 1's turn");
            }

            Console.WriteLine("\n");

            // calling the board function
            Board();

            // taking the player's input
            choice = int.Parse(Console.ReadLine());

            // check if the position the player is selecting already has a marker on it or not
            if(playField[choice] != 'X' && playField[choice] != 'O')
            {
                if(player % 2 == 0)
                {
                    playField[choice] = 'O';
                    player++;
                }
                else
                {
                    playField[choice] = 'X';
                    player++;
                }

            }
            else
            {
                Console.WriteLine("Sorry spot {0} is already taken by marker {1}", choice, playField[choice]);
                Console.WriteLine("\n");
                Console.WriteLine("Please wait, playfield will load in a few seconds");
                Thread.Sleep(2000);
            }

            // checks the win conditions
            flag = CheckWin();

        }
        while(flag != 1 && flag != -1);

        // while loop will keep going until all of the cells are marked

        // clear the console and get the playfield again
        Console.Clear();
        Board();

        // this is to check for win conditions
        if(flag == 1)
        {
            Console.WriteLine("Player {0} wins!", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("It's a draw!");
        }
        Console.ReadLine();

    }

    // Board to hold the playfield
    private static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", playField[1], playField[2], playField[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", playField[4], playField[5], playField[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", playField[7], playField[8], playField[9]);
        Console.WriteLine("     |     |      ");
    }

    // win checker
    private static int CheckWin()
    {
        #region Horizontal win conditions
        if(playField[1] == playField[2] && playField[2] == playField[3] || playField[4] == playField[5] && playField[5] == playField[6] || playField[7] == playField[8] && playField[8] == playField[9])
        {
            return 1;
        }
        #endregion
        #region Vertical win conditions
        else if(playField[1] == playField[4] && playField[4] == playField[7] || playField[2] == playField[5] && playField[5] == playField[8] || playField[3] == playField[6] && playField[6] == playField[9])
        {
            return 1;
        }
        #endregion
        #region Diagonal win conditions
        else if(playField[1] == playField[5] && playField[5] == playField[9] || playField[3] == playField[5] && playField[5] == playField[7])
        {
            return 1;
        }
        #endregion
        #region Draw conditions
        else if(playField[1] != '1' && playField[2] != '2' && playField[3] != '3' && playField[4] != '4' && playField[5] != '5' && playField[6] != '6' && playField[7] != '7' && playField[8] != '8' && playField[9] != '9')
        {
            return -1;
        }
        #endregion
        else
        {
            return 0;
        }
    }

}