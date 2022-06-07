﻿class Vector
{
    #region Variables
    public int[] arr;
    #endregion

    #region Properties
    public int this[int index]
    {
        get
        {
            if ((index >= 0) && (index < arr.Length))
            {
                return arr[index];
            }
            else
            {
                throw new Exception("Index out of array range!");
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

    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < arr.Length; i++)
        {
            str += arr[i] + " ";
        }
        return str;
    }

    public void InitShufle()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }
        Random random = new Random();
        for (int i = 0; i < random.Next((arr.Length / 2), arr.Length); i++)
        {
            int random1 = random.Next(0, arr.Length);
            int random2 = random.Next(0, arr.Length);
            (arr[random1], arr[random2]) = (arr[random2], arr[random1]);
        }
    }

    private static int[] Merge(int[] arr, int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (arr[left] < arr[right])
            {
                tempArray[index] = arr[left];
                left++;
            }
            else
            {
                tempArray[index] = arr[right];
                right++;
            }
            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = arr[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = arr[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            arr[lowIndex + i] = tempArray[i];
        }
        return arr;
    }

    private void Merge(int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (arr[left] < arr[right])
            {
                tempArray[index] = arr[left];
                left++;
            }
            else
            {
                tempArray[index] = arr[right];
                right++;
            }
            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = arr[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = arr[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            arr[lowIndex + i] = tempArray[i];
        }
    }

    private static int[] MergeSort(int[] arr, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            //ви ігноруєте результат повернення.
            MergeSort(arr, lowIndex, middleIndex);
            MergeSort(arr, middleIndex + 1, highIndex);
            Merge(arr, lowIndex, middleIndex, highIndex);
        }
        return arr;
    }

    private void MergeSort(int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(lowIndex, middleIndex);
            MergeSort(middleIndex + 1, highIndex);
            Merge(lowIndex, middleIndex, highIndex);
        }
    }

    public void MergeSort()
    {
        MergeSort(0, arr.Length - 1);
    }

    #region Task 1
    public static void MergeSortFromFile(string path) // Task 1
    {
        string line;
        using (StreamReader streamReader = new StreamReader(path + "Unsorted array.txt"))
        {//файл не обов'язково поміщається в стрічку.
            line = streamReader.ReadLine();
        }

        int midIndex = line.Length/2;
        while (line[midIndex] != ' ') // for cases when line is "3 15 4" and we divide it length on 2 and get 4 numbers like "4 1 5 4"
        {
            ++midIndex;
        }

        using (StreamWriter streamWriter = new StreamWriter(path + "Sorted Array First Part.txt"))
        {
            var firstPartLine = line[..(midIndex)].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            int[] firstHalf = Vector.MergeSort(firstPartLine, 0, firstPartLine.Length - 1); // first half of array added to memory

            for (int i = 0; i < firstHalf.Length; i++)
            {
                streamWriter.Write(firstHalf[i] + " ");
            }
        } // first half of array deleted from memory

        using (StreamWriter streamWriter = new StreamWriter(path + "Sorted Array Second Part.txt"))
        {
            var secondPartLine = line[(midIndex)..].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            int[] secondHalf = Vector.MergeSort(secondPartLine, 0, secondPartLine.Length - 1); // second half of array added to memory

            for (int i = 0; i < secondHalf.Length; i++)
            {
                streamWriter.Write(secondHalf[i] + " ");
            }
        } // second half of array deleted from memory
        MergeTwoFiles(path);
    }

    private static void MergeTwoFiles(string path)
    {
        using (StreamReader streamReaderFirst = new StreamReader(path + "Sorted Array First Part.txt"))
        {
            using (StreamReader streamReaderSecond = new StreamReader(path + "Sorted Array Second Part.txt"))
            {
                int first = GetNumberFromFile(streamReaderFirst);
                int second = GetNumberFromFile(streamReaderSecond);
                using (StreamWriter streamWriter = new StreamWriter(path + "Sorted Array.txt"))
                {
                    while (true)
                    {
                        if (first > second)
                        {
                            streamWriter.Write(second + " ");
                            second = GetNumberFromFile(streamReaderSecond);
                        }
                        else if (first < second)
                        {
                            streamWriter.Write(first + " ");
                            first = GetNumberFromFile(streamReaderFirst);
                        }
                        else if (second == first)
                        {
                            streamWriter.Write(first + " " + second + " ");
                            first = GetNumberFromFile(streamReaderFirst);
                            second = GetNumberFromFile(streamReaderSecond);
                        }

                        if ((first == int.MaxValue) && (second == int.MaxValue)) // solution with int.MaxValue is temporary
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private static int GetNumberFromFile(StreamReader streamReader)
    {
        string first = "";
        if (!streamReader.EndOfStream)
        {
            while (streamReader.Peek() != ' ')
            {
                first += (streamReader.Read() - '0');
            }
            streamReader.Read();
            return Convert.ToInt32(first);
        }
        return int.MaxValue;
    }

    public static void FilesExistsCheck(string path)
    {
        if(!File.Exists(path + "Unsorted Array.txt"))
        {
            FileStream fs = File.Create(path + "Unsorted Array.txt");
            fs.Close();
        }
        if (!File.Exists(path + "Sorted Array First Part.txt"))
        {
            FileStream fs = File.Create(path + "Sorted Array First Part.txt");
            fs.Close();
        }
        if (!File.Exists(path + "Sorted Array Second Part.txt"))
        {
            FileStream fs = File.Create(path + "Sorted Array Second Part.txt");
            fs.Close();
        }
        if (!File.Exists(path + "Sorted Array.txt"))
        {
            FileStream fs = File.Create(path + "Sorted Array.txt");
            fs.Close();
        }
    }
    #endregion

    #region Task 2
    public void HeapSort() // Task 2
    {
        for (int i = (arr.Length / 2 - 1); i >= 0; i--)
        {
            Heapify(arr.Length, i);
        }
        for (int i = (arr.Length - 1); i >= 0; i--)
        {
            (arr[i], arr[0]) = (arr[0], arr[i]);
            Heapify(i, 0);
        }
    }

    private void Heapify(int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        if ((left < n) && (arr[left] > arr[largest]))
        {
            largest = left;
        }
        if ((right < n) && (arr[right] > arr[largest]))
        {
            largest = right;
        }
        if (largest != i)
        {
            (arr[largest], arr[i]) = (arr[i], arr[largest]);
            Heapify(n, largest);
        }
    }
    #endregion
    #endregion
}

