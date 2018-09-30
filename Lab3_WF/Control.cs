using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3_WF
{
    class Control
    {
        public static List<char>[] GetTable()
        {
            StreamReader std = new StreamReader("input.txt");
            int n, m;
            string[] str = std.ReadLine().Split(' ');
            n = Int32.Parse(str[0]);
            m = Int32.Parse(str[1]);
            List<char>[] jobs = new List<char>[m];
            char[] names = new char[n];
            char[] next = new char[n];
            int[] priority = new int[n];
            int[] pred = new int[n];
            int[] pred1 = new int[n];
            for (int i = 0; i < n - 1; i++)
            {
                string name;
                name = std.ReadLine();
                //char t1=name
                names[i] = (char)(i + 65);
                next[name[0] - 65] = name[2];
            }
            std.Close();
            names[n - 1] = (char)(n + 64);
            char pr = '\0';
            List<char> pri = new List<char>();
            List<char> newpri = new List<char>();
            pri.Add('\0');
            int prior = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pri.Contains(next[j]))
                    {
                        priority[j] = prior;
                        prior++;
                        newpri.Add(names[j]);
                        newpri.Remove(next[j]);
                    }
                }
                // newpri.
                pri.RemoveRange(0, pri.Count);
                pri.InsertRange(0, newpri);
                if (next[i] != '\0')
                {
                    pred[next[i] - 65]++;
                    pred1[next[i] - 65]++;
                }
            }
            char[] way = new char[n];
            int[] kolvo = new int[n];
            List<char>[] onehour = new List<char>[m];
            for (int i = 0; i < m; i++)
            {
                onehour[i] = new List<char>();
            }
            for (int i = 0; i < n; i++)
            {
                way[priority[i]] = names[i];
                kolvo[priority[i]] = pred[i];
            }
            int kolv = 0;
            while (kolv != n)//pred[next[way[n - 1] - 65] - 65]
            {
                int j = 0;
                pred1.CopyTo(pred, 0);
                for (int i = n - 1; i >= 0 && j < m; i--)
                {
                    if (way[i] != '\0' && pred[way[i] - 65] == 0)
                    {
                        onehour[j].Add(way[i]);
                        j++;
                        if (next[way[i] - 65] != '\0')
                            pred1[next[way[i] - 65] - 65]--;
                        way[i] = '\0';
                        kolv++;
                    }
                }
            }
            return onehour;
        }
    }
}
