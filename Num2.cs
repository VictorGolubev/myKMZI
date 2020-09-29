using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolubevV
{
    class Num2 {

        private static Logger log = LogManager.GetCurrentClassLogger();

        public static void execute() {
            log.Info("Задание №2. Алгоритм шифрования ГОСТ 28147-89. Выполните первый цикл\nалгоритма шифрования ГОСТ 28147 89 в режиме простой замены. Для\nполучения 64 бит исходного текста используйте 8 первых букв из своих\nданных: Фамилии Имени Отчества. Для получения ключа (256 бит)\nиспользуют текст, состоящий из 32 букв. Первый подключ содержит первые 4 буквы.\n");
            log.Info(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n\n");
            Console.Clear();
            Console.WriteLine("Задание №1");
            //Ввод и перевод в двоичную систему
            Console.Write("Введите исходный текст (8 букв) -> ");
            string TXT = Console.ReadLine();
            string TXT_bi = HELP.getBiFromStr(TXT);
            log.Info("Перевод входящего сообщения {0} в двоичный код (кодировка ASCII) = {1}\n", TXT, TXT_bi);

            Console.Write("Введите подключ (4 букв) -> ");
            string x0 = Console.ReadLine();
            string x0_bi = HELP.getBiFromStr(x0);
            log.Info("Перевод подключа {0} в двоичный код (кодировка ASCII) = {1}\n", x0, x0_bi);

            List<int> L0 = HELP.getL0(HELP.str2list(TXT_bi));
            log.Info("L0 = ",HELP.list2str(L0));
            List<int> R0 = HELP.getR0(HELP.str2list(TXT_bi));
            log.Info("R0 = ", HELP.list2str(R0));

            List<int> sum_mod_32 = F_R0X0(R0, HELP.str2list(x0_bi));
            log.Info("Результат суммирования R0 + X0 по mod 2^32 = {0}\n", HELP.list2str(sum_mod_32));

            sum_mod_32 = replace(sum_mod_32);
            log.Info("Результат суммирования R0 + X0 по mod 2^32 преобразуем в блоке подстановки.\nРезультат подстановки = {0}\n", HELP.list2str(sum_mod_32));

            sum_mod_32 = leftShift(sum_mod_32);
            log.Info("После циклического сдвига на 11 = {0}\n", HELP.list2str(sum_mod_32));


            long a = Convert.ToInt64(HELP.list2str(L0), 2);
            long b = Convert.ToInt64(HELP.list2str(sum_mod_32), 2);
            long R1 = a ^ b;

            log.Info("Результат. R1 = {0}", Convert.ToString(R1, 2).PadLeft(32, '0'));

            Console.WriteLine("Результат. R1 = {0}", Convert.ToString(R1,2).PadLeft(32,'0'));
            Console.WriteLine("Подробности в логах.");
            Console.WriteLine("Чтобы вернуться в меню нажмите Enter...");
            Console.ReadLine();
        }

        private static List<int> F_R0X0(List<int> r0, List<int> x0)
        {
            List<int> res;
            string R0 = "";
            r0.ForEach(m => R0 += m);
            string X0 = "";
            x0.ForEach(m => X0 += m);

            long a = Convert.ToInt64(R0, 2);
            long b = Convert.ToInt64(X0, 2);

            long maska = 0b11111111111111111111111111111111;

            res = HELP.str2list(Convert.ToString(sumMOD32(a, b) & maska, 2));
            return res;
        }
        private static long sumMOD32(long a, long b)
        {
            long s = 0;
            long carryin = 0; // перенос из предыдущего разряда
            long k = 1; // маска для получения самого младшего бита
            long temp_a = a;
            long temp_b = b;

            while (temp_a != 0 || temp_b != 0)
            {
                // извлечение самых младших битов
                long ak = a & k, bk = b & k;

                // вычисляем бит который переносится в следующий разряд
                long carryout = (ak & bk) | (ak & carryin) | (bk & carryin);

                // комбинация двух складываемых битов
                // и бита перенесенного из предыдущего разряда
                s |= (ak ^ bk ^ carryin);

                // то что будет перенесено в следующий разряд
                carryin = carryout << 1;

                // сдвигаем маску на один бит влево
                k <<= 1;

                // отрезаем уже обработанные младшие биты
                // остатки используются для контроля продолжения цикла
                temp_a >>= 1;
                temp_b >>= 1;
            }

            return s | carryin;
        }

        private static List<int> replace(List<int> suma)
        {
            List<int> res = new List<int>();
            int counter = 7;
            for (int i = 0; i < 32; i += 4, counter--)
            {
                int znach = suma[i] * 8 + suma[i + 1] * 4 + suma[i + 2] * 2 + suma[i + 3];
                string binZnach = Convert.ToString(HELP.s[znach][counter], 2).PadLeft(4, '0');
                res.AddRange(HELP.str2list(binZnach));
            }
            return res;
        }

        private static List<int> leftShift(List<int> param)
        {
            for (int i = 0; i < 11; i++)
            {
                int temp = param[0];
                param.RemoveAt(0);
                param.Add(temp);
            }
            return param;
        }
    }
}
