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

    public void InitShufle() // 5. Оптимізувати метод InitShufle класу Vector, створений на занятті.
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

    public bool palindromeCheck(int i, int j) // 1. Додати в клас Vector метод, який перевіряє, чи поле є паліндромом.
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

    public void arrayReverse() // 2. Додати в клас Vector метод, який реверсує елементи масиву.
    {
        for (int i = 0, j = this.arr.Length - 1; i != j && i < j; i++, j--)
        {
            (arr[j], arr[i])=(arr[i], arr[j]);
        }
    }

    public void sequence() // 3. Додати в клас Vector метод, який в масиві знаходить найдовшу підпослідовність однакових чисел.
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
}
