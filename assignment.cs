using System;

public class Program
{
	public static void Main()
	{
		bool exit = false;
		string input;
		while (exit == false)
		{
			do
			{
			Console.WriteLine("WELCOME TO THE EPIC GAME PORTAL.");
			Console.WriteLine("\u2605 \u2743 \u2743 \u2605 \u2721 \u2605 \u2743 \u2721 \u2605 \u2605 \u2743");
			Console.WriteLine("\n\n// PRESS 'N' TO PLAY NAUGHTS AND CROSSES \n// PRESS 'R' TO PLAY ROCK PAPER SCISSORS \n// PRESS 'E' TO EXIT");
				input = Console.ReadLine();
				if (input.ToUpper() == "R")
				{
					Console.WriteLine("-\n-\n\nwelcome to ROCK PAPER SCISSORS!");
					Console.WriteLine("press M to travel back to menu at any time\n\n");
					Console.WriteLine("RULES:\n\n-- CHOOSE AND GET LUCKY TO BEAT YOUR OPPONENT. ");
					RPS();
				}
				else if (input.ToUpper() == "N")
				{
					Console.WriteLine("-\n-\n\nwelcome to NAUGHTS AND CROSSES!");
					Console.WriteLine("press M to travel back to menu at any time\n\n");
					Console.WriteLine("RULES:\n\n-- FILL 3 PLACES IN A ROW WITH YOUR SYMBOL (DIAGONALLY, VERTICALLY OR HORIZONTALLY) \nTO WIN THE GAME. ");
					NAC();
				}
				else if (input.ToUpper() == "E")
				{
					Console.WriteLine("SEE YOU NEXT TIME... \n\nyou have exited.");
					exit = true;
				}
				else
				{
					Console.WriteLine("\nInvalid input. Please choose a game mode or E to exit.\n\n");
				}
			}
			while (input != "N" && input != "R" && input != "E");
		}
	}

	// naughts and crosses
	public static void NAC()
	{
		//rules
		bool p1 = true;
		bool win = false;
		bool gameOver = false; 
		int num1;
		int num2;
		string row;
		string place;
		bool canConvert = false;
		string playAgain;
		//playing grid
		string[, ] grid =
		{
			{"_","_","_"}, {"_","_","_"}, {"_","_","_"}
		};
		while (gameOver == false)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write(grid[i, j]);
				}

				Console.WriteLine();
			}

			// player turn 	
			if (win == false && p1 == true)
			{
				Console.WriteLine("\nPLAYER 1 TURN:\n");
			}
			else if (win == false && p1 == false)
			{
				Console.WriteLine("\nPLAYER 2 TURN:\n");
			}
			do{
			Console.WriteLine("Row: ");
			row = Console.ReadLine();
			canConvert = int.TryParse(row, out num1);
				if (row.ToUpper() == "M")
				{
					Console.WriteLine("\nTRAVELING BACK TO MENU \uaa5c\uaa5c... \n\n\n");
					gameOver = true;
					return;
				}
			Console.WriteLine("Place: ");
			place = Console.ReadLine();
				if (place.ToUpper() == "M")
				{
					Console.WriteLine("\nTRAVELING BACK TO MENU \uaa5c\uaa5c... \n\n\n");
					gameOver = true;
					return;
				}
			canConvert = int.TryParse(place, out num2);
				if (canConvert == false || num1 > 2 || num1 < 0|| num2 < 0|| num2 > 2 && row != "M" && place != "M")
				{
					Console.WriteLine("\n\nInvalid input. Please enter numbers from 0-2. (KEY: 0=first row, 2= last row)");
				}
				else if (grid[num1, num2] != "_")
           			{
               				Console.WriteLine("\n\nThis square has already been chose! Please choose another one that is empty.");
            			}

			} while (canConvert == false || num1 > 2 || num1 < 0|| num2 < 0|| num2 > 2 && row != "M" && place != "M" || (grid[num1, num2] != "_"));
			
				
			if (p1 == true)
			{
				grid[num1, num2] = "X";
				p1 = false;
			}
			else
			{
				grid[num1, num2] = "O";
				p1 = true;
			}

			// checking for win
			for (int i = 0; i < 3; i++)
			{
				//horizotal
				if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i] && grid[0, i] != "_")
				{
					win = true;
				}

				// vertical
				if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2] && grid[i, 0] != "_")
				{
					win = true;
				}
			}

			//diagonal
			if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] && grid[0, 0] != "_")
			{
				win = true;
			}

			if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0] && grid[0, 2] != "_")
			{
				win = true;
			}

			if (win)
			{
				if (!p1)
				{
					Console.WriteLine("PLAYER 1 WINS!! \u263A");
					gameOver = true;
				}
				else
				{
					Console.WriteLine("PLAYER 2 WINS!! \u263A");
					gameOver = true;
				}
			}

			// tie
			if (!win && grid[0, 0] != "_" && grid[0, 1] != "_" && grid[0, 2] != "_" && grid[1, 0] != "_" && grid[1, 1] != "_" && grid[1, 2] != "_" && grid[2, 0] != "_" && grid[2, 1] != "_" && grid[2, 2] != "_")
			{
				Console.WriteLine("GAME TIED");
				gameOver = true;
			}

			// add input checking here for YES and NO input only, else is not accepted!!!
			if (gameOver == true)
			{
				do{
				Console.WriteLine("\n\nPLAY AGAIN?");
				playAgain = Console.ReadLine();
				if (playAgain.ToUpper() == "YES")
				{
					Console.WriteLine("STARTING NEW GAME");
					NAC();
					gameOver = false;
				}
				else if (playAgain.ToUpper() == "NO")
				{
					Console.WriteLine("TRAVELING BACK TO MENU\uaa5c\uaa5c...\n\n\n");
					break;
				}
				else
				{
					Console.WriteLine("\nInvalid input - please choose either YES or NO:");
				}
		} while (playAgain != "yes" && playAgain != "no");
			}
		}
	}

	// rock paper scissors
	public static void RPS()
	{
		Random choice = new Random();
		Random versus = new Random();
		int comp = 0;
		int player = 0;
		int place = 0;
		int opponent = 0;
		bool gameOver = false;
		string playAgain;
		string[] move =
		{
			"rock","scissors","paper"
		};
		string[] names =
		{
			"Johnny","Nina","Anton","Rebecca","Benjamin","Mohammed","Nicky",
		};
		string[] countries =
		{
			"the USA","Germany","China","Brazil","Switzerland","Pakistan","Puerto Rico",
		};
		// online person
		Console.WriteLine("\nFINDING OPPONENT...");
		Console.WriteLine("CONNECTING TO SERVER...\n");
		opponent = versus.Next(0, 6);
		place = versus.Next(0, 6);
		Console.WriteLine("You will be playing against " + names[opponent] + " from " + countries[place] + "!");
		// not supposed to reroell its dotnetfiddle thing
		while (gameOver == false)
		{
			comp = choice.Next(0, 3);
			//player
			Console.WriteLine("ROCK, PAPER OR SCISSORS?");
			string playerMove = Console.ReadLine();
			// input checking
			if (playerMove.ToUpper() == "M" || playerMove.ToUpper() == "M")
				{
					Console.WriteLine("\nTRAVELING BACK TO MENU \uaa5c\uaa5c... \n\n\n");
					gameOver = true;
					break;
				}
			if (playerMove == move[0])
			{
				player = 0;
			}

			if (playerMove == move[1])
			{
				player = 1;
			}

			if (playerMove == move[2])
			{
				player = 2;
			}

			Console.WriteLine("\n" + names[opponent] + " chose " + move[comp] + ", you chose " + move[player] + "\n");
			if (comp == player)
			{
				Console.WriteLine("You tied...");
				gameOver = true;
			}
			else if ((comp - player) == 1 || (comp - player) == -2)
			{
				Console.WriteLine("You Win!\u263A");
				gameOver = true;
			}
			else
			{
				Console.WriteLine(names[opponent] + " wins ㅠㅠ");
				gameOver = true;
			}

			if (gameOver == true)
			{
				do{
				Console.WriteLine("\n\nPLAY AGAIN?");
				playAgain = Console.ReadLine();
				if (playAgain.ToUpper() == "YES")
				{
					Console.WriteLine("JOINING NEW OPPONENT..");
					gameOver = false;
					RPS();
				}
				else if (playAgain.ToUpper() == "NO")
				{
					Console.WriteLine("\nTRAVELING BACK TO MENU \uaa5c\uaa5c... \n\n\n");
					gameOver = true;
					break;
				}
				else
				{
					Console.WriteLine("\nInvalid input - please choose either YES or NO:");
				}
			
		} while (playAgain != "yes" && playAgain != "no");
			}
		}
	}
}
