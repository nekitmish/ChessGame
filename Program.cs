using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Program
    {

        static bool isCorrectCoords(char[] coords, char[] rightSymbols)
        {
            bool ret = true;
            foreach(char coord in coords){
                if (!(rightSymbols.Contains(coord)))
                {
                    ret = false;
                }
            }
            return ret;
        }
        static bool MoveCheck(int startX, int finishX, int startY, int finishY, string figure)
        {
            int absXMove = Math.Abs(finishX - startX);
            int absYMove = Math.Abs(finishY - startY);
            if (((absXMove == 2) && (absYMove == 1)) || ((absXMove == 1) && (absYMove == 2)) && (figure == "конь"))
            {
                return true;
            }
            else if ((absXMove == 0) && (absYMove == 1) && (figure == "пешка"))
            {
                return true;
            }
            else if (((absXMove > 0) && (absYMove > 0)) && (absXMove == absYMove) && (figure == "слон"))
            {
                return true;
            }
            else if (((absXMove > 0) && (absYMove == 0)) || ((absYMove > 0) && (absXMove == 0)) && (figure == "ладья"))
            {
                return true;
            }
            else if ((((absXMove > 0) && (absYMove == 0)) || ((absYMove > 0) && (absXMove == 0))) 
                || (((absXMove > 0) && (absYMove > 0)) && (absXMove == absYMove)) 
                && (figure == "ферзь"))
            {
                return true;
            }
            else if ((absXMove <= 1) && (absYMove <= 1) && (figure == "король"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static void Main(string[] args)
        {
            bool isActive = true;
            while (isActive)
            {
                Console.WriteLine("Добро пожаловать. Введите начальное и конечное значение в формате 'A1 B2'");
                string input = Console.ReadLine();
                Console.WriteLine("Теперь введите фигуру, которой будете ходить");
                string figure = Console.ReadLine().ToLower();
                string[] figures = { "слон", "пешка", "конь", "ладья", "ферзь", "король" };
                if (!(figures.Contains(figure)))
                {
                    Console.WriteLine("Вы ввели неверное название фигуры. Попробуйте еще раз.");
                    continue;
                }
                string[] coordinates = input.Split(' ');
                string startCoord;
                string finishCoord;
                char startXCoord;
                char startYCoord;
                char finishXCoord;
                char finishYCoord;
                try
                {
                    startCoord = coordinates[0];
                    finishCoord = coordinates[1];
                    if ((startCoord.Length != 2) || (finishCoord.Length != 2))
                    {
                        throw new Exception();
                    }
                    startXCoord = Convert.ToChar(startCoord.Substring(0, 1));
                    startYCoord = Convert.ToChar(startCoord.Substring(1, 1));
                    finishXCoord = Convert.ToChar(finishCoord.Substring(0, 1));
                    finishYCoord = Convert.ToChar(finishCoord.Substring(1, 1));

                    char[] coords = { startXCoord, startYCoord, finishXCoord, finishYCoord };
                    char[] rightCoords = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', '1', '2', '3', '4', '5', '6', '7', '8'};
                    if (!isCorrectCoords(coords, rightCoords))
                    {
                        throw new Exception();
                    }
                    Console.WriteLine(startXCoord + " " + startYCoord);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Я все вижу, шалунишка. Давай по новой");
                    continue;
                    throw ex;
                }

                if (MoveCheck((int)startXCoord, (int)finishXCoord, (int)startYCoord, (int)finishYCoord, figure))
                {
                    Console.WriteLine("Ход верный");
                }
                else
                {
                    Console.WriteLine("Ход неверный");
                }
                isActive = false;
            }
            Console.ReadKey();

        }
    }
}
