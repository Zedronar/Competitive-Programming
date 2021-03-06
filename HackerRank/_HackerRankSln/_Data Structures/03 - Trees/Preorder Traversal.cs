﻿using _HackerRankSln._Data_Structures._03___Trees;
using System;
using System.Collections.Generic;
using System.Linq;

// https://www.hackerrank.com/challenges/tree-preorder-traversal

public static class Preorder_Traversal
{
    public static void PreOrder(Node root)
    {
        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Count() > 0)
        {
            Node currentNode = stack.Pop();
            if (currentNode.right != null)
            {
                stack.Push(currentNode.right);
            }

            if (currentNode.left != null)
            {
                stack.Push(currentNode.left);
            }

            Console.WriteLine(currentNode.data + " ");
        }
    }
}