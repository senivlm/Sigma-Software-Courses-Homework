using System;
using System.Text;
class Array
{
    private int[,] _array;
    private int _columns, _rows;

    public int Columns
    {
        get => _columns;
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Кількість стовпців має бути більшою за ноль!");
            }
            _columns = value;
        }
    }

    public int Rows
    {
        get => _rows;
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Кількість рядків має бути більшою за ноль!");
            }
            _rows = value;
        }
    }

    public Array(int n, int m)
    {
        Columns = n;
        Rows = m;
        _array = new int[_columns, _rows];
    }

    public void ArrayVerticalSnake()
    {
        int num;
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                if (j % 2 == 0)
                {
                    num = (i + 1) + j * Columns;
                    _array[i, j] = num;
                }
                else
                {
                    num = (Columns - i) + j * Columns;
                    _array[i, j] = num;
                }
            }
        }
    }

    public void ArrayDiagonalSnake()
    {
        int i = 0, j = 0, num = 0;
        bool swap = true;

        for (int k = 0; k < Columns*Rows;)
        {
            if (swap)
            {
                ArrayDiagonalSnakeAlgorithm(Rows, ref i, ref j, ref num, ref k, ref swap);
            }
            else
            {
                ArrayDiagonalSnakeAlgorithm(Columns, ref j, ref i, ref num, ref k, ref swap);
            }
            swap = !swap;
        }
    }

    private void ArrayDiagonalSnakeAlgorithm(in int x, ref int i, ref int j, ref int num, ref int k, ref bool swap)
    {
        for (; (j >= 0) && (i < x); i++, j--)
        {
            if (swap) { _array[j, i] = ++num; }
            else { _array[i, j] = ++num; }
            k++;
        }
        if ((j < 0) && (i <= x - 1))
        {
            j = 0;
        }
        if (i == x)
        {
            j += 2;
            i--;
        }
    }

    public void ArraySpiralSnake()
    {
        int n = Columns, m = Rows;
        int k, i = 0, j = 0, num = 0;

        while ((i < n) && (j < m))
        {
            for (k = j; k < m; ++k)
            {
                _array[k, i] = ++num;
            }
            i++;

            for (k = i; k < n; ++k)
            {
                _array[m - 1, k] = ++num;
            }
            m--;

            if (i < n)
            {
                for (k = m - 1; k >= j; --k)
                {
                    _array[k, n - 1] = ++num;
                }
                n--;
            }
            if (j < m)
            {
                for (k = n - 1; k >= i; --k)
                {
                    _array[j, k] = ++num;
                }
                j++;
            }
        }
    }

    public void ArrayOutput()
    {
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                Console.Write(String.Format("{0,-3}", _array[i, j]));
            }
            Console.WriteLine();
        }
    }
}