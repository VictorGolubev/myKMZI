using NLog;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GolubevV
{
    class Num3
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public static void execute()
        {
            log.Info("Задание №3. Алгоритм шифрования RSA. Сгенерируйте открытый и\nзакрытый ключи в алгоритме шифрования RSA, выбрав простые числа p и q\nиз первой сотни. Зашифруйте сообщение, состоящее из ваших инициалов: ФИО.\n");
            log.Info(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n\n");
            Console.Clear();
            Console.WriteLine("Задание №3");
            Console.Write("Введите p -> ");
            int p = Convert.ToInt32(Console.ReadLine());
            log.Info("p = {}",p);
            Console.Write("Введите q -> ");
            int q = Convert.ToInt32(Console.ReadLine());
            log.Info("q = {}", q);

            int pq = p * q;
            log.Info("p*q = {}", pq);
            int f_n = (p - 1) * (q - 1);
            log.Info("Функция Эйлера = {0}", f_n);
            int param_d = HELP.getD(f_n);
            log.Info("d = {0}", f_n);
            int param_e = HELP.getE(param_d, f_n);
            log.Info("e = {0}", f_n);
            Console.WriteLine("Открытый ключ = ({0},{1})", param_e, pq);
            log.Info("Открытый ключ ({0},{1})", param_e, pq);
            Console.WriteLine("Секретный ключ = ({0},{1})\n\n", param_d, pq);
            log.Info("Секретный ключ ({0},{1})", param_d, pq);

            Console.WriteLine("Шифрование\n");
            Console.Write("Введите текст шифруемого сообщения -> ");
            byte[] text = Encoding.GetEncoding(1251).GetBytes(Console.ReadLine());

            string code="";

            foreach (byte temp in text)
            {
                BigInteger b = new BigInteger(temp);
                b = BigInteger.Pow(b, param_e);
                b %= pq;
                code += b.ToString() + ",";
            }
            code = code.Remove(code.Length - 1);
            Console.WriteLine("Зашифрованное сообщение -> {0}\n\n",code);
            log.Info("Сообщение {0} -> Шифр {1}", Encoding.GetEncoding(1251).GetString(text),code);


            Console.WriteLine("Расшифрование\n");
            Console.Write("Введите текст шифруемого сообщения -> ");
            string encodedText = Console.ReadLine();
            byte[] decodedText = new byte[encodedText.Split(',').Length];
            int counter = 0;
            foreach (string temp in encodedText.Split(','))
            {
                int num = Convert.ToInt32(temp);
                BigInteger b = new BigInteger(num);
                b = BigInteger.Pow(b, param_d);
                b %= pq;
                decodedText[counter++] = Convert.ToByte(b.ToString());
            }
            Console.WriteLine("Расшифрованное сообщение -> {0}\n\n", Encoding.GetEncoding(1251).GetString(decodedText));
            log.Info("Шифр {0} -> Сообщение {1}\n", encodedText, Encoding.GetEncoding(1251).GetString(decodedText));

            Console.WriteLine("Подробности в логах.");
            Console.WriteLine("Чтобы вернуться в меню нажмите Enter...");
            Console.ReadLine();
        }
    }
}
