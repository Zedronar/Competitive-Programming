﻿// https://leetcode.com/problems/battleships-in-a-board/
public partial class Solution
{
    public int CountBattleships(char[,] board)
    {
        int count = 0;
        for (int i = 0; i < board.GetLength(0); i++)
            for (int j = 0; j < board.GetLength(1); j++)
                if (board[i, j] == 'X'
                    && (i == 0 || board[i - 1, j] == '.')
                    && (j == 0 || board[i, j - 1] == '.'))
                    count++;

        return count;
    }
}