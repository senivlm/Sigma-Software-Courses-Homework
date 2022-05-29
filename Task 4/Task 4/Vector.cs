enum indexPos { first, last, middle }; // for quickSort method
class Vector
{
    int[] arr;

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

    public Vector(int[] arr)
    {
        this.arr = arr;
    }

    public Vector(int n)
    {
        arr = new int[n];
    }

    public Vector() { }

    public void InitShufle(int a, int b)
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
        int randomNumberOfTimes = new Random().Next(5, 10);
        int random1, random2;
        for (int i = 0; i < randomNumberOfTimes; i++)
        {
            random1 = random.Next(0, arr.Length);
            random2 = random.Next(0, arr.Length);
            (arr[random1], arr[random2]) = (arr[random2], arr[random1]);
        }
    }

    public Pair[] CalculateFreq()
    {

        Pair[] pairs = new Pair[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            pairs[i] = new Pair(0, 0);

        }
        int countDifference = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            bool isElement = false;
            for (int j = 0; j < countDifference; j++)
            {
                if (arr[i] == pairs[j].Number)
                {
                    pairs[j].Freq++;
                    isElement = true;
                    break;
                }
            }
            if (!isElement)
            {
                pairs[countDifference].Freq++;
                pairs[countDifference].Number = arr[i];
                countDifference++;
            }
        }

        Pair[] result = new Pair[countDifference];
        for (int i = 0; i < countDifference; i++)
        {
            result[i] = pairs[i];
        }

        return result;
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

    public bool palindromeCheck(int i, int j)
    {
        bool palidrome = true;
        for (; i != j && i < j; ++i, --j)
        {
            if (arr[i] != arr[j])
            {
                palidrome = false;
                break;
            }
        }
        return palidrome;
    }

    public void arrayReverse()
    {
        for (int i = 0, j = this.arr.Length - 1; i != j && i < j; i++, j--)
        {
            (arr[j], arr[i])=(arr[i], arr[j]);
        }
    }

    public void sequence()
    {
        int count = 0, countTemp = 0, firstIndex = 0, firstIndexTemp = 0;
        for (int i = 0; i < arr.Length - 1; i++)
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
        Console.WriteLine($"Перший індекс найдовшої послідовності одинакових чисел: {firstIndex}");
    }
    public void quickSort(int leftIndex, int rightIndex, indexPos pos)
    {
        int i = leftIndex;
        int j = rightIndex;
        int pivot = 0;

        switch (pos)
        {
            case indexPos.first: pivot = arr[leftIndex]; break;                 // First element like pivot
            case indexPos.last: pivot = arr[rightIndex]; break;                 // Last element like pivot
            case indexPos.middle: pivot = arr[(leftIndex+rightIndex)/2]; break; // Middle element like pivot
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
                (arr[j], arr[i])=(arr[i], arr[j]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
        {
            quickSort(leftIndex, j, pos);
        }
        if (rightIndex > i)
        {
            quickSort(i, rightIndex, pos);
        }
    }
}
