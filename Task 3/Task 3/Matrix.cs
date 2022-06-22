enum MatrixDirection { Down, Right }
class Matrix
{

    private int[,] _matrix;
    private int _rows, _columns;
    public int Rows
    {
        get => _rows;
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Кількість рядків повинна бути більшою за нуль!");
            }
            _rows = value;
        }
    }
    public int Columns
    {
        get => _columns;
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Кількість стовпців повинна бути більшою за нуль!");
            }
            _columns = value;
        }
    }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _matrix = new int[Rows, Columns];
    }

    public void MatrixDiagonalSnake(MatrixDirection matrixDirection)
    {
        int i = 0, j = 0, num = 0;
        bool swap = true;
        if (matrixDirection == MatrixDirection.Down) { swap = false; }
        else if (matrixDirection == MatrixDirection.Right) { swap = true; }

        for (int k = 0; k < Columns*Rows;)
        {
            if (swap)
            {
                MatrixDiagonalSnakeAlgorithm(Rows, ref i, ref j, ref num, ref k, ref swap);
            }
            else
            {
                MatrixDiagonalSnakeAlgorithm(Columns, ref j, ref i, ref num, ref k, ref swap);
            }
            swap = !swap;
        }
    }

    private void MatrixDiagonalSnakeAlgorithm(in int x, ref int i, ref int j, ref int num, ref int k, ref bool swap)
    {
        for (; (j >= 0) && (i < x); i++, j--)
        {
            if (swap) { _matrix[j, i] = ++num; }
            else { _matrix[i, j] = ++num; }
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

    public void MatrixSquare(out int iFirstIndex, out int jFirstIndex)     
    {
        int count = 0, countTemp = 0, iFirstIndexTemp = 0, jFirstIndexTemp = 0;
        iFirstIndex = 0;
        jFirstIndex = 0;

        for (int i = 0; i < Rows - 1; i++)
        {
            for (int j = 0; j < Columns - 1; j++)
                if ((_matrix[i, j] == _matrix[i, j + 1]) && (_matrix[i + 1, j] == _matrix[i + 1, j + 1]) && (_matrix[i, j] == _matrix[i + 1, j]) && (i + 1 < _matrix.Length) && (j + 1 < _matrix.Length))
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
    }

    public void MatrixRandomInitialization(int a, int b)
    {
        Random random = new();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                _matrix[i, j] = random.Next(a, b);
            }
        }
    }

    public void ArrayOutput()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write(String.Format("{0,-3}", _matrix[i, j]));
            }
            Console.WriteLine();
        }
    }
}