using System;
using System.Text;
using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            using (var prnt = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                var N = input[0];
                var M = input[1];
                if (M == 1)
                {
                    int a = 1;
                    for (int i = 0; i < N; i++)
                    {
                        prnt.WriteLine(a++);
                    }
                    return;
                }
                Dictionary<int, int> result = new Dictionary<int, int>();
                for (int i = 0; i < M; i++)
                {
                    result.Add(i, 1);
                }
                for (int j = 0; j < 10000; j++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        if (i != M - 1)
                        {
                            prnt.Write(string.Format("{0} ", result[i]));
                        }
                        else
                        {
                            prnt.WriteLine(string.Format("{0} ", result[i]));
                        }
                    }
                    if (result[0] == N)
                        return;
                    for (int i = M - 1; i > 0; i--)
                    {
                        if (result[i] >= result[i - 1] && result[i] < N)
                        {
                            result[i]++;
                            break;
                        }
                        else if (result[i] == N && result[i - 1] < N)
                        {
                            result[i - 1]++;
                            for (int k = M - 1; k >= i; k--)
                            {
                                result[k] = result[i - 1];
                            }
                            break;
                        }
                    }
                }
            }
        }
    }