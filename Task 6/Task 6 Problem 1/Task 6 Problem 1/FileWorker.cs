static class FileWorker
{
    public static void CreateDataFile(List<Consumer> consumers, string path, int quarter)
    {
        path += "Data.txt";

        if (File.Exists(path))
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine($"Номер кварталу: {quarter} | Кількість квартир: {consumers.Count}");
                streamWriter.WriteLine();
                for (int i = 0; i < consumers.Count; i++)
                {
                    streamWriter.WriteLine($"Фамілія: {consumers[i].Surname} | Номер квартири: {consumers[i].ApartmentNumber}");
                    for (int j = 0; j < (consumers[i].GetMeteringsCount()/4); j++)
                    {
                        streamWriter.WriteLine($"\tДата знаття показника: {consumers[i].GetMeteringIndicatorDate(j+((quarter-1)*3)).ToString("dd/MM/yyyy")} | Показник: {consumers[i].GetMeteringIndicator(j+((quarter-1)*3))}"); // rework
                    }
                    streamWriter.WriteLine();
                }
            }
        }
        else
        {
            throw new Exception("This file does not exist!");
        }
    }
}

