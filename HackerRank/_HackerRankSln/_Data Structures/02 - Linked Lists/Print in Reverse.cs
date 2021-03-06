﻿using _HackerRankSln._Data_Structures._02___Linked_Lists;
using System;
using System.Text;

// https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list-in-reverse

public static class Print_in_Reverse
{
    public static void ReversePrint(Node head)
    {
        Node node = head;
        StringBuilder s = new StringBuilder();

        while (node != null)
        {
            s.Insert(0, node.data.ToString() + '\n');
            node = node.next;
        }

        Console.WriteLine(s);
    }
}