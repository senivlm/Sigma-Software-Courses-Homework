class Vector
{
    public static int[] arr;

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

    public Vector(int n)
    {
        arr = new int[n];
    }


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
        for (int i = 0; i < random.Next(arr.Length/2, arr.Length); i++)
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

    private static void MergeFiles(int[] firstHalf, int[] secondHalf, string path)
    {

    }
    private static void Merge(int lowIndex, int middleIndex, int highIndex)
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
            MergeSort(arr, lowIndex, middleIndex);
            MergeSort(arr, middleIndex + 1, highIndex);
            Merge(arr, lowIndex, middleIndex, highIndex);
        }
        return arr;
    }

    private static void MergeSort(int lowIndex, int highIndex)
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

    public static void MergeSortFromFile(string path) // Task 1
    {
        string line = "";

        using (StreamReader streamReader = new StreamReader(path + "Unsorted array.txt"))
        {
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
            int[] firstHalf = Vector.MergeSort(firstPartLine, 0, firstPartLine.Length - 1); // first array added to memory
            
            for (int i = 0; i < firstHalf.Length; i++)
            {
                streamWriter.Write(firstHalf[i] + " ");
            }
        } // first array deleted from memory

        using (StreamWriter streamWriter = new StreamWriter(path + "Sorted Array Second Part.txt"))
        {
            var secondPartLine = line[(midIndex)..].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            int[] secondHalf = Vector.MergeSort(secondPartLine, 0, secondPartLine.Length - 1); // second array added to memory
            
            for (int i = 0; i < secondHalf.Length; i++)
            {
                streamWriter.Write(secondHalf[i] + " ");
            }
        } // second array deleted from memory
        MergeTwoFiles(path);
    }

    public static void MergeTwoFiles(string path)
    {
        StreamReader streamReaderFirst = new StreamReader(path + "Sorted Array First Part.txt");
        StreamReader streamReaderSecond = new StreamReader(path + "Sorted Array Second Part.txt");
        StreamWriter streamWriter = new StreamWriter(path + "Sorted Array.txt");

        string lineFirst = streamReaderFirst.ReadLine();
        string lineSecond = streamReaderSecond.ReadLine();
        string element1, element2;
        int first = 0, second = 0, i = 0, j = 0;
        while (i < lineFirst.Length && j < lineSecond.Length)
        {
            element1 = "";
            while (lineFirst[i] != ' ')
            {
                element1 += lineFirst[i];
                i++;
            }
            if (element1 != "")
            {
                first = int.Parse(element1);
            }
            element2 = "";
            while (lineSecond[j] != ' ')
            {
                element2 += lineSecond[j];
                j++;
            }
            if (element2 != "") 
            { 
                second = int.Parse(element2); 
            }

            if (first < second)
            {
                streamWriter.Write(first + " ");
                i++;
            }
            else if (first > second)
            {
                streamWriter.Write(second + " ");
                j++;
            }
        }
        streamWriter.Close();
    }
    public void HeapSort(int n) // Task 2
    {
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(n, i);
        }
        for (int i = n-1; i>=0; i--)
        {
            (arr[i], arr[0])=(arr[0], arr[i]);
            Heapify(i, 0);
        }
    }
    public void Heapify(int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        } 
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }
        if (largest != i)
        {
            (arr[largest], arr[i])=(arr[i], arr[largest]);
            Heapify(n, largest);
        }
    }
}

