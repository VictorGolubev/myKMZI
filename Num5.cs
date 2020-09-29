using NLog;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GolubevV
{
    class Num5
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public static void execute()
        {
            log.Info("Задание №5. Электронная цифровая подпись. Используя хеш-образ своей Фамилии, вычислите электронную цифровую подпись по схеме RSA.\n");
            log.Info(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n\n");
            Console.Clear();
            Console.WriteLine("Задание №5");
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
            int f_n = (p - 1) * (q - 1);
            log.Info("Функция Эйлера = {0}", f_n);
            int param_d = HELP.getD(f_n);
            log.Info("d = {0}", f_n);
            int param_e = HELP.getE(param_d, f_n);
            log.Info("e = {0}", f_n);
            Console.WriteLine("Открытый ключ = ({0},{1})", param_e, n);
            log.Info("Открытый ключ ({0},{1})", param_e, n);
            Console.WriteLine("Секретный ключ = ({0},{1})\n\n", param_d, n);
            log.Info("Секретный ключ ({0},{1})", param_d, n);

            Console.Write("Введите сообщение -> ");
            string text = Console.ReadLine();
            log.Info("Сообщение = {}", text);

            H = HELP.getHash(text, H, n, log);
            Console.WriteLine("Хэш {0} -> {1}\n", text, Convert.ToString(H));
            log.Info("Хэш {0} -> {1}", text, Convert.ToString(H));

            int key1 = param_e;
            int key2 = n;
            BigInteger b1 = new BigInteger(H);
            b1 = BigInteger.Pow(b1, key1);
            b1 %= key2;
            string ECP = b1.ToString();

            Console.WriteLine("ХЕШ {0} -> ЭЦП {1}. (Согласно открытым ключам)\n", Convert.ToString(H), ECP);
            log.Info("ХЕШ {0} -> ЭЦП {1}. (Согласно открытым ключам)\n", Convert.ToString(H), ECP);

            key1 = param_d;
            BigInteger b2 = new BigInteger(Convert.ToInt32(ECP));
            b2 = BigInteger.Pow(b2, key1);
            b2 %= key2;
            string ECPcheck = b2.ToString();

            Console.WriteLine("Проверка ЭЦП {0} -> {1}. (Согласно серктным ключам)\n", ECP, ECPcheck);
            log.Info("Проверка ЭЦП {0} -> {1}. (Согласно серктным ключам)\n", ECP, ECPcheck);

            Console.WriteLine("Подробности в логах.");
            Console.WriteLine("Чтобы вернуться в меню нажмите Enter...");
            Console.ReadLine();
        }
    }
}
