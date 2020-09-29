using NLog;
using System;
using System.Text;

namespace GolubevV
{
    class Program
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            int menu = 0;
            while (menu == 0)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Задание \"Алгоритм шифрования DES.\"");
                Console.WriteLine("2. Задание \"Алгоритм шифрования ГОСТ 28147-89.\"");
                Console.WriteLine("3. Задание \"Алгоритм шифрования RSA.\"");
                Console.WriteLine("4. Задание \"Функция хеширования.\"");
                Console.WriteLine("5. Задание \"Электронная цифровая подпись.\"");
                Console.WriteLine("0. Выйти");
                Console.Write("Введите номер задачи -> ");
                string input = Console.ReadLine();
                menu = input.Equals("") ? 0 : Convert.ToInt32(input);
                switch (menu)
                {
                    case 1:
                        Num1.execute();
                        log.Info("Case 1  COMPLETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n\n\n");
                        Console.Clear();
                        menu = 0;
                        break;
                    case 2:
                        Num2.execute();
                        log.Info("Case 2  COMPLETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n\n\n");
                        Console.Clear();
                        menu = 0;
                        break;
                    case 3:
                        Num3.execute();
                        log.Info("Case 3  COMPLETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n\n\n");
                        Console.Clear();
                        menu = 0;
                        break;
                    case 4:
                        Num4.execute();
                        log.Info("Case 4  COMPLETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n\n\n");
                        Console.Clear();
                        menu = 0;
                        break;
                    case 5:
                        Num5.execute();
                        log.Info("Case 5  COMPLETE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n\n\n");
                        Console.Clear();
                        menu = 0;
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Пожалуйста, введите корректный номер задачи!");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        menu = 0;
                        break;
                }
            }
        }

    }
}
