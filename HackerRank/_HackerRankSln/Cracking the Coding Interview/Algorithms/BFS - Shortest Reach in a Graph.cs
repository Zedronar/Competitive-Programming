﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _HackerRankSln.Cracking_the_Coding_Interview
{
    public class BFS___Shortest_Reach_in_a_Graph
    {
        private static void Solve()
        {
            int q = ReadInt();
            while (q-- > 0)
            {
                int n, s;
                List<int>[] g;
                GetInput(out n, out g, out s);

                int[] a = Enumerable.Repeat(-1, n).ToArray();

                var queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(Tuple.Create(s, 0));

                while (queue.Count > 0)
                {
                    Tuple<int, int> node = queue.Dequeue();

                    if (a[node.Item1] != -1)
                    {
                        continue;
                    }

                    a[node.Item1] = node.Item2 * 6;

                    if (g[node.Item1] != null)
                    {
                        foreach (int v in g[node.Item1])
                        {
                            queue.Enqueue(Tuple.Create(v, node.Item2 + 1));
                        }
                    }
                }

                WriteArray(a.Where(ai => ai != 0));
            }
        }

        private static void GetInput(out int n, out List<int>[] g, out int s)
        {
            n = ReadInt();
            var m = ReadInt();
            g = new List<int>[n];
            for (int i = 0; i < m; i++)
            {
                var u = ReadInt() - 1;
                var v = ReadInt() - 1;
                if (g[u] == null) g[u] = new List<int>();
                if (g[v] == null) g[v] = new List<int>();

                // Add edges to both nodes
                g[u].Add(v);
                g[v].Add(u);
            }

            s = ReadInt() - 1;
        }

        #region Main

        private static TextReader reader;
        private static TextWriter writer;

        public static void Main()
        {
#if DEBUG

            //reader = new StreamReader("C:\\Users\\Axel\\Desktop\\input.txt");
            reader = new StreamReader(Console.OpenStandardInput());
            writer = Console.Out;

            //writer = new StreamWriter("..\\..\\output.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        //reader = new StreamReader("input.txt");
        //writer = new StreamWriter("output.txt");
#endif
            try
            {
                Solve();

                //var thread = new Thread(new String_Task().Solve, 1024 * 1024 * 128);
                //thread.Start();
                //thread.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
#if DEBUG
#else
            throw;
#endif
            }
            reader.Close();
            writer.Close();
        }

        #endregion Main

        #region Read / Write
        private static Queue<string> currentLineTokens = new Queue<string>();
        private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries); }
        public static string Read() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(Read()); }
        public static long ReadLong() { return long.Parse(Read()); }
        public static double ReadDouble() { return double.Parse(Read(), CultureInfo.InvariantCulture); }
        public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
        public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
        public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
        public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
        public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
        {
            int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
            for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
            return ret;
        }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
        public static void WriteArray<T>(IEnumerable<T> array) { writer.WriteLine(string.Join(" ", array)); }
        public static void Write(params object[] array) { WriteArray(array); }
        public static void WriteLines<T>(IEnumerable<T> array) { foreach (var a in array) writer.WriteLine(a); }
        private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        {
            public new TValue this[TKey key]
            {
                get { return ContainsKey(key) ? base[key] : default(TValue); }
                set { base[key] = value; }
            }
        }
        private static T[] Init<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }
        #endregion
    }
}
