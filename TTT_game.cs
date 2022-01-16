class TTT
{
    public static char player_sign = ' ';
    static int Turns = 0;
    static char[] board = {'0','1','2','3','4','5','6','7','8'};

    public static void Board_reset()
    {
        char[] Board_init = {'0','1','2','3','4','5','6','7','8'};
        board = Board_init;
        Draw_board();
        Turns = 0;
    }

    public static void Draw_board()
    {
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" {0} | {1} | {2} ", board[0],board[1],board[2]);
        Console.WriteLine("   |   |   ");
        Console.WriteLine("===========");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" {0} | {1} | {2} ", board[3],board[4],board[5]);
        Console.WriteLine("   |   |   ");
        Console.WriteLine("===========");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" {0} | {1} | {2} ", board[6],board[7],board[8]);
        Console.WriteLine("   |   |   ");
    }

    public static void Intro()
    {
        Console.WriteLine("Welcome to Tic Tac Toe");
        Console.WriteLine("RULES");
        Console.WriteLine("Tic Tac Toe is a turn based 2 player game\n" +
                          "Each player must choose and play with a unique sign. Player 1 will be X and Player 2 will be O\n" +
                          "The first player to land 3 of their signs in a row is the winner");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    public static void XorO(int player, int input)
    {
        if (player == 1) player_sign = 'X';
        else if (player == 2) player_sign = 'O';

        switch (input)
        {
            case 1: board[0] = player_sign; break;
            case 2: board[1] = player_sign; break;
            case 3: board[2] = player_sign; break;
            case 4: board[3] = player_sign; break;
            case 5: board[4] = player_sign; break;
            case 6: board[5] = player_sign; break;
            case 7: board[6] = player_sign; break;
            case 8: board[7] = player_sign; break;
            case 9: board[8] = player_sign; break;
        }
    }

    public static void Horizontal_win()
    {
        char[] player_signs = {'X','O'};

        foreach (char player_sign in player_signs)
        {
            if ( ((board[0] == player_sign)&&(board[1] == player_sign)&&(board[2] == player_sign)) 
            ||   ((board[3] == player_sign)&&(board[4] == player_sign)&&(board[5] == player_sign))
            ||   ((board[6] == player_sign)&&(board[7] == player_sign)&&(board[8] == player_sign)) )
            {
                if (player_sign == 'X')
                {
                    Console.WriteLine("Congratulations Player 1, You're winner!\n");
                }
                else if (player_sign == 'X')
                {
                    Console.WriteLine("Congratulations Player 2, You're winner!\n");
                }

                Console.WriteLine("Press any key to reset the game");
                Console.ReadKey();
                Board_reset();
                break;
            }
        }
    }

    public static void Vertical_win ()
    {
        char[] player_signs = {'X','O'};

        foreach (char player_sign in player_signs)
        {
            if ( ((board[0] == player_sign)&&(board[3] == player_sign)&&(board[6] == player_sign)) 
            ||   ((board[1] == player_sign)&&(board[4] == player_sign)&&(board[7] == player_sign))
            ||   ((board[2] == player_sign)&&(board[5] == player_sign)&&(board[8] == player_sign)) )
            {
                if (player_sign == 'X')
                {
                    Console.WriteLine("Congratulations Player 1, You're winner!\n");
                }
                else if (player_sign == 'X')
                {
                    Console.WriteLine("Congratulations Player 2, You're winner!\n");
                }

                Console.WriteLine("Press any key to reset the game");
                Console.ReadKey();
                Board_reset();
                break;
            }
        }
    }

    public static void Diagonal_win()
    {
        char[] player_signs = {'X','O'};

        foreach (char player_sign in player_signs)
        {
            if ( ((board[0] == player_sign)&&(board[4] == player_sign)&&(board[8] == player_sign)) 
            ||   ((board[2] == player_sign)&&(board[4] == player_sign)&&(board[6] == player_sign)) )
            {
                if (player_sign == 'X')
                {
                    Console.WriteLine("Congratulations Player 1, You're winner!\n");
                }
                else if (player_sign == 'X')
                {
                    Console.WriteLine("Congratulations Player 2, You're winner!\n");
                }

                Console.WriteLine("Press any key to reset the game");
                Console.ReadKey();
                Board_reset();
                break;
            }
        }
    }

    public static void Draw()
    {
        Console.WriteLine("Draw. Nobody is winner!\n" +
                         "Press any key to reset the game");
        Console.ReadKey();
        Board_reset();
    }
    
    static void Main(string[] args)
    {
        int player = 2;
        int input = 0;
        bool Correct_input = true;

        Intro();

        do
        {
            if (player == 2)
            {
                player = 1;
                XorO(player, input);
            }
            else if (player == 1)
            {
                player = 2;
                XorO(player, input);
            }

            Draw_board();
            Turns ++;
            Horizontal_win();
            Vertical_win();
            Diagonal_win();

            if (Turns == 10)
            {
                Draw();
            }
            do
            {
                Console.WriteLine("Ready Player {0}. Choose a space", player);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter a number");
                }

                if ((input == 0)&&(board[0] == '0')) Correct_input = true;
                else if ((input == 1)&&(board[1] == '1')) Correct_input = true;
                else if ((input == 2)&&(board[2] == '2')) Correct_input = true;
                else if ((input == 3)&&(board[3] == '3')) Correct_input = true;
                else if ((input == 4)&&(board[4] == '4')) Correct_input = true;
                else if ((input == 5)&&(board[5] == '5')) Correct_input = true;
                else if ((input == 6)&&(board[6] == '6')) Correct_input = true;
                else if ((input == 7)&&(board[7] == '7')) Correct_input = true;
                else if ((input == 8)&&(board[8] == '8')) Correct_input = true;
                else
                {
                    Console.WriteLine("Invalid entry. Please try again");
                    Correct_input = false;
                }
            } while (!Correct_input);
        } while (true);
    }

}

