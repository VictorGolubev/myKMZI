using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolubevV
{
    public static class HELP
    {
        public static Dictionary<int, List<int>> sBox1 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7} },
            {1, new List<int>(){0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8} },
            {2, new List<int>(){4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0} },
            {3, new List<int>(){15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13} }

        };
        public static Dictionary<int, List<int>> sBox2 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10} },
            {1, new List<int>(){13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1} },
            {2, new List<int>(){0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15} },
            {3, new List<int>(){13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9} }
        };
        public static Dictionary<int, List<int>> sBox3 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8} },
            {1, new List<int>(){13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1} },
            {2, new List<int>(){13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7} },
            {3, new List<int>(){1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12} }
        };
        public static Dictionary<int, List<int>> sBox4 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15} },
            {1, new List<int>(){13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9} },
            {2, new List<int>(){10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4} },
            {3, new List<int>(){3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14} }
        };
        public static Dictionary<int, List<int>> sBox5 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9} },
            {1, new List<int>(){14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6} },
            {2, new List<int>(){4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14} },
            {3, new List<int>(){11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3} }
        };
        public static Dictionary<int, List<int>> sBox6 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11} },
            {1, new List<int>(){10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8} },
            {2, new List<int>(){9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6} },
            {3, new List<int>(){4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13} }
        };
        public static Dictionary<int, List<int>> sBox7 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1} },
            {1, new List<int>(){13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6} },
            {2, new List<int>(){1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,3} },
            {3, new List<int>(){6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12} }
        };
        public static Dictionary<int, List<int>> sBox8 = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7} },
            {1, new List<int>(){1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2} },
            {2, new List<int>(){7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8} },
            {3, new List<int>(){2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11} }
        };

        public static Dictionary<int, List<int>> s = new Dictionary<int, List<int>>()
        {
            {0, new List<int>(){ 4, 14, 5, 7, 6, 4, 13, 1 } },
            {1, new List<int>(){ 10, 11, 8, 13, 12, 11, 11, 15 } },
            {2, new List<int>(){ 9, 4, 1, 10, 7, 10, 4, 13 } },
            {3, new List<int>(){ 2, 12, 13, 1, 1, 0, 1, 0 } },
            {4, new List<int>(){ 13, 6, 10, 0, 5, 7, 3, 5 } },
            {5, new List<int>(){ 8, 13, 3, 8, 15, 2, 15, 7 } },
            {6, new List<int>(){ 0, 15, 4, 9, 13, 1, 5, 10 } },
            {7, new List<int>(){ 14, 10, 2, 15, 8, 13, 9, 4 } },
            {8, new List<int>(){ 6, 2, 14, 14, 4, 3, 0, 9 } },
            {9, new List<int>(){ 11, 3, 15, 4, 10, 6, 10, 2 } },
            {10, new List<int>(){ 1, 8, 12, 6, 9, 8, 14, 3 } },
            {11, new List<int>(){ 12, 1, 7, 12, 14, 5, 7, 14 } },
            {12, new List<int>(){ 7, 0, 6, 11, 0, 9, 6, 6 } },
            {13, new List<int>(){ 15, 7, 0, 2, 3, 12, 8, 11 } },
            {14, new List<int>(){ 5, 5, 9, 5, 11, 15, 2, 8 } },
            {15, new List<int>(){ 3, 9, 11, 3, 2, 14, 12, 12 } },
        };

        public static string getBiFromStr(string s)
        {
            byte[] txt = Encoding.GetEncoding(1251).GetBytes(s);
            string s_bi = "";
            foreach (byte b in txt)
                s_bi += Convert.ToString(b, 2);
            return s_bi;
        }

        public static string list2str(List<int> s)
        {
            string result = "";
            foreach (int c in s)
                result += Convert.ToString(c);
            return result;
        }
        public static List<int> str2list(string s)
        {
            List<int> result = new List<int>();
            foreach (char c in s.ToCharArray())
                result.Add(c-'0');
            return result;
        }


        public static List<int> getR0(List<int> txt_bi)
        {
            List<int> result = new List<int>();
            for (int i = 32; i < 64; i++)
                result.Add(txt_bi[i]);
            return result;
        }

        public static List<int> getL0(List<int> txt_bi)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < 32; i++)
                result.Add(txt_bi[i]);
            return result;
        }
        
        public static int getHash(string text, int H, int n, Logger log)
        {
            byte[] txt = Encoding.GetEncoding(1251).GetBytes(text);
            int counter = 0;
            log.Info("H{0} = {1}", counter++, H);
            foreach (byte temp in txt)
            {
                H = (H + temp) * (H + temp) % n;
                log.Info("H{0} = {1}", counter++, H);
            }
            return H;
        }

        public static int getE(int d, int f_n)
        {
            //e*d=f_n*k+1 уравнение
            int e = -1;

            int k = 1;
            while (e < 0)
            {
                e = (f_n * k + 1) % d == 0 ? (f_n * k + 1) / d : -1;
                k++;
            }
            return e;
        }
        public static int getD(int f_n)
        {
            int res = -1;

            int temp = 2;
            while (res < 0)
            {
                if (NOD(temp, f_n) == 1 && temp < f_n)
                    res = temp;
                temp++;
            }
            return res;
        }

        private static int NOD(int x, int y)
        {
            while (x != y)
            {
                if (x > y)
                    x = x - y;
                else
                    y = y - x;
            }
            return x;
        }
    }
}
