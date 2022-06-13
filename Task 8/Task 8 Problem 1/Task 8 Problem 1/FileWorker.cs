static class FileWorker
{
    public static string? path;
    public static void CreateDataFile(List<Consumer> consumers, int quarter, string filename)
    {
        FileWorker.CheckIfFileExists(path + filename);
        using (StreamWriter streamWriter = new StreamWriter(path + filename))
        {
            streamWriter.WriteLine($"Номер кварталу: {quarter} | Кількість квартир: {consumers.Count}");
            streamWriter.WriteLine();
            for (int i = 0; i < consumers.Count; i++)
            {
                streamWriter.WriteLine($"Фамілія: {consumers[i].Surname} | Номер квартири: {consumers[i].ApartmentNumber} |");
                for (int j = 0; j < (consumers[i].GetMeteringsCount()/4); j++)
                {
                    int meteringIndex = (j+(quarter-1)*3);
                    streamWriter.WriteLine($"\tДата знаття показника: {consumers[i].GetMeteringIndicatorDate(meteringIndex).ToString("dd/MM/yyyy")} | Показник: {consumers[i].GetMeteringIndicator(meteringIndex)} |");
                }
                streamWriter.WriteLine();
            }
        }
    }

    public static void GetDataFromFile(List<Consumer> consumers, string filename)
    {
        FileWorker.CheckIfFileExists(path + filename);

        using (StreamReader streamReader = new StreamReader(path + filename))
        {
            string surname = "", date = "";
            int apartmentNumber = 0, indicator = 0, num = 0;
            while (!streamReader.EndOfStream)
            {
                string[] line = streamReader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < line.Length; i++) // need to be redone
                {
                    if (line[i] == "Фамілія:")
                    {
                        surname = line[i+1];
                    }
                    if (line[i] == "квартири:")
                    {
                        apartmentNumber = Convert.ToInt32(line[i+1]);
                        consumers.Add(new Consumer(surname, apartmentNumber));
                        num++;
                    }
                    if (line[i] == "показника:")
                    {
                        date = line[i+1];
                    }
                    if (line[i] == "Показник:")
                    {
                        indicator = Convert.ToInt32(line[i+1]);
                        DateTime dateTime = DateTime.Parse(date);
                        consumers[num-1].AddMetering(new Metering(indicator, dateTime));
                    }
                }
            }
        }
    }

    public static void OutputInFileListConsumers(List<Consumer> consumers, int quarter, string filename)
    {
        FileWorker.CheckIfFileExists(path + filename);

        using (StreamWriter streamWriter = new StreamWriter(path + filename))
        {
            string[] months = new string[] { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            int index = (quarter-1)*3;
            int num = 0;
            streamWriter.WriteLine("----------------------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-2} | {1,-2} | {2,-10} | {3,-36} | {4,-10} |", "#", "A#", "Прізвище", "Квартал", "Витрати"));
            streamWriter.WriteLine("----------------------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-2} | {1,-2} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} |", "", "", "", months[index], months[++index], months[++index], ""));
            streamWriter.WriteLine("----------------------------------------------------------------------------");
            foreach (Consumer consumer in consumers)
            {
                streamWriter.WriteLine(String.Format("| {0,-2} | {1,-2} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10:F1} |", ++num, consumer.ApartmentNumber, consumer.Surname, consumer.GetMeteringIndicator(0), consumer.GetMeteringIndicator(1), consumer.GetMeteringIndicator(2), Consumer.GetDebt(consumer)));
            }
            streamWriter.WriteLine("----------------------------------------------------------------------------");
        }
    }

    public static void OutputInFileConsumer(Consumer consumer, int quarter)
    {
        FileWorker.CheckIfFileExists(path + "Consumer.txt");

        using (StreamWriter streamWriter = new StreamWriter(path + "Consumer.txt"))
        {
            string[] months = new string[] { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            int index = (quarter-1)*3;
            streamWriter.WriteLine("-----------------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-2} | {1,-10} | {2,-36} | {3,-10} |", "#", "Прізвище", "Квартал", "Витрати"));
            streamWriter.WriteLine("-----------------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-2} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} |", "", "", months[index], months[++index], months[++index], ""));
            streamWriter.WriteLine("-----------------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-2} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10:F1} |", consumer.ApartmentNumber, consumer.Surname, consumer.GetMeteringIndicator(0), consumer.GetMeteringIndicator(1), consumer.GetMeteringIndicator(2), Consumer.GetDebt(consumer)));
            streamWriter.WriteLine("-----------------------------------------------------------------------");
        }

    }

    public static void OutputInFileDifferenceInDates(List<Consumer> consumers)
    {
        FileWorker.CheckIfFileExists(path + "Difference in dates.txt");

        using (StreamWriter streamWriter = new StreamWriter(path + "Difference in dates.txt"))
        {
            streamWriter.WriteLine("-----------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-2} | {1,-10} | {2,-25} | {3,-15} |", "#", "Прізвище", "Дата знаття показників", "Різниця в днях"));
            streamWriter.WriteLine("-----------------------------------------------------------------");
            foreach (Consumer consumer in consumers)
            {
                TimeSpan subtractDates = DateTime.Now.Subtract(consumer.GetMeteringIndicatorDate(0));
                streamWriter.WriteLine(String.Format("| {0,-2} | {1,-10} | {2,-25} | {3,-15} |", consumer.ApartmentNumber, consumer.Surname, consumer.GetMeteringIndicatorDate(2).ToString("dd/MM/yyyy"), subtractDates.ToString("dd")));
            }
            streamWriter.WriteLine("-----------------------------------------------------------------");
        }
    }

    public static void CheckIfFileExists(string path)
    {
        if (!File.Exists(path))
        {
            throw new Exception("File for this method does not exist!");
        }
    }
}