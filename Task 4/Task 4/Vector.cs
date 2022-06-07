﻿enum IndexPos { First, Last, Middle }; // for QuickSort method
class Vector
{// з швидким сортуванням все добре.
    #region Variables
    public int[] arr;
    #endregion

    #region Properties
    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < arr.Length)
            {
                return arr[index];
            }
            else
            {
                throw new Exception("Index out of range array");
            }
        }
        set
        {
            arr[index] = value;
        }
    }
    #endregion

    #region Constructors
    public Vector(int n)
    {
        arr = new int[n];
    }
    #endregion

    #region Methods
    public void RandomInitialization(int a, int b)
    {
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(a, b);
        }
    }

    public void InitShufle()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }
        Random random = new Random();
        for (int i = 0; i < random.Next(arr.Length/2, arr.Length); i++)
        {
            int random1 = random.Next(0, arr.Length);
            int random2 = random.Next(0, arr.Length);
            (arr[random1], arr[random2]) = (arr[random2], arr[random1]);
        }
    }
    
    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < arr.Length; i++)
        {
            str += arr[i] + " ";
        }
        return str;
    }

    public bool PalindromeCheck(int i, int j)
    {
        bool palidrome = true;
        for (; (i != j) && (i < j); ++i, --j)
        {
            if (arr[i] != arr[j])
            {
                palidrome = false;
                break;
            }
        }
        return palidrome;
    }

    public void ArrayReverse()
    {
        for (int i = 0, j = (arr.Length - 1); (i != j) && (i < j); i++, j--)
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
    }

    public int Sequence()
    {
        int count = 0, countTemp = 0, firstIndex = 0, firstIndexTemp = 0;
        for (int i = 0; i < (arr.Length - 1); i++)
        {
            if (arr[i] == arr[i+1])
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
            case IndexPos.First: pivot = arr[leftIndex]; break;                 // First element like pivot
            case IndexPos.Last: pivot = arr[rightIndex]; break;                 // Last element like pivot
            case IndexPos.Middle: pivot = arr[(leftIndex+rightIndex)/2]; break; // Middle element like pivot
        }

        while (i <= j)
        {
            while (arr[i] < pivot)
            {
                i++;
            }
            while (arr[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                (arr[j], arr[i]) = (arr[i], arr[j]);
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
