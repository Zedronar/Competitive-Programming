﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public static class Merge_Sort___Counting_Inversions
{
    private static int[] tempData;

    private static void Solve()
    {
        int T = ReadInt();
        while (--T >= 0)
        {
            int n = ReadInt();
            int[] arr = ReadIntArray();
            tempData = new int[n];
            long swaps = mergesort(arr, 0, n - 1);

            Write(swaps);
        }
    }

    private static long mergesort(int[] data, int leftStart, int rightEnd)
    {
        if (leftStart >= rightEnd)
        {
            // done
            return 0;
        }

        int middle = leftStart + (rightEnd - leftStart) / 2;
        long count = mergesort(data, leftStart, middle);
        count += mergesort(data, middle + 1, rightEnd);
        count += mergeData(data, leftStart, rightEnd);

        return count;
    }

    private static long mergeData(int[] data, int leftStart, int rightEnd)
    {
        int index = leftStart;
        long count = 0;
        int middle = leftStart + (rightEnd - leftStart) / 2;

        int leftEnd = middle;
        int rightStart = middle + 1;
        int left = leftStart;
        int right = rightStart;
        while (left <= leftEnd || right <= rightEnd)
        {
            if (left > leftEnd)
                tempData[index] = data[right++];
            else if (right > rightEnd)
                tempData[index] = data[left++];
            else if (data[left] <= data[right])
            {
                tempData[index] = data[left++];
            }
            else
            {
                // swap
                tempData[index] = data[right++];
                count += middle + 1 - left;
            }

            index++;
        }

        Array.Copy(tempData, leftStart, data, leftStart, rightEnd - leftStart + 1);

        return count;
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

    public static string Read()
    {
        while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue();
    }

    public static int ReadInt()
    {
        return int.Parse(Read());
    }

    public static long ReadLong()
    {
        return long.Parse(Read());
    }

    public static double ReadDouble()
    {
        return double.Parse(Read(), CultureInfo.InvariantCulture);
    }

    public static int[] ReadIntArray()
    {
        return ReadAndSplitLine().Select(int.Parse).ToArray();
    }

    public static long[] ReadLongArray()
    {
        return ReadAndSplitLine().Select(long.Parse).ToArray();
    }

    public static double[] ReadDoubleArray()
    {
        return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
    }

    public static int[][] ReadIntMatrix(int numberOfRows)
    {
        int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix;
    }

    public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
    {
        int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
        for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
        return ret;
    }

    public static string[] ReadLines(int quantity)
    {
        string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines;
    }

    public static void WriteArray<T>(IEnumerable<T> array)
    {
        writer.WriteLine(string.Join(" ", array));
    }

    public static void Write(params object[] array)
    {
        WriteArray(array);
    }

    public static void WriteLines<T>(IEnumerable<T> array)
    {
        foreach (var a in array) writer.WriteLine(a);
    }

    private static string[] ReadAndSplitLine()
    {
        return reader.ReadLine().Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries);
    }

    private static T[] Init<T>(int size) where T : new()
    {
        var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret;
    }

    private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get { return ContainsKey(key) ? base[key] : default(TValue); }
            set { base[key] = value; }
        }
    }

    #endregion Read / Write
}