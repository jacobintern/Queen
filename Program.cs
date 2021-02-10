using System;
using System.Collections;
using System.Collections.Generic;

namespace Queen
{
    class Program
    {
        static int successCount = 0;
        static void Main(string[] args)
        {
            // int[] arr = new int[2] { 10, 22 };
            // Console.WriteLine(Array.Find(arr, o => (o - 33) % 11 == 0) == 0);
            // Console.WriteLine(Array.Find(arr, o => (o - 33) % 9 == 0) == 0);
            // Console.WriteLine(Array.Find(arr, o => o % 10 == 2) == 0);
            // Console.WriteLine(Array.Find(arr, o => o / 10 == 30 / 10) == 0);
            // Console.WriteLine(Array.Find(arr, o => (o - 33) % 11 == 0) == 0 &&
            // Array.Find(arr, o => (o - 33) % 9 == 0) == 0 &&
            // Array.Find(arr, o => o % 10 == 2) == 0 &&
            // Array.Find(arr, o => o / 10 == 30 / 10) == 0);
            int qNum = 8;
            OutputResult(10, qNum, new int[qNum]);
            Console.WriteLine("result is " + successCount);
        }

        static void OutputResult(int rowNum, int qNum, int[] queenArr)
        {
            int q = ((rowNum / 10) - 1);
            // 如果皇后數量達標
            if (q == qNum)
            {
                PrintAns(queenArr);
                successCount++;
                return;
            }
            // 列起始於 0 1 2 3 ...以此類推
            for (int colNum = 0; colNum < qNum; colNum++)
            {
                if (colNum < qNum)
                {
                    if (CheckArround(queenArr, rowNum, colNum, qNum))
                    {
                        queenArr[q] = rowNum + colNum;
                        OutputResult(rowNum + 10, qNum, queenArr);
                        queenArr[q] = 0;
                    }
                }
            }
        }

        static bool CheckArround(int[] arr, int rowNum, int colNum, int qNum)
        {
            // false 有皇后 true 無皇后
            // 檢查放置的位置是否符合皇后的規則
            // * X X X * *
            // X X Q X X X
            // * X X X * *
            // X * X * X *
            // * * X * * X
            // 除了自己的九宮格內以外，不能在直線，橫線，斜線上
            if (Array.Find(arr, o => (o + 11) % 11 == (rowNum + colNum + 11) % 11) == 0 &&
            Array.Find(arr, o => (o + 9) % 9 == (rowNum + colNum + 9) % 9) == 0 &&
            Array.Find(arr, o => o % 10 == colNum) == 0 &&
            Array.Find(arr, o => o / 10 == rowNum / 10) == 0)
            {
                return true;
            }
            return false;
        }

        static void PrintAns(int[] arr)
        {
            Array.ForEach(arr, o => Console.Write(o + ", "));
            Console.WriteLine();
        }
    }
}
