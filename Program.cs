using System;

namespace Queen
{
    class Program
    {
        static int successCount = 0;
        static void Main(string[] args)
        {
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
                PrintAns(queenArr, qNum);
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
            // 檢查斜角 往上檢查
            bool leftTop = true;
            bool rightTop = true;
            bool leftBottom = true;
            bool rightBottom = true;
            // 左上
            for (int i = 1; i < qNum; i++)
            {
                if ((rowNum + colNum) / 10 == 1 || (rowNum + colNum) % 10 == 0)
                {
                    break;
                }
                else if (Array.Find(arr, o => o == ((rowNum + colNum) - (i * 11))) > 0)
                {
                    leftTop = false;
                    break;
                }
                else if (((rowNum + colNum) - (i * 11)) % 10 == 0)
                {
                    break;
                }
                else if (((rowNum + colNum) - (i * 11)) / 10 == 1)
                {
                    break;
                }
            }
            // 左下
            for (int i = 1; i < qNum; i++)
            {
                if ((rowNum + colNum) / 10 == qNum || (rowNum + colNum) % 10 == 0)
                {
                    break;
                }
                else if (Array.Find(arr, o => o == ((rowNum + colNum) + (i * 9))) > 0)
                {
                    leftBottom = false;
                    break;
                }
                else if (((rowNum + colNum) + (i * 9)) % 10 == 0)
                {
                    break;
                }
                else if (((rowNum + colNum) + (i * 9)) / 10 == qNum)
                {
                    break;
                }
            }
            // 右上
            for (int i = 1; i < qNum; i++)
            {
                if ((rowNum + colNum) / 10 == 1 || (rowNum + colNum) % 10 == qNum - 1)
                {
                    break;
                }
                else if (Array.Find(arr, o => o == ((rowNum + colNum) - (i * 9))) > 0)
                {
                    rightTop = false;
                    break;
                }
                else if (((rowNum + colNum) - (i * 9)) % 10 == qNum - 1)
                {
                    break;
                }
                else if (((rowNum + colNum) - (i * 9)) / 10 == 1)
                {
                    break;
                }
            }
            // 右下
            for (int i = 1; i < qNum; i++)
            {
                if ((rowNum + colNum) / 10 == qNum || (rowNum + colNum) % 10 == qNum - 1)
                {
                    break;
                }
                if (Array.Find(arr, o => o == ((rowNum + colNum) + (i * 9))) > 0)
                {
                    rightBottom = false;
                    break;
                }
                else if (((rowNum + colNum) + (i * 11)) % 10 == 0)
                {
                    break;
                }
                else if (((rowNum + colNum) + (i * 11)) / 10 == qNum)
                {
                    break;
                }
            }
            if (Array.Find(arr, o => o % 10 == colNum) == 0 &&
            Array.Find(arr, o => o / 10 == rowNum / 10) == 0 &&
            leftTop && rightTop && leftBottom && rightBottom)
            {
                return true;
            }
            return false;
        }

        static void PrintAns(int[] arr, int qNum)
        {
            string tmp = string.Empty;
            Array.ForEach(arr, o => tmp += o + ", ");
            Console.WriteLine(tmp);
            // 行
            for (int i = 1; i <= qNum; i++)
            {
                // 列
                for (int j = 0; j < qNum; j++)
                {
                    if (Array.Find(arr, o => o == (i * 10 + j)) > 0)
                    {
                        Console.Write("[Q]");
                    }
                    else
                    {
                        Console.Write("[*]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
