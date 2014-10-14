using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CubikGame
{
    class Program
    {
        static Random r = new Random();
        static char[,] InitCubik(int number)
        {
            char[,] cubik = new char[7, 7];
            for (int i = 0; i < cubik.GetLength(0); i++)
                for (int j = 0; j < cubik.GetLength(1); j++)
                    if (i == 0 || j == 0 || i == cubik.GetLength(0) - 1 || j == cubik.GetLength(1) - 1)
                        cubik[i, j] = '*';
                    else
                        cubik[i, j] = ' ';
            switch (number)
            {
                case 1:
                    cubik[3, 3] = '*';
                    break;
                case 2:
                    cubik[3, 2] = '*';
                    cubik[3, 4] = '*';
                    break;
                case 3:
                    cubik[2, 2] = '*';
                    cubik[3, 3] = '*';
                    cubik[4, 4] = '*';
                    break;
                case 4:
                    cubik[2, 2] = '*';
                    cubik[2, 4] = '*';
                    cubik[4, 2] = '*';
                    cubik[4, 4] = '*';
                    break;
                case 5:
                    cubik[2, 2] = '*';
                    cubik[2, 4] = '*';
                    cubik[4, 2] = '*';
                    cubik[4, 4] = '*';
                    cubik[3, 3] = '*';
                    break;
                case 6:
                    cubik[2, 2] = '*';
                    cubik[2, 3] = '*';
                    cubik[2, 4] = '*';
                    cubik[4, 2] = '*';
                    cubik[4, 3] = '*';
                    cubik[4, 4] = '*';
                    break;
            }
            return cubik;
        }


        static int ShowCubik()
        {
            int number = r.Next(1, 7);
            char[,] cubik = InitCubik(number);
            for (int i = 0; i < cubik.GetLength(0); i++)
            {
                for (int j = 0; j < cubik.GetLength(1); j++)
                    Console.Write(cubik[i, j]);
                Console.WriteLine();
            }
            return number;
        }


        static void StartGame(byte queueNumber1)
        {
            int humanScore = 0;
            int compScore = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == queueNumber1)
                    {
                        Console.WriteLine("Бросает человек.\nНажмите любую клавишу для броска кубиков ...");
                        Console.ReadKey();
                        Thread.Sleep(500);
                        humanScore += ShowCubik();
                        humanScore += ShowCubik();
                    }
                    else
                    {
                        Console.WriteLine("Бросает компьютер ...");
                        Thread.Sleep(1000);
                        compScore += ShowCubik();
                        compScore += ShowCubik();
                    }
                }
            }
            Console.WriteLine("Игра окончена.");
            Console.WriteLine("Человек - {0} баллов.", humanScore);
            Console.WriteLine("Компьютер - {0} баллов.", compScore);
            if (humanScore > compScore)
                Console.WriteLine("Победитель Человек!!!");
            else if (humanScore < compScore)
                Console.WriteLine("Победитель компьютер.");
            else
                Console.WriteLine("Ничья :)");
        }


        static void Main(string[] args)
        {
            char key;
            byte queueNumber = 0; 
            //флаг очередности, если 0, первым ходит человек. 1- компьютер.
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Выберите очередность хода:\n0 - первый бросает кубики человек\n1 - первый бросает компьютер");
            try
            {
                queueNumber = Convert.ToByte(Console.ReadLine());
            }
            catch
            {
                queueNumber = 0;//по умолчанию первый бросает кубики человек.
            }
            if (queueNumber != 1 && queueNumber != 0)
                queueNumber = 0;//по умолчанию первый бросает кубики человек.

            do
            {
                StartGame(queueNumber);
                Console.WriteLine("\nЕсли хотите сыграть еще раз, нажмите 'Y' или 'y'.");
                try
                {
                    key = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    key = 'n';
                }
            } while (key == 'Y' || key == 'y');
        }
    }
}