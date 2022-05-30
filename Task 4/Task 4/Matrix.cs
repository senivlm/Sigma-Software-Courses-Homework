enum MatrixDirection { Down, Right }
class Matrix
{
    public static void MatrixDiagonalSnake(int n, int m, MatrixDirection matrixDirection)
    {

        int[,] matrix = new int[n, m];
        int i = 0, j = 0, num = 0;
        bool swap = true;
        if (matrixDirection == MatrixDirection.Down) { swap = false; }
        else if (matrixDirection == MatrixDirection.Right) { swap = true; }

        for (int k = 0; k < n*m;)
        {
            if (swap)
            {
                for (; (i >= 0) && (j < m); j++, i--)
                {
                    matrix[i, j] = ++num;
                    k++;
                }
                if ((i < 0) && (j <= m - 1))
                {
                    i = 0;
                }
                if (j == m)
                {
                    i += 2;
                    j--;
                }
            }
            else
            {
                for (; (j >= 0) && (i < n); i++, j--)
                {
                    matrix[i, j] = ++num;
                    k++;
                }
                if ((j < 0) && (i <= n - 1))
                {
                    j = 0;
                }
                if (i == n)
                {
                    j += 2;
                    i--;
                }
            }
            swap = !swap;
        }

        for (i = 0; i < n; i++)
        {
            for (j = 0; j < m; j++)
            {
                Console.Write($"{matrix[i, j]} \t");
            }
            Console.WriteLine();
        }
    }

    public static void MatrixSquare(int n, int m)
    {
        int[,] array = new int[n, m];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = random.Next(1, 5);
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        int count = 0, countTemp = 0, iFirstIndex = 0, jFirstIndex = 0, iFirstIndexTemp = 0, jFirstIndexTemp = 0;

        for (int i = 0; i < n-1; i++)
        {
            for (int j = 0; j < m-1; j++)
                if ((array[i, j] == array[i, j+1]) && (array[i+1, j] == array[i+1, j+1]) && (array[i, j] == array[i+1, j]))
                {
                    if (countTemp == 0)
                    {
                        iFirstIndexTemp = i;
                        jFirstIndexTemp = j;
                    }
                    countTemp++;
                }
                else
                {
                    if (count < countTemp)
                    {
                        count = countTemp;
                        iFirstIndex = iFirstIndexTemp;
                        jFirstIndex = jFirstIndexTemp;
                    }
                    countTemp = 0;
                }
        }
        Console.WriteLine($"Індекс першого елементу прямокутника: [{iFirstIndex},{jFirstIndex}].");
    }
}