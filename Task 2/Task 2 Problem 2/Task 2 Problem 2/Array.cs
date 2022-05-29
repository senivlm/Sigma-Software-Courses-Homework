using System;
using System.Text;
class Array
{
    int[,] array;

    public int[,] arrayVerticalSnake(int n, int m)
    {
        int[,] arrayVerticalSnake = new int[n, m];
        int num;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (j % 2 == 0)
                {
                    num = (i + 1) + j * n;
                    arrayVerticalSnake[i, j] = num;
                }
                else
                {
                    num = (n - i) + j * n;
                    arrayVerticalSnake[i, j] = num;
                }
            }
        }
        return arrayVerticalSnake;
    }

    public int[,] arrayDiagonalSnake(int n, int m)
    {
        int[,] arrayDiagonalSnake = new int[n, m];
        int i = 0, j = 0, num = 0;
        bool swap = true;

        for (int k = 0; k < n*m;)
        {
            if (swap)
            {
                for (; i >= 0 && j < m; j++, i--)
                {
                    arrayDiagonalSnake[i, j] = ++num;
                    k++;
                }
                if (i < 0 && j <= m - 1)
                {
                    i = 0;
                }
                if (j == m)
                {
                    i = i + 2;
                    j--;
                }
            }
            else
            {
                for (; j >= 0 && i < n; i++, j--)
                {
                    arrayDiagonalSnake[i, j] = ++num;
                    k++;
                }
                if (j < 0 && i <= n - 1)
                {
                    j = 0;
                }
                if (i == n)
                {
                    j = j + 2;
                    i--;
                }
            }
            swap = !swap;
        }
        return arrayDiagonalSnake;
    }

    public int[,] arraySpiralSnake(int n, int m)
    {
        int[,] arraySpiralSnake = new int[n, m];

        int k, i = 0, j = 0, num = 0, tn = n, tm = m;

        while (i < n && j < m)
        {
            for (k = j; k < m; ++k)
            {
                arraySpiralSnake[k, i] = ++num;
            }
            i++;

            for (k = i; k < n; ++k)
            {
                arraySpiralSnake[m - 1, k] = ++num;
            }
            m--;

            if (i < n)
            {
                for (k = m-1; k >= j; --k)
                {
                    arraySpiralSnake[k, n-1] = ++num;
                }
                n--;
            }
            if (j < m)
            {
                for (k = n-1; k >= i; --k)
                {
                    arraySpiralSnake[j, k] = ++num;
                }
                j++;
            }
        }
        return arraySpiralSnake;
    }

    public void arrayOutput(int n, int m, int[,] array)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{array[i, j]} \t");
            }
            Console.WriteLine();
        }
    }
}