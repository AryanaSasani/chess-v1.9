using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_2
{
	//==========================================================================================================
	//==========================================================================================================

	public class ChessBoard
	{
		private string[,] chessBoard;
		public const int DIMENTION = 8;

		private Move move;


		public string ChessBoardHorizentalSymboal { get; set; }
		public string ChessBoardVerticalSymboal { get; set; }

		bool KISH = false;
		bool MATE = false;


		

		public void DisplayChessBoard()
		{
			while (!move.Exit)
			{
				
				
				

				Console.Clear();
				Console.WriteLine("    0    1    2    3    4    5    6    7     :Y ");// x axis header
				for (int r = 0; r < DIMENTION; r++)
				{
					Console.Write("  ");
					for (int c = 0; c < DIMENTION; c++)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write(ChessBoardHorizentalSymboal);  // horizental patern
					}
					Console.WriteLine("+");
					Console.ResetColor();
					Console.Write(r + " "); //y axis header

					for (int c = 0; c < DIMENTION; c++)
					{
						//Console.Write(r+"  "); //y axis header
						Console.ForegroundColor = ConsoleColor.Yellow;

						Console.Write(ChessBoardVerticalSymboal);
						Console.ResetColor();

						Console.Write(Character.characters[r, c] + " ");


					}
					Console.ForegroundColor = ConsoleColor.Yellow;

					Console.WriteLine("|");
				}

					// last line seperator

				Console.Write("  ");
				for (int c = 0; c < DIMENTION; c++)
				{
					Console.Write(ChessBoardHorizentalSymboal);  // horizental patern
				}
				Console.WriteLine("+");

				Console.ResetColor();
				Console.WriteLine("X \n");
				
					move.MakeMove();
				

			}
		}


	

		
		public ChessBoard()
		{

			move = new Move();
			chessBoard = new string[DIMENTION, DIMENTION];
			ChessBoardHorizentalSymboal = "+====";
			ChessBoardVerticalSymboal = "| ";

		}

		public void boardDisplayer()
		{
			Console.WriteLine("    0    1    2    3    4    5    6    7     :Y ");// x axis header
			for (int r = 0; r <DIMENTION; r++)
			{
				Console.Write("  ");
				for (int c = 0; c < DIMENTION; c++)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(ChessBoardHorizentalSymboal);  // horizental patern
				}
				Console.WriteLine("+");
				Console.ResetColor();
				Console.Write(r + " "); //y axis header

				for (int c = 0; c < DIMENTION; c++)
				{
					//Console.Write(r+"  "); //y axis header
					Console.ForegroundColor = ConsoleColor.Yellow;

					Console.Write(ChessBoardVerticalSymboal);
					Console.ResetColor();

					Console.Write(Character.characters[r, c] + " ");


				}
				Console.ForegroundColor = ConsoleColor.Yellow;

				Console.WriteLine("|");
			}

			// last line seperator

			Console.Write("  ");
			for (int c = 0; c < DIMENTION; c++)
			{
				Console.Write(ChessBoardHorizentalSymboal);  // horizental patern
			}
			Console.WriteLine("+");

			Console.ResetColor();
			Console.WriteLine("X \n");
		}




	}
	//==========================================================================================================
	//####################################################################################################

	public abstract class Character
	{
		public string SYMBOL = "  ";
		public string SPACE = "  ";
		public static string[,] characters;

		protected virtual void initCharacters()
		{
			for (int r = 0; r < ChessBoard.DIMENTION; r++)
			{
				for (int c = 0; c < ChessBoard.DIMENTION; c++)
				{
					if (r == 0 || r == 1) // x0 x1  pkayer 2
					{
						if (r == 1)
						{
							characters[r, c] = "P2";

						}
						else
						{
							if (c == 0 || c == ChessBoard.DIMENTION - 1)
								characters[r, c] = "R2";
							else if (c == 1 || c == ChessBoard.DIMENTION - 2)
								characters[r, c] = "N2";
							else if (c == 2 || c == ChessBoard.DIMENTION - 3)
								characters[r, c] = "B2";
							else if (c == 3)
								characters[r, c] = "Q2";
							else
							{
								characters[r, c] = "K2";
								/*K2_X = r;
								K2_Y = c;*/
							}
						}


					}
					else if(r == ChessBoard.DIMENTION - 1 || r == ChessBoard.DIMENTION - 2)
					{
						if (r == ChessBoard.DIMENTION-2)
						{
							characters[r, c] = "P1";

						}
						else
						{
							if (c == 0 || c == ChessBoard.DIMENTION - 1)
								characters[r, c] = "R1";
							else if (c == 1 || c == ChessBoard.DIMENTION - 2)
								characters[r, c] = "N1";
							else if (c == 2 || c == ChessBoard.DIMENTION - 3)
								characters[r, c] = "B1";
							else if (c == 3)
								characters[r, c] = "Q1";
							else
							{
								characters[r, c] = "K1";
								/*K1_X = r;
								K1_Y = c;*/
							}
						}
					}
					else
					{
						characters[r, c] = SPACE;
					}
				}
			}
		}
		public Character()
		{


			characters = new string[ChessBoard.DIMENTION, ChessBoard.DIMENTION];
			initCharacters();
		}
	}

	//###########################################################################################################
	//==========================================================================================================
	//==========================================================================================================

	public abstract class Mohre
	{
		protected int targetX;
		protected int targetY;
		protected int destinationX;
		protected int destinationY;
		protected bool error = false;

		

		public Mohre()
		{


		}


		public virtual bool validateMove_P1(int tarX, int tarY, int destX, int destY)
		{

			return error;

		}
		public virtual bool validateMove_P2(int tarX, int tarY, int destX, int destY)
		{

			return error;

		}

		public virtual int Possible_Moves()
		{
			int posibilitys;
			return 0;

		}



	}

	public class Pawn : Mohre
	{





		public override bool validateMove_P1(int tarX, int tarY, int destX, int destY) //paeen
		{
			Console.ForegroundColor = ConsoleColor.Red;
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			int deltaX = targetX - destinationX;
			error = true;


			/// harekat 1 khoone
			if (targetX==6)
			{
				if (targetY == destinationY && (deltaX==1||deltaX==2))// move
				{
					if(deltaX==1)
					{ 
						if(Character.characters[destinationX,destinationY]=="  ")
						{
							error = false;
						}
						else
						{
							Console.WriteLine("you cant move there !\n something is infront of P1");
							error = true;
						}
					}
					else
					{
						if (deltaX == 2)
						{
							if ((Character.characters[destinationX+1, destinationY] == "  ")&& (Character.characters[destinationX, destinationY] == "  "))
							{
								error = false;
							}
							else
							{
								Console.WriteLine("you cant move there !\n something is infront of P1");
								error = true;
							}
						}
						else
						{
							Console.WriteLine(" Pawn cant move like this !");
							error = true;
						}

					}

				}
				else if( (Math.Abs(targetY-destinationY)==1) && deltaX==1 ) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1]=='2')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{
						Console.WriteLine("you cant move there !\n there is no enemy my besty :| ");
						error = true;
					}
					else
					{
						Console.WriteLine("(P1) you cant kill your friends!! ");
						error = true;
					}
				}
				else
				{
					Console.WriteLine(" Pawn cant move like this !");
					error = true;
				}
			}///////*******************************************************************************************
			else // radif joz radif 6
			{
				if (targetY == destinationY && deltaX == 1)// move
				{

					if (Character.characters[destinationX, destinationY] == "  ")
					{
						error = false;
					}
					else
					{
						Console.WriteLine("you cant move there !\n something is infront of P1");
						error = true;
					}
					
				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1]=='2')
					{
						error = false;
					}
					else if(Character.characters[destinationX, destinationY] == "  ")
					{
						Console.WriteLine("you cant move there !\n there is no enemy my besty :| ");
						error = true;
					}
					else
					{
						Console.WriteLine("(P1) you cant kill your friends!! ");
						error = true;
					}
				}
				else
				{
					Console.WriteLine("Pawn cant move like this !!" );
					error = true;
				}
			}

			Console.ResetColor();
			return error;

		}


		//  // ************************************************

		public bool validate_P1(int tarX, int tarY, int destX, int destY) //paeen
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			int deltaX = targetX - destinationX;
			error = true;


			/// harekat 1 khoone
			if (targetX == 6)
			{
				if (targetY == destinationY && (deltaX == 1 || deltaX == 2))// move
				{
					if (deltaX == 1)
					{
						if (Character.characters[destinationX, destinationY] == "  ")
						{
							error = false;
						}
						else
						{
							error = true;
						}
					}
					else
					{
						if (deltaX == 2)
						{
							if ((Character.characters[destinationX + 1, destinationY] == "  ") && (Character.characters[destinationX, destinationY] == "  "))
							{
								error = false;
							}
							else
							{
								error = true;
							}
						}
						else
						{
						
							error = true;
						}

					}

				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1] == '2')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{
						
						error = true;
					}
					else
					{
						error = true;
					}
				}
				else
				{
					error = true;
				}
			}///////*******************************************************************************************
			else // radif joz radif 6
			{
				if (targetY == destinationY && deltaX == 1)// move
				{

					if (Character.characters[destinationX, destinationY] == "  ")
					{
						error = false;
					}
					else
					{
						error = true;
					}

				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1] == '2')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{
						error = true;
					}
					else
					{
						error = true;
					}
				}
				else
				{
					error = true;
				}
			}

			Console.ResetColor();
			return error;

		}
		//*****************


		public override bool validateMove_P2(int tarX, int tarY, int destX, int destY)
		{
			Console.ForegroundColor = ConsoleColor.Red;

			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;


			int deltaX = destinationX-targetX;


			/// harekat 1 khoone
			if (targetX == 1) //X
			{
				if (targetY == destinationY && (deltaX == 1 || deltaX == 2))// move
				{
					if (deltaX == 1)
					{
						if (Character.characters[destinationX, destinationY] == "  ")
						{
							error = false;
						}
						else
						{
							Console.WriteLine("you cant move there !\n something is infront of P2");
							error = true;
						}
					}
					else
					{
						if (deltaX == 2)
						{
							if ((Character.characters[destinationX - 1, destinationY] == "  ") && (Character.characters[destinationX, destinationY] == "  "))
							{
								error = false;
							}
							else
							{
								Console.WriteLine("you cant move there !\n something is infront of P2");
								error = true;
							}
						}
						else
						{
							Console.WriteLine(" Pawn cant move like this !");
							error = true;
						}
					}

				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1] == '1')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{
						Console.WriteLine("you cant move there !\n there is no enemy my besty :| ");
						error = true;
					}
					else
					{
						Console.WriteLine("(P2) you cant kill your friends!! ");
						error = true;
					}
				}
				else
				{
					Console.WriteLine(" Pawn cant move like this !");
					error = true;
				}
			}///////*******************************************************************************************
			else // radif joz radif 1
			{
				if (targetY == destinationY && deltaX == 1)// move
				{

					if (Character.characters[destinationX, destinationY] == "  ")
					{
						error = false;
					}
					else
					{
						Console.WriteLine("you cant move there !\n something is infront of P2");
						error = true;
					}

				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1] == '1')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{
						Console.WriteLine("you cant move there !\n there is no enemy my besty :| ");
						error = true;
					}
					else
					{
						Console.WriteLine("(P2) you cant kill your friends!! ");
						error = true;
					}
				}
				else
				{
					Console.WriteLine(" Pawn cant move like this !");
					error = true;
				}
			}

			Console.ResetColor();

			return error;



		}
		///%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		public bool validate_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;


			int deltaX = destinationX - targetX;


			/// harekat 1 khoone
			if (targetX == 1) //X
			{
				if (targetY == destinationY && (deltaX == 1 || deltaX == 2))// move
				{
					if (deltaX == 1)
					{
						if (Character.characters[destinationX, destinationY] == "  ")
						{
							error = false;
						}
						else
						{
							error = true;
						}
					}
					else
					{
						if (deltaX == 2)
						{
							if ((Character.characters[destinationX - 1, destinationY] == "  ") && (Character.characters[destinationX, destinationY] == "  "))
							{
								error = false;
							}
							else
							{
								error = true;
							}
						}
						else
						{
							error = true;
						}
					}

				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1] == '1')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{
						error = true;
					}
					else
					{
						error = true;
					}
				}
				else
				{
					error = true;
				}
			}///////*******************************************************************************************
			else // radif joz radif 1
			{
				if (targetY == destinationY && deltaX == 1)// move
				{

					if (Character.characters[destinationX, destinationY] == "  ")
					{
						error = false;
					}
					else
					{
						error = true;
					}

				}
				else if ((Math.Abs(targetY - destinationY) == 1) && deltaX == 1) //attack
				{
					if (Character.characters[destinationX, destinationY] != "  " && Character.characters[destinationX, destinationY][1] == '1')
					{
						error = false;
					}
					else if (Character.characters[destinationX, destinationY] == "  ")
					{ 
						error = true;
					}
					else
					{
						error = true;
					}
				}
				else
				{
					error = true;
				}
			}
			return error;

		}


	}



	public class Rook : Mohre
	{



		public  override bool validateMove_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			Console.ForegroundColor = ConsoleColor.Red;


			/// harekat 1 khoone
			error = false;
			bool Mane = false;
			// whether dest is allied ? (motahhed)
			if (Character.characters[destinationX, destinationY][1] == '1')
			{
				Console.WriteLine("R1 cant move there");
				Mane = true;
			}
			else if (targetX == destinationX || targetY == destinationY)  // valid move
			{
				if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement for  Rook! ");

			}
			

			if (Mane == true)
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("cant move there!  something is in your way sir !!");


			}

			Console.ResetColor();
			return error;



		}

		public bool validate_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			/// harekat 1 khoone
			error = false;
			bool Mane = false;
			// whether dest is allied ? (motahhed)
			if (Character.characters[destinationX, destinationY][1] == '1')
			{
				Mane = true;
			}
			else if (targetX == destinationX || targetY == destinationY)  // valid move
			{
				if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{ 
				error = true;
			}


			if (Mane == true)
			{
				error = true;
			}

			return error;



		}

		public override bool validateMove_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			Console.ForegroundColor = ConsoleColor.Red;


			/// harekat 1 khoone
			error = false;
			bool Mane = false;
			// whether dest is allied ? (motahhed)
			if (Character.characters[destinationX, destinationY][1] == '2')
			{
				Console.WriteLine("R2 cant move there");
				Mane = true;
			}
			else if (targetX == destinationX || targetY == destinationY)  // valid move
			{
				if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement for  Rook! ");

			}
			

			if (Mane == true)
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("cant move there!  something is in your way sir !!");


			}

			Console.ResetColor();
			return error;



		}

		public bool validate_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			/// harekat 1 khoone
			error = false;
			bool Mane = false;
			// whether dest is allied ? (motahhed)
			if (Character.characters[destinationX, destinationY][1] == '2')
			{
				Mane = true;
			}
			else if (targetX == destinationX || targetY == destinationY)  // valid move
			{
				if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				error = true;
			}


			if (Mane == true)
			{
				error = true;
			}

			return error;



		}

	}



	public class Knight : Mohre
	{



		public override bool validateMove_P1(int tarX, int tarY, int destX, int destY) /// fucked up
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;



			
			/// 
			if(Character.characters[destinationX,destinationY][1]!='1') // space or enemy
			{

				if ((targetX + 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetX - 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetY + 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else if ((targetY - 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					error = true;
					Console.WriteLine("Wrong movement  for Knight ! ");

				}
			}
			else if(Character.characters[destinationX, destinationY][1] == '1') // allie
			{

				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("(N1) you can't kill your allie !");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement  for Knight 1 ! ");

			}

			Console.ResetColor();


			return error;



		}


		public  bool validate_P1(int tarX, int tarY, int destX, int destY) /// fucked up
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;




			/// 
			if (Character.characters[destinationX, destinationY][1] != '1') // space or enemy
			{

				if ((targetX + 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetX - 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetY + 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else if ((targetY - 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else
				{
					error = true;
				}
			}
			else if (Character.characters[destinationX, destinationY][1] == '1') // allie
			{
				error = true;
			}
			else
			{
				error = true;

			}

			return error;

		}

		public override bool validateMove_P2(int tarX, int tarY, int destX, int destY) /// fucked up
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;




			/// 
			if (Character.characters[destinationX, destinationY][1] != '2') // space or enemy
			{

				if ((targetX + 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetX - 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetY + 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else if ((targetY - 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					error = true;
					Console.WriteLine("Wrong movement  for Knight ! ");

				}
			}
			else if (Character.characters[destinationX, destinationY][1] == '2') // allie
			{

				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("(N2) you can't kill your allie !");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement  for Knight 2 ! ");

			}

			Console.ResetColor();


			return error;



		}


		public bool validate_P2(int tarX, int tarY, int destX, int destY) /// fucked up
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;




			/// 
			if (Character.characters[destinationX, destinationY][1] != '2') // space or enemy
			{

				if ((targetX + 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetX - 2 == destinationX) && ((targetY + 1 == destinationY) || (targetY - 1 == destinationY)))
				{
					error = false;
				}
				else if ((targetY + 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else if ((targetY - 2 == destinationY) && ((targetX + 1 == destinationX) || (targetX - 1 == destinationX)))
				{
					error = false;
				}
				else
				{
				
					error = true;
					

				}
			}
			else if (Character.characters[destinationX, destinationY][1] == '2') // allie
			{
				error = true;			
			}
			else
			{
				error = true;
			}

			Console.ResetColor();


			return error;



		}




	}

	public class Bishop : Mohre
	{



		public override bool validateMove_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;
			error = false;

			/// harekat 1 khoone
			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if(Character.characters[destinationX,destinationY][1]=='1')
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("(B1) , you can't kill your allie");
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					error = true;
					Console.WriteLine(" You cant move this !! there is somthin in your way! ");

				}

			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement  for Bishop ! ");

			}


			return error;



		}


		public bool validate_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;
			error = false;

			/// harekat 1 khoone
			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if (Character.characters[destinationX, destinationY][1] == '1')
				{
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					error = true;

				}

			}
			else
			{
				error = true;
			}


			return error;



		}




		public override bool validateMove_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;
			error = false;

			/// harekat 1 khoone
			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if (Character.characters[destinationX, destinationY][1] == '2')
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("(B2) , you can't kill your allie");
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					error = true;
					Console.WriteLine(" You cant move this !! there is somthin in your way! ");

				}

			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement  for Bishop ! ");

			}

			return error;
		}

		public bool validate_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;
			error = false;

			/// harekat 1 khoone
			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if (Character.characters[destinationX, destinationY][1] == '2')
				{
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					error = true;
				}

			}
			else
			{
				error = true;
			}
			return error;
		}

	}


	public class Queen : Mohre
	{
		public override bool validateMove_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;

			error = false;
			/// /////////////  bishop
			/*if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				error = false;
			}*/


			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if(Character.characters[destinationX,destinationY][1]=='1')
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("(Q1) , you cant kill your allie !");
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					error = true;
					Console.WriteLine(" You cant move this !! there is somthin in your way! ");

				}

			}
			else if (targetX == destinationX || targetY == destinationY)///////////////////////////////////////////////  rook
			{
				if (Character.characters[destinationX, destinationY][1] == '1')
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("(Q1) , you cant kill your allie !");
					error = true;
				}
				else if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement for  queen! ");

			}

			if (Mane == true)
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("cant move there!  something is in your way sir !!");


			}


			return error;

		}

		public  bool validate_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;

			error = false;
			/// /////////////  bishop
			/*if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				error = false;
			}*/


			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if (Character.characters[destinationX, destinationY][1] == '1')
				{
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					error = true;
				}

			}
			else if (targetX == destinationX || targetY == destinationY)///////////////////////////////////////////////  rook
			{
				if (Character.characters[destinationX, destinationY][1] == '1')
				{ 
					error = true;
				}
				else if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				error = true;
			}

			if (Mane == true)
			{
				error = true;
			}


			return error;

		}

		public override bool validateMove_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;

			error = false;
			/// /////////////  bishop
			/*if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				error = false;
			}*/


			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if (Character.characters[destinationX, destinationY][1] == '2')
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("(Q2) , you cant kill your allie !");
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					error = true;
					Console.WriteLine(" You cant move this !! there is somthin in your way! ");

				}

			}
			else if (targetX == destinationX || targetY == destinationY)///////////////////////////////////////////////  rook
			{
				if (Character.characters[destinationX, destinationY][1] == '2')
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("(Q1) , you cant kill your allie !");
					error = true;
				}
				else if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement for  Queen! ");

			}

			if (Mane == true)
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("cant move there!  something is in your way sir !!");


			}


			return error;

		}


		public bool validate_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;

			bool Mane = false;

			error = false;
			/// /////////////  bishop
			/*if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				error = false;
			}*/


			if (Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY))
			{
				if (Character.characters[destinationX, destinationY][1] == '2')
				{
					error = true;
				}
				else if (targetX < destinationX)  // rast 
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}

				}
				else  // chap
				{
					if (targetY < destinationY)       // bala rast mane ?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY + i] != "  ")
							{
								Mane = true;
							}
						}
					}
					else   // paeen rast mane?
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY - i] != "  ")
							{
								Mane = true;
							}
						}
					}
				}

				if (Mane == true)
				{
					error = true;
				}

			}
			else if (targetX == destinationX || targetY == destinationY)///////////////////////////////////////////////  rook
			{
				if (Character.characters[destinationX, destinationY][1] == '2')
				{
					error = true;
				}
				else if (targetX == destinationX)   // ofoghi
				{
					if (targetY < destinationY)// rast
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY + i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //chap
					{
						for (int i = 1; i < Math.Abs(targetY - destinationY); i++)
						{
							if (Character.characters[targetX, targetY - i] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
				else // amoodi
				{
					if (targetX < destinationX)// paeen
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX + i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
					else  //bala
					{
						for (int i = 1; i < Math.Abs(targetX - destinationX); i++)
						{
							if (Character.characters[targetX - i, targetY] != "  ")
							{
								Mane = true;
								break;
							}
						}
					}
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;

			}

			if (Mane == true)
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
			}


			return error;

		}

	}
	/// <summary>
	/// /////////////////////////////////            $ King $ 
	/// </summary>
	public class King : Mohre
	{



		public override bool validateMove_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;



			/// harekat 1 khoone
			if(Character.characters[destinationX,destinationY][1]=='1')
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("(K1) my King !!! you cant kill your allie !");
				error = true;
			}
			else if ((Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY)) && (Math.Abs(targetX - destinationX) == 1))
			{
				error = false;
			}
			else if (((targetX == destinationX) && (Math.Abs(targetY - destinationY) == 1)) || ((targetY == destinationY) && (Math.Abs(targetX - destinationX) == 1)))
			{
				error = false;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement  for King ! ");

			}


			return error;

		}

		public  bool validate_P1(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;



			/// harekat 1 khoone
			if (Character.characters[destinationX, destinationY][1] == '1')
			{
				error = true;
			}
			else if ((Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY)) && (Math.Abs(targetX - destinationX) == 1))
			{
				error = false;
			}
			else if (((targetX == destinationX) && (Math.Abs(targetY - destinationY) == 1)) || ((targetY == destinationY) && (Math.Abs(targetX - destinationX) == 1)))
			{
				error = false;
			}
			else
			{
				error = true;
			}


			return error;

		}

		public override bool validateMove_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;



			/// harekat 1 khoone
			if (Character.characters[destinationX, destinationY][1] == '2')
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("(K2) my King !!! you cant kill your allie !");
				error = true;
			}
			else if ((Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY)) && (Math.Abs(targetX - destinationX) == 1))
			{
				error = false;
			}
			else if (((targetX == destinationX) && (Math.Abs(targetY - destinationY) == 1)) || ((targetY == destinationY) && (Math.Abs(targetX - destinationX) == 1)))
			{
				error = false;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				error = true;
				Console.WriteLine("Wrong movement  for King ! ");

			}


			return error;

		}
		public  bool validate_P2(int tarX, int tarY, int destX, int destY)
		{
			targetX = tarX;
			targetY = tarY;
			destinationX = destX;
			destinationY = destY;



			/// harekat 1 khoone
			if (Character.characters[destinationX, destinationY][1] == '2')
			{
				error = true;
			}
			else if ((Math.Abs(targetX - destinationX) == Math.Abs(targetY - destinationY)) && (Math.Abs(targetX - destinationX) == 1))
			{
				error = false;
			}
			else if (((targetX == destinationX) && (Math.Abs(targetY - destinationY) == 1)) || ((targetY == destinationY) && (Math.Abs(targetX - destinationX) == 1)))
			{
				error = false;
			}
			else
			{
				error = true;
			}


			return error;

		}
	}







	//==========================================================================================================
	//==========================================================================================================

	public class Move : Character
	{
		bool mate_statue;

		public int K1_X;
		public int K1_Y;
		public int K2_X;
		public int K2_Y;

		int k;
		public ChessBoard board;
		public Pawn pawn;
		public Rook rook;
		public Knight knight;

		public Bishop bishop;
		public Queen queen;
		public King king;

		protected int targetX;
		protected int targetY;
		protected int destinationX;
		protected int destinationY;

		public bool Exit { get; set; }
		public Move()
		{
			mate_statue = false;
			K1_X = 7;
			K1_Y = 4;
			K2_X = 0;
			K2_Y = 4;

			//pawn = new Pawn();
			targetX = 0;
			targetY = 0;
			destinationX = 0;
			destinationY = 0;
			
			pawn = new Pawn();
			rook = new Rook();
			knight = new Knight();

			bishop = new Bishop();
			queen = new Queen();
			king = new King();

			Exit = false;
		}

		public  void MakeMove()
		{


			string ch = "c";
			string[] holdChar = new string[2];   //[target,destination]
			if (Kish_P1()==true)
			{
				int x1=0;
				int y1=0;
				int x2=0;
				int y2=0;
				int tryCount = 0;
				mate_statue = Mate_Check(1);
				if(mate_statue==true)
				{
					Exit = true;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Player 2 win !");

					Console.ForegroundColor = ConsoleColor.DarkGreen;

					Console.WriteLine("game finished !");
					MoveMohre();
				}
				
				while (Kish_P1()==true &&Exit==false)
				{

					if(tryCount>0)
					{

						characters[x1, y1] = holdChar[0];
						characters[x2, y2] = holdChar[1];
						Console.Clear();
						boardDisplayer();

						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine(" wrong move !!! ");
					}
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("player 1 kish ");
					Console.WriteLine("player 1 , do sth !");
					Console.ResetColor();

					getInput();
					while(destinationX==K1_X&&destinationY==K1_Y)
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;

						Console.WriteLine("you cannot kill the king !!\n enter new coordinates");
						Console.ResetColor();
						getInput();

					}
					x1 = targetX;
					y1 = targetY;
					x2 = destinationX;
					y2 = destinationY;
					while (Exit == true)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("out of range inputs \t try again");
						Console.ResetColor();

						getInput();
						while (destinationX == K1_X && destinationY == K1_Y)
						{
							Console.ForegroundColor = ConsoleColor.DarkRed;

							Console.WriteLine("you cannot kill the king !!\n enter new coordinates");
							Console.ResetColor();
							getInput();

						}

						x1 = targetX;
						y1 = targetY;
						x2 = destinationX;
						y2 = destinationY;
					}
					holdChar[0] = characters[targetX, targetY];
					holdChar[1] = characters[destinationX, destinationY];
					Console.ResetColor();

					MoveMohre();
					tryCount++;
				}
				tryCount = 0;

			}
			else if(Kish_P2()==true)
			{
				int tryCount = 0;


				int x1 = 0;
				int y1 = 0;
				int x2 = 0;
				int y2 = 0;

				mate_statue = Mate_Check(2);
				if (mate_statue == true)
				{
					Exit = true;
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Player 1 win !");

					Console.ForegroundColor = ConsoleColor.DarkGreen;

					Console.WriteLine("game finished !");
					MoveMohre();
				}

				while (Kish_P2() == true && Exit==false)
				{
					if (tryCount > 0)
					{

						characters[x1, y1] = holdChar[0];
						characters[x2, y2] = holdChar[1];
						Console.Clear();
						boardDisplayer();
						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine(" wrong move !!! ");

					}
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("player 2 kish ");
					Console.WriteLine("player 2 , do sth !");
					Console.ResetColor();

					getInput();
					while (destinationX == K2_X && destinationY == K2_Y)
					{
						Console.ForegroundColor = ConsoleColor.DarkRed;

						Console.WriteLine("you cannot kill the king !!\n enter new coordinates");
						Console.ResetColor();
						getInput();

					}

					x1 = targetX;
					y1 = targetY;
					x2 = destinationX;
					y2 = destinationY;
					while (Exit==true)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("out of range inputs \t try again");
						Console.ResetColor();

						getInput();
						while (destinationX == K2_X && destinationY == K2_Y)
						{
							Console.ForegroundColor = ConsoleColor.DarkRed;

							Console.WriteLine("you cannot kill the king !!\n enter new coordinates");
							Console.ResetColor();
							getInput();

						}

						x1 = targetX;
						y1 = targetY;
						x2 = destinationX;
						y2 = destinationY;
					}
					holdChar[0] = characters[targetX, targetY];
					holdChar[1] = characters[destinationX, destinationY];
					Console.ResetColor();
					MoveMohre();
					tryCount++;
				}
				tryCount = 0;

			}
			else
			{

				int x1 = 0;
				int y1 = 0;
				int x2 = 0;
				int y2 = 0;

				getInput();

				x1 = targetX;
				y1 = targetY;
				x2 = destinationX;
				y2 = destinationY;
				try
				{
					holdChar[0] = characters[targetX, targetY];
					holdChar[1] = characters[destinationX, destinationY];

				}
				catch(IndexOutOfRangeException)
				{
					Exit = true;

				}
				MoveMohre();
				if(Exit==false)
				{
					try
					{

						if (holdChar[0][1]=='1')
						{
							if(Kish_P1()==true)
							{
								characters[x1, y1] = holdChar[0];
								characters[x2, y2] = holdChar[1];
								Console.Clear();
								boardDisplayer();
								Console.WriteLine("you cant do that ! casue you will be kish");
								Exit = true;
								MoveMohre();
							}
					
						}
						else if(holdChar[0][1] == '2')
						{
							if (Kish_P2() == true)
							{

								characters[x1, y1] = holdChar[0];
								characters[x2, y2] = holdChar[1];
								Console.Clear();
								boardDisplayer();
								Console.WriteLine("p2 you cant do that ! casue you will be kish");
								Exit = true;
								MoveMohre();
							}
					
						}
					}
					catch(NullReferenceException)
					{
					}
				}
				
			}

			

		}
		public virtual void getInput()
		{
			//get input and validate it
			// the program run until the user enters invlidate input

			Console.WriteLine("Enter targets X axis");
			Exit = validateInput(int.TryParse(Console.ReadLine(), out targetX));
			if (!Exit)// if we passed the previos validation , move to the next coordinates
			{
				Console.WriteLine("Enter targets Y axis");
				Exit = validateInput(int.TryParse(Console.ReadLine(), out targetY));
			}
			if(targetX>=0 && targetX<8 && targetY>= 0 && targetY < 8)
			{
				if (characters[targetX,targetY]=="  ")
				{
					Console.WriteLine("Error !! you cant choose void indexes ");
					Exit = true;

				}
			}

			if (!Exit)// if we passed the previos validation , move to the next coordinates
			{
				Console.WriteLine("Enter Destination X axis");
				Exit = validateInput(int.TryParse(Console.ReadLine(), out destinationX));
			}

			if (!Exit)// if we passed the previos validation , move to the next coordinates
			{
				Console.WriteLine("Enter Destination Y axis");
				Exit = validateInput(int.TryParse(Console.ReadLine(), out destinationY));
			}
		}
		public virtual bool validateInput(bool parsed)
		{
			bool error = false;
			if (!parsed)
				error = true;
			else if (targetX < 0 || targetX < 0 || destinationX < 0 || destinationY < 0)
			{
				error = true;
			}
			else if (targetX > ChessBoard.DIMENTION - 1 || targetY > ChessBoard.DIMENTION - 1 || destinationX > ChessBoard.DIMENTION - 1 || destinationY > ChessBoard.DIMENTION - 1)
			{
				error = true;

			}

			/*if ((targetX == destinationX) && (targetY == destinationY))
			{
				error = true;
				Console.ForegroundColor = ConsoleColor.DarkYellow;

				Console.WriteLine(" cant kill yoursalfe ! !!");

			}*/

			if (error)
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				
				Console.WriteLine("invalid input !!");
			}
			return error;

		}
		public virtual void rearengePawns()
		{
			if (characters[targetX, targetY]=="K1")
			{
				K1_X = destinationX;
		
				K1_Y = destinationY;
			}
			else if (characters[targetX, targetY] == "K2")
			{
				K2_X = destinationX;
				K2_Y = destinationY;
			}
			
			characters[destinationX, destinationY] = characters[targetX, targetY];
			characters[targetX, targetY] = "  ";
		
		

		}

		public void MoveMohre()
		{
			string ch = "c";
			if (!Exit)
			{
				if (targetY == destinationY && targetX == destinationX)
				{
					Console.WriteLine("you cant kill yourself sir !");
					Exit = true;
				}
				else if (characters[targetX, targetY][0] == 'P')
				{
					if (characters[targetX, targetY][1] == '1')
					{
						Exit = pawn.validateMove_P1(targetX, targetY, destinationX, destinationY);
					}
					else if (characters[targetX, targetY][1] == '2')
					{
						Exit = pawn.validateMove_P2(targetX, targetY, destinationX, destinationY);
					}

					if (!Exit)
						rearengePawns();


				}
				else if (characters[targetX, targetY][0] == 'R')
				{
					if (characters[targetX, targetY][1] == '1')
					{
						Exit = rook.validateMove_P1(targetX, targetY, destinationX, destinationY);
					}
					else if (characters[targetX, targetY][1] == '2')
					{
						Exit = rook.validateMove_P2(targetX, targetY, destinationX, destinationY);
					}

					if (!Exit)
						rearengePawns();


				}
				else if (characters[targetX, targetY][0] == 'N')
				{
					if (characters[targetX, targetY][1] == '1')
					{
						Exit = knight.validateMove_P1(targetX, targetY, destinationX, destinationY);
					}
					else if (characters[targetX, targetY][1] == '2')
					{
						Exit = knight.validateMove_P2(targetX, targetY, destinationX, destinationY);
					}

					if (!Exit)
						rearengePawns();


				}
				else if (characters[targetX, targetY][0] == 'B')
				{
					if (characters[targetX, targetY][1] == '1')
					{
						Exit = bishop.validateMove_P1(targetX, targetY, destinationX, destinationY);
					}
					else if (characters[targetX, targetY][1] == '2')
					{
						Exit = bishop.validateMove_P2(targetX, targetY, destinationX, destinationY);
					}

					if (!Exit)
						rearengePawns();
				}
				else if (characters[targetX, targetY][0] == 'Q')
				{
					if (characters[targetX, targetY][1] == '1')
					{
						Exit = queen.validateMove_P1(targetX, targetY, destinationX, destinationY);
					}
					else if (characters[targetX, targetY][1] == '2')
					{
						Exit = queen.validateMove_P2(targetX, targetY, destinationX, destinationY);
					}

					if (!Exit)
						rearengePawns();
				}
				else if (characters[targetX, targetY][0] == 'K')
				{
					if (characters[targetX, targetY][1] == '1')
					{
						Exit = king.validateMove_P1(targetX, targetY, destinationX, destinationY);
					}
					else if (characters[targetX, targetY][1] == '2')
					{
						Exit = king.validateMove_P2(targetX, targetY, destinationX, destinationY);
					}

					if (!Exit)
						rearengePawns();
				}
				else
				{
					if (!Exit)
						rearengePawns();

				}
			}
			if (Exit == true)
			{
				
				bool loop = true;
				if (mate_statue == true)
				{
					loop = false;
				}
				while (loop)
				{
					Console.ResetColor();
					Console.WriteLine("************************************");
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine("Error !");

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Press < e > for exit");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("OR :  Press  < c > for continue");
					ch = Console.ReadLine();
					if (ch == "e" || ch == "E")
					{
						Exit = true;
						Console.ForegroundColor = ConsoleColor.Red;

						Console.WriteLine("the Game finished !!   press any key to close the game ...");
						loop = false;
					}
					else if (ch == "c" || ch == "C")
					{
						Exit = false;
						loop = false;
						targetX = 0;
						targetY = 0;
						destinationX = 0;
						destinationY = 0;
					}

					Console.ResetColor();
				}



			}
			
		}


		public bool Kish_P1() // player 1 is kish??
		{
			bool kish = false;
			bool Nokish = true;  // if mokish = false => kish = true
			int k1_X = K1_X;
			int k1_Y = K1_Y;
			char symbol = ' ';

			for (int x = 0; x < ChessBoard.DIMENTION; x++)
			{
				for (int y = 0; y < ChessBoard.DIMENTION; y++)
				{
					if (Character.characters[x, y][1] == '2')
					{
						symbol = Character.characters[x, y][0];
						if (symbol == 'P')
						{
							Nokish = pawn.validate_P2(x, y, k1_X, k1_Y);
						}
						else if (symbol == 'R')
						{
							Nokish = rook.validate_P2(x, y, k1_X, k1_Y);
						}
						else if (symbol == 'N')
						{
							Nokish = knight.validate_P2(x, y, k1_X, k1_Y);
						}
						else if (symbol == 'B')
						{
							Nokish = bishop.validate_P2(x, y, k1_X, k1_Y);
						}
						else if (symbol == 'Q')
						{
							Nokish = queen.validate_P2(x, y, k1_X, k1_Y);
						}
						else if (symbol == 'K')
						{
							Nokish = king.validate_P2(x, y, k1_X, k1_Y);
						}

						if (Nokish == false)
						{
							kish = true;
							break;
						}
					}
					if(kish==true)
					{
						break;
					}
				}
			}
			/*Console.Clear();
			boardDisplayer();
*/
			return kish;
		}
		public bool Kish_P2()
		{
			
			int k2_X = K2_X;
			int k2_Y = K2_Y;

			bool kish = false;
			bool Nokish = true;  // if mokish = false => kish 
			char symbol = ' ';

			for (int x = 0; x < ChessBoard.DIMENTION; x++)
			{
				for (int y = 0; y < ChessBoard.DIMENTION; y++)
				{
					if (Character.characters[x, y][1] == '1')
					{
						symbol = Character.characters[x, y][0];
						if (symbol == 'P')
						{
							Nokish = pawn.validate_P1(x, y, k2_X, k2_Y);
						}
						else if (symbol == 'R')
						{
							Nokish = rook.validate_P1(x, y, k2_X, k2_Y);
						}
						else if (symbol == 'N')
						{
							Nokish = knight.validate_P1(x, y, k2_X, k2_Y);
						}
						else if (symbol == 'B')
						{
							Nokish = bishop.validate_P1(x, y, k2_X, k2_Y);
						}
						else if (symbol == 'Q')
						{
							Nokish = queen.validate_P1(x, y, k2_X, k2_Y);
						}
						else if (symbol == 'K')
						{
							Nokish = king.validate_P1(x, y, k2_X, k2_Y);
						}


						if(Nokish==false)
						{
							kish = true;
							break;
						}
					}
					if (kish == true)
					{
						break;
					}
				}
			}
			
			/*boardDisplayer();*/

			return kish; 
		}


		public bool Mate_Check(int Kish_player)
		{
			int num_scapes=0;
			bool mate = false;
			string[] holder = new string[2];  //[target , dest]
			char sym=' ';

			if(Kish_player==1)
			{
				

				for(int x=0; x<8;x++)
				{ 
					for (int y = 0; y < 8; y++)
					{
						if (characters[x, y][1] == '1')
						{
							sym = characters[x, y][0];

							if (sym == 'P')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (pawn.validate_P1(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P1() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if(num_scapes!=0)
											{
												return false;
											}
										}
									}
								}
							}
							else if (sym == 'B')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (bishop.validate_P1(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P1() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}
							}
							else if (sym == 'N')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (knight.validate_P1(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P1() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}

							}
							else if (sym == 'R')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (rook.validate_P1(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P1() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}

							}
							else if (sym == 'Q')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (queen.validate_P1(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P1() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}
							}
							else if (sym == 'K')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (king.validate_P1(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											K1_X = i;
											K1_Y = j;
											
											characters[x, y] = "  ";

											if (Kish_P1() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];
											K1_X = x;
											K1_Y = y;

											if (num_scapes != 0)
											{	

												return false;
											}
										}
									}
								}
							}


						}
					}

				}

				if(num_scapes==0)//////////////////////MATE 
				{
					mate = true;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Player1 !! you f@%$d up and mated bro XD !");
					Console.ResetColor();
					return true;

				}


			}
			else if(Kish_player==2)       ////p;ayer 2
			{
				for (int x = 0; x < 8; x++)
				{
					for (int y = 0; y < 8; y++)
					{
						if (characters[x, y][1] == '2')
						{
							sym = characters[x, y][0];

							if (sym == 'P')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (pawn.validate_P2(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P2() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}
							}
							else if (sym == 'B')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (bishop.validate_P2(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P2() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}
							}
							else if (sym == 'N')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (knight.validate_P2(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P2() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												Console.WriteLine("N");
												Console.ReadKey();
												return false;
											}
										}
									}
								}

							}
							else if (sym == 'R')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if(x==i&&y==j)
										{
											continue;
										}
										if (rook.validate_P2(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P2() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}

							}
							else if (sym == 'Q')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (queen.validate_P2(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";

											if (Kish_P2() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}
							}
							else if (sym == 'K')
							{
								for (int i = 0; i < 8; i++)
								{
									for (int j = 0; j < 8; j++)
									{
										if (x == i && y == j)
										{
											continue;
										}
										if (king.validate_P2(x, y, i, j) != true)
										{
											holder[0] = characters[x, y];
											holder[1] = characters[i, j];

											characters[i, j] = holder[0];
											characters[x, y] = "  ";
											K2_X = i;
											K2_Y = j;

											if (Kish_P2() == false)
												num_scapes++;

											characters[i, j] = holder[1];
											characters[x, y] = holder[0];
											K2_X = x;
											K2_Y = y;

											if (num_scapes != 0)
											{
												return false;
											}
										}
									}
								}
							}


						}
					}

				}



				if (num_scapes == 0)//////////////////////MATE 
				{
					mate = true;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(" player 2 , you F@#d up and mated  bro XD");
					Console.ResetColor();
					return true;
				}


			}
			return false;
		}


		public void boardDisplayer()
		{
			Console.Clear();
			string ChessBoardHorizentalSymboal = "+====";
			string ChessBoardVerticalSymboal = "| ";
			Console.WriteLine("    0    1    2    3    4    5    6    7     :Y ");// x axis header
			for (int r = 0; r < 8; r++)
			{
				Console.Write("  ");
				for (int c = 0; c < 8; c++)
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(ChessBoardHorizentalSymboal);  // horizental patern
				}
				Console.WriteLine("+");
				Console.ResetColor();
				Console.Write(r + " "); //y axis header

				for (int c = 0; c < 8; c++)
				{
					//Console.Write(r+"  "); //y axis header
					Console.ForegroundColor = ConsoleColor.Yellow;

					Console.Write(ChessBoardVerticalSymboal);
					Console.ResetColor();

					Console.Write(Character.characters[r, c] + " ");


				}
				Console.ForegroundColor = ConsoleColor.Yellow;

				Console.WriteLine("|");
			}

			// last line seperator

			Console.Write("  ");
			for (int c = 0; c < 8; c++)
			{
				Console.Write(ChessBoardHorizentalSymboal);  // horizental patern
			}
			Console.WriteLine("+");

			Console.ResetColor();
			Console.WriteLine("X \n");
		}



	}
	//==========================================================================================================
	//==========================================================================================================

	class Program
	{
		static void Main(string[] args)
		{
			ChessBoard chessBoard = new ChessBoard();
			chessBoard.DisplayChessBoard();
			Console.ReadKey();

		}
	}
}

