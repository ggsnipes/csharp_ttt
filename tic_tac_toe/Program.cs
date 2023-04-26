using System;
using System.Threading;

class Program
{
    // This is the playfield that will be rendered on the console screen
    static char[] playField = { '1', '2', '3', '4', '5', '6', '7', '8', '9'};
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
    }

}