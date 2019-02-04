﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

// https://codeforces.com/problemset/problem/472/A
// Alternative: https://codeforces.com/contest/472/submission/35372850
public static class Design_Tutorial___Learn_from_Math
{
    // Get all primes up to N using the Sieve of Erathostenes
    private static List<int> GetAllPrimesLessThan(int maxPrime)
    {
        var primes = new List<int>();
        var maxSquareRoot = (int)Math.Sqrt(maxPrime);
        var eliminated = new BitArray(maxPrime + 1);

        for (int i = 2; i <= maxPrime; ++i)
        {
            if (!eliminated[i])
            {
                primes.Add(i);
                if (i <= maxSquareRoot)
                {
                    for (int j = i * i; j <= maxPrime; j += i)
                    {
                        eliminated[j] = true;
                    }
                }
            }
        }
        return primes;
    }

    private static bool IsPrime(int n)
    {
        return Primes.Contains(n);
    }

    private static List<int> Primes { get; set; }

    private static void Solve()
    {
        int n = ReadInt();
        Primes = GetAllPrimesLessThan(n);
        for (int i = 2; i <= n; i++)
        {
            int n1 = i;
            int n2 = n - i;
            if (!IsPrime(n1) && !IsPrime(n2))
            {
                Write(n1 + " " + n2);
                return;
            }
        }
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
            //var thread = new Thread(new Design_Tutorial___Learn_from_Math().Solve, 1024 * 1024 * 128);
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

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries); }
    public static string Read() { while (currentLineTokens.Count == 0) { currentLineTokens = new Queue<string>(ReadAndSplitLine()); } return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(Read()); }
    public static long ReadLong() { return long.Parse(Read()); }
    public static double ReadDouble() { return double.Parse(Read(), CultureInfo.InvariantCulture); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
    public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
    public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) { matrix[i] = ReadIntArray(); } return matrix; }
    public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
    {
        int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
        for (int i = 0; i < ret.Length; i++)
        {
            ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++)
            {
                ret[i][j] = matrix[j][i];
            }
        }
        return ret;
    }
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) { lines[i] = reader.ReadLine().Trim(); } return lines; }
    public static void WriteArray<T>(IEnumerable<T> array) { writer.WriteLine(string.Join(" ", array)); }
    public static void Write(params object[] array) { WriteArray(array); }
    public static void WriteLines<T>(IEnumerable<T> array)
    {
        foreach (var a in array)
        {
            writer.WriteLine(a);
        }
    }
    private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get { return ContainsKey(key) ? base[key] : default(TValue); }
            set { base[key] = value; }
        }
    }
    private static T[] Init<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) { ret[i] = new T(); } return ret; }
    #endregion
}