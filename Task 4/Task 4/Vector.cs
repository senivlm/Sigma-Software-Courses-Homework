enum IndexPos { First, Last, Middle }; // for QuickSort method
class Vector
{
    #region Variables
    private int[] _arr;
    #endregion

    #region Properties
    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < _arr.Length)
            {
                return _arr[index];
            }
            else
            {
                throw new Exception("Index out of range array");
            }
        }
        set
        {
            _arr[index] = value;
        }
    }
    #endregion

    #region Constructors
    public Vector(int n)
    {
        if (n <= 0)
        {
            throw new Exception("Розмір матриці повинен бути більшим за нуль!");
        }
        _arr = new int[n];
    }
    #endregion

    #region Methods
    public void RandomInitialization(int a, int b)
    {
        Random random = new();
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] = random.Next(a, b);
        }
    }

    public void ShufleInitialization()
    {
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] = i + 1;
        }
        Random random = new();
        for (int i = 0; i < random.Next(_arr.Length/2, _arr.Length); i++)
        {
            int random1 = random.Next(0, _arr.Length);
            int random2 = random.Next(0, _arr.Length);
            (_arr[random1], _arr[random2]) = (_arr[random2], _arr[random1]);
        }
    }
    
    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < _arr.Length; i++)
        {
            str += _arr[i] + " ";
        }
        return str;
    }

    public bool PalindromeCheck(int i, int j)
    {
        bool palidrome = true;
        for (; (i != j) && (i < j); ++i, --j)
        {
            if (_arr[i] != _arr[j])
            {
                palidrome = false;
                break;
            }
        }
        return palidrome;
    }

    public void ArrayReverse()
    {
        for (int i = 0, j = (_arr.Length - 1); (i != j) && (i < j); i++, j--)
        {
            (_arr[j], _arr[i]) = (_arr[i], _arr[j]);
        }
    }

    public int Sequence()
    {
        int count = 0, countTemp = 0, firstIndex = 0, firstIndexTemp = 0;
        for (int i = 0; i < (_arr.Length - 1); i++)
        {
            if ((_arr[i] == _arr[i + 1]) && (_arr[i + 1] < _arr.Length))
            {
                if (countTemp == 0)
                {
                    firstIndexTemp = i;
                }
                countTemp++;
            }
            else
            {
                if (count < countTemp)
                {
                    count = countTemp;
                    firstIndex = firstIndexTemp;
                }
                countTemp = 0;
            }
        }
        return firstIndex;
    }

    public void QuickSort(int leftIndex, int rightIndex, IndexPos pos)
    {
        int i = leftIndex;
        int j = rightIndex;
        int pivot = 0;

        switch (pos)
        {
            case IndexPos.First: pivot = _arr[leftIndex]; break;                 // First element like pivot
            case IndexPos.Last: pivot = _arr[rightIndex]; break;                 // Last element like pivot
            case IndexPos.Middle: pivot = _arr[(leftIndex+rightIndex)/2]; break; // Middle element like pivot
        }

        while (i <= j)
        {
            while (_arr[i] < pivot)
            {
                i++;
            }
            while (_arr[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                (_arr[j], _arr[i]) = (_arr[i], _arr[j]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
        {
            QuickSort(leftIndex, j, pos);
        }
        if (rightIndex > i)
        {
            QuickSort(i, rightIndex, pos);
        }
    }
    #endregion
}
