using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolubevV
{
    class Num4
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public static void execute()
        {
            log.Info("Задание №4. Функция хеширования. Найти хеш–образ своей Фамилии, используя хеш–функцию\nH_i =〖(H_(i - 1) + M_i)〗^2 mod n\nгде n = pq, p, q взять из Задания №3.\n");
            log.Info(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n\n");
            Console.Clear();
            Console.WriteLine("Задание №4");
            Console.Write("Введите p -> ");
            int p = Convert.ToInt32(Console.ReadLine());
            log.Info("p = {}", p);
            Console.Write("Введите q -> ");
            int q = Convert.ToInt32(Console.ReadLine());
            log.Info("q = {}", q);
            Console.Write("Введите номер варианта -> ");
            int H = Convert.ToInt32(Console.ReadLine());
            log.Info("H = {}", H);
            int n = p * q;
            log.Info("n = p*q = {}", n);

            Console.Write("Введите сообщение -> ");
            string text = Console.ReadLine();
            log.Info("Сообщение = {}", text);

            Console.WriteLine("Хэш {0} -> {1}\n", text, Convert.ToString(HELP.getHash(text,H,n,log)));
            log.Info("Хэш {0} -> {1}", text, Convert.ToString(HELP.getHash(text, H, n, log)));


            Console.WriteLine("Подробности в логах.");  
            Console.WriteLine("Чтобы вернуться в меню нажмите Enter...");
            Console.ReadLine();
        }
    }
}
