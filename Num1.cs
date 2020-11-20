using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolubevV
{
    static class Num1
    {
        private static Logger log = LogManager.GetCurrentClassLogger();


        public static void execute()
        {
            log.Info("Задание №1. Алгоритм шифрования DES. Выполните первый цикл алгоритма\nшифрования DES. Для получения 64 бит исходного текста используйте 8\nпервых букв из своих данных: Фамилии Имени Отчества. Для получения\nключа (256 бит) используют текст, состоящий из 32 букв.\n");
            log.Info(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n\n");
            Console.Clear();
            Console.WriteLine("Задание №1");
            //Ввод и перевод в двоичную систему
            Console.Write("Введите исходный текст (8 букв) -> ");
            string TXT = Console.ReadLine();
            string TXT_bi = HELP.getBiFromStr(TXT);
            
            Console.Write("Введите подключ (7 букв) -> ");
            string X0 = Console.ReadLine();
            string X0_bi = HELP.getBiFromStr(X0);

            //Логируем промежуточные значение
            log.Info("Перевод входящего сообщения {0} в двоичный код (кодировка ASCII) = {1}\n", TXT, TXT_bi);
            log.Info("Перевод первого подключа {0} в двоичный код (кодировка ASCII) X0 = {1}\n",X0,X0_bi);

            List<int> x0 = reducingX0(X0_bi);
            log.Info("Уменьшаем длину ключа X0 до 48 бит\n Результат Х0 = {0}\n", HELP.list2str(x0));

            List<int> txt_bi = replaceTXT(HELP.str2list(TXT_bi));
            log.Info("Выполняем операцию перестановки битовой последовательности исходного сообщения.\nРезультат = {0}\n", HELP.list2str(txt_bi));

            List<int> L0 = HELP.getL0(txt_bi);
            log.Info("Получаем L0 = {0}\n", HELP.list2str(L0));
            List<int> R0 = HELP.getR0(txt_bi);
            log.Info("Получаем R0 = {0}\n", HELP.list2str(R0));

            R0 = extendingR0(R0);
            log.Info("Расширенный R0 = {0}\n", HELP.list2str(R0));

            long a = Convert.ToInt64(HELP.list2str(R0), 2);
            long b = Convert.ToInt64(HELP.list2str(x0), 2);
            List<int> sumXORO = HELP.str2list(Convert.ToString(a ^ b, 2));
            while (sumXORO.Count < 48)
                sumXORO.Insert(0, 0);
            log.Info("Результат сложения X0 и R0 = {0}\n", HELP.list2str(sumXORO));

            sumXORO = substitutionsSBox(sumXORO);
            log.Info("Результат подстановок из таблиц = {0}\n", HELP.list2str(sumXORO));

            sumXORO = replaceAfterSbox(sumXORO);
            log.Info("Результат перестановки = {0}\n", HELP.list2str(sumXORO));

            sumXORO.AddRange(L0);
            log.Info("Обхединение R и L = {0}\n", HELP.list2str(sumXORO));

            List<int> result = permutations(sumXORO);
            log.Info("Итоговая перестановка. Результат = {0}\n", HELP.list2str(result));
            Console.WriteLine("Результат = {0}",HELP.list2str(result));
            Console.WriteLine("Подробности решения в логах.");
            Console.WriteLine("Чтобы вернуться в меню нажмите Enter...");
            Console.ReadLine();

        }

        private static List<int> permutations(List<int> RL)
        {

            List<int> result = new List<int>();
            result.Add(RL[39]);
            result.Add(RL[7]);
            result.Add(RL[47]);
            result.Add(RL[15]);
            result.Add(RL[55]);
            result.Add(RL[23]);
            result.Add(RL[63]);
            result.Add(RL[31]);
            result.Add(RL[38]);
            result.Add(RL[6]);
            result.Add(RL[46]);
            result.Add(RL[14]);
            result.Add(RL[54]);
            result.Add(RL[22]);
            result.Add(RL[62]);
            result.Add(RL[30]);
            result.Add(RL[37]);
            result.Add(RL[5]);
            result.Add(RL[45]);
            result.Add(RL[13]);
            result.Add(RL[53]);
            result.Add(RL[21]);
            result.Add(RL[61]);
            result.Add(RL[29]);
            result.Add(RL[36]);
            result.Add(RL[4]);
            result.Add(RL[44]);
            result.Add(RL[12]);
            result.Add(RL[52]);
            result.Add(RL[20]);
            result.Add(RL[60]);
            result.Add(RL[28]);
            result.Add(RL[35]);
            result.Add(RL[3]);
            result.Add(RL[43]);
            result.Add(RL[11]);
            result.Add(RL[51]);
            result.Add(RL[19]);
            result.Add(RL[59]);
            result.Add(RL[27]);
            result.Add(RL[34]);
            result.Add(RL[2]);
            result.Add(RL[42]);
            result.Add(RL[10]);
            result.Add(RL[50]);
            result.Add(RL[18]);
            result.Add(RL[58]);
            result.Add(RL[26]);
            result.Add(RL[33]);
            result.Add(RL[1]);
            result.Add(RL[41]);
            result.Add(RL[9]);
            result.Add(RL[49]);
            result.Add(RL[17]);
            result.Add(RL[57]);
            result.Add(RL[25]);
            result.Add(RL[32]);
            result.Add(RL[0]);
            result.Add(RL[40]);
            result.Add(RL[8]);
            result.Add(RL[48]);
            result.Add(RL[16]);
            result.Add(RL[56]);
            result.Add(RL[24]);

            return result;
        }

        private static List<int> substitutionsSBox(List<int> sumXORO)
        {
            List<int> result = new List<int>();
            int row, column;
            row = sumXORO[0] * 2 + sumXORO[5];
            column = sumXORO[1] * 8 + sumXORO[2] * 4 + sumXORO[3] * 2 + sumXORO[4];
            int fromS1 = HELP.sBox1[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS1, 2).PadLeft(4,'0')));
            log.Info("s-box1: Строка-{0} Столбец-{1} Значиение-{2}-{3}",row,column,fromS1,Convert.ToString(fromS1, 2).PadLeft(4, '0'));

            row = sumXORO[6] * 2 + sumXORO[11];
            column = sumXORO[7] * 8 + sumXORO[8] * 4 + sumXORO[9] * 2 + sumXORO[10];
            int fromS2 = HELP.sBox2[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS2, 2).PadLeft(4, '0')));
            log.Info("s-box2: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS2, Convert.ToString(fromS2, 2).PadLeft(4, '0'));

            row = sumXORO[12] * 2 + sumXORO[17];
            column = sumXORO[13] * 8 + sumXORO[14] * 4 + sumXORO[15] * 2 + sumXORO[16];
            int fromS3 = HELP.sBox3[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS3, 2).PadLeft(4, '0')));
            log.Info("s-box3: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS3, Convert.ToString(fromS3, 2).PadLeft(4, '0'));

            row = sumXORO[18] * 2 + sumXORO[23];
            column = sumXORO[19] * 8 + sumXORO[20] * 4 + sumXORO[21] * 2 + sumXORO[22];
            int fromS4 = HELP.sBox4[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS4, 2).PadLeft(4, '0')));
            log.Info("s-box4: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS4, Convert.ToString(fromS4, 2).PadLeft(4, '0'));

            row = sumXORO[24] * 2 + sumXORO[29];
            column = sumXORO[25] * 8 + sumXORO[26] * 4 + sumXORO[27] * 2 + sumXORO[28];
            int fromS5 = HELP.sBox5[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS5, 2).PadLeft(4, '0')));
            log.Info("s-box5: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS5, Convert.ToString(fromS5, 2).PadLeft(4, '0'));

            row = sumXORO[30] * 2 + sumXORO[35];
            column = sumXORO[31] * 8 + sumXORO[32] * 4 + sumXORO[33] * 2 + sumXORO[34];
            int fromS6 = HELP.sBox6[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS6, 2).PadLeft(4, '0')));
            log.Info("s-box6: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS6, Convert.ToString(fromS6, 2).PadLeft(4, '0'));

            row = sumXORO[36] * 2 + sumXORO[41];
            column = sumXORO[37] * 8 + sumXORO[38] * 4 + sumXORO[39] * 2 + sumXORO[40];
            int fromS7 = HELP.sBox7[row][column];           
            result.AddRange(HELP.str2list(Convert.ToString(fromS7, 2).PadLeft(4, '0')));
            log.Info("s-box7: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS7, Convert.ToString(fromS7, 2).PadLeft(4, '0'));

            row = sumXORO[42] * 2 + sumXORO[47];
            column = sumXORO[43] * 8 + sumXORO[44] * 4 + sumXORO[45] * 2 + sumXORO[46];
            int fromS8 = HELP.sBox8[row][column];
            result.AddRange(HELP.str2list(Convert.ToString(fromS8, 2).PadLeft(4, '0')));
            log.Info("s-box8: Строка-{0} Столбец-{1} Значиение-{2}-{3}", row, column, fromS8, Convert.ToString(fromS8, 2).PadLeft(4, '0'));

            return result;
        }

        private static List<int> extendingR0(List<int> R0)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < 32; i += 4)
            {
                result.Add(R0[i-1 < 0 ? 31 : i-1]);
                result.Add(R0[i]);
                result.Add(R0[i + 1]);
                result.Add(R0[i + 2]);
                result.Add(R0[i + 3]);
                result.Add(R0[i+4 > 31 ? 0 : i+4]);
            }

            return result;

        }
        private static List<int> replaceAfterSbox(List<int> r)
        {
            List<int> result = new List<int>();
            result.Add(r[15]);
            result.Add(r[6]);
            result.Add(r[19]);
            result.Add(r[20]);
            result.Add(r[28]);
            result.Add(r[11]);
            result.Add(r[27]);
            result.Add(r[16]);
            result.Add(r[0]);
            result.Add(r[14]);
            result.Add(r[22]);
            result.Add(r[25]);
            result.Add(r[4]);
            result.Add(r[17]);
            result.Add(r[30]);
            result.Add(r[9]);
            result.Add(r[1]);
            result.Add(r[7]);
            result.Add(r[23]);
            result.Add(r[13]);
            result.Add(r[31]);
            result.Add(r[26]);
            result.Add(r[2]);
            result.Add(r[8]);
            result.Add(r[18]);
            result.Add(r[12]);
            result.Add(r[29]);
            result.Add(r[5]);
            result.Add(r[21]);
            result.Add(r[10]);
            result.Add(r[3]);
            result.Add(r[24]);
            return result;
        }
        private static List<int> replaceTXT(List<int> x0)
        {
            List<int> result = new List<int>();
            result.Add(x0[57]);
            result.Add(x0[49]);
            result.Add(x0[41]);
            result.Add(x0[33]);
            result.Add(x0[25]);
            result.Add(x0[17]);
            result.Add(x0[9]);
            result.Add(x0[1]);
            result.Add(x0[59]);
            result.Add(x0[51]);
            result.Add(x0[43]);
            result.Add(x0[35]);
            result.Add(x0[27]);
            result.Add(x0[19]);
            result.Add(x0[11]);
            result.Add(x0[3]);
            result.Add(x0[61]);
            result.Add(x0[53]);
            result.Add(x0[45]);
            result.Add(x0[37]);
            result.Add(x0[29]);
            result.Add(x0[21]);
            result.Add(x0[13]);
            result.Add(x0[5]);
            result.Add(x0[63]);
            result.Add(x0[55]);
            result.Add(x0[47]);
            result.Add(x0[39]);
            result.Add(x0[31]);
            result.Add(x0[23]);
            result.Add(x0[15]);
            result.Add(x0[7]);
            result.Add(x0[56]);
            result.Add(x0[48]);
            result.Add(x0[40]);
            result.Add(x0[32]);
            result.Add(x0[24]);
            result.Add(x0[16]);
            result.Add(x0[8]);
            result.Add(x0[0]);
            result.Add(x0[58]);
            result.Add(x0[50]);
            result.Add(x0[42]);
            result.Add(x0[34]);
            result.Add(x0[26]);
            result.Add(x0[18]);
            result.Add(x0[10]);
            result.Add(x0[2]);
            result.Add(x0[60]);
            result.Add(x0[52]);
            result.Add(x0[44]);
            result.Add(x0[36]);
            result.Add(x0[28]);
            result.Add(x0[20]);
            result.Add(x0[12]);
            result.Add(x0[4]);
            result.Add(x0[62]);
            result.Add(x0[54]);
            result.Add(x0[46]);
            result.Add(x0[38]);
            result.Add(x0[30]);
            result.Add(x0[22]);
            result.Add(x0[14]);
            result.Add(x0[6]);
            return result;
        }

        private static List<int> reducingX0(string x0_bi)
        {
            List<int> X0_bi = HELP.str2list(x0_bi);
            for (int i = 7; i < X0_bi.Count; i += 8)
                X0_bi[i] = -1;
            X0_bi[X0_bi.Count - 2] = -1;
            X0_bi.RemoveAll(x => x == -1);
            return X0_bi;
        }
    }
}
