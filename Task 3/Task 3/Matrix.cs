enum MatrixDirection { Down, Right }
class Matrix
{

    private int[,] _matrix;
    private int _rows;
    private int _cols;
    public int Rows
    {
        get => _rows;
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Кількість рядків не може бути меньше, ніж один!");
            }
            _rows = value;
        }
    }
    public int Cols
    {
        get => _cols;
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Кількість стовпців не може бути меньше, ніж один!");
            }
            _cols = value;
        }
    }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Cols = columns;
        _matrix = new int[rows, columns];
    }

    // 4. У класі Matrix створити метод, який заповнює квадратну матрицю діагональною змійкою,
    // параметром методу має бути напрям початкового повороту змійки (вправо, чи вниз), заданий змінною типу Enum.
    public void MatrixDiagonalSnake(MatrixDirection matrixDirection)
    {
        int i = 0, j = 0, num = 0;
        bool swap = true;
        if (matrixDirection == MatrixDirection.Down) { swap = false; }
        else if (matrixDirection == MatrixDirection.Right) { swap = true; }

        for (int k = 0; k < _rows*_cols;)
        {
            if (swap)
            {
                for (; (i >= 0) && (j < _cols); j++, i--)
                {
                    _matrix[i, j] = ++num;
                    k++;
                }
                if ((i < 0) && (j <= _cols - 1))
                {
                    i = 0;
                }
                if (j == _cols)
                {
                    i += 2;
                    j--;
                }
            }
            else
            {
                for (; (j >= 0) && (i < _rows); i++, j--)
                {
                    _matrix[i, j] = ++num;
                    k++;
                }
                if ((j < 0) && (i <= _rows - 1))
                {
                    j = 0;
                }
                if (i == _rows)
                {
                    j += 2;
                    i--;
                }
            }
            swap = !swap;
        }
    }

    // Додаткове завдання. Дано цілочисельна прямокутна матриця. Знайти прямокутник найбільшої площі, заповнений однаковими числами.
    public void MatrixSquare(out int iFirstIndex, out int jFirstIndex)     
    {
        int count = 0, countTemp = 0, iFirstIndexTemp = 0, jFirstIndexTemp = 0;
        iFirstIndex = 0;
        jFirstIndex = 0;

        for (int i = 0; i < _rows-1; i++)
        {
            for (int j = 0; j < _cols-1; j++)
                if ((_matrix[i, j] == _matrix[i, j+1]) && (_matrix[i+1, j] == _matrix[i+1, j+1]) && (_matrix[i, j] == _matrix[i+1, j]))
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

    public void MatrixRandomInitialization()
    {
        Random random = new Random();
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                _matrix[i, j] = random.Next(1, 5);
            }
        }
    }

    public void ArrayOutput()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Console.Write($"{_matrix[i, j]} \t");
            }
            Console.WriteLine();
        }
    }
}