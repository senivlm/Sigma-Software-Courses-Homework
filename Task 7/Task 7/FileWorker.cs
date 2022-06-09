using System.Text;
class FileWorker
{
    private string _path;

    public FileWorker(string path)
    {
        _path = path;
    }

    public void CheckPath()
    {
        if(!File.Exists(_path))
        {
            throw new Exception("Файл не був найдений!");
        }
    }

    public void ReadDataFromFile()
    {
        using (StreamReader streamReader = new StreamReader(_path))
        {
            // Skip first three lines
            streamReader.ReadLine();
            streamReader.ReadLine();
            streamReader.ReadLine();
            
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] lineSplit = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = lineSplit[1].Trim();
                decimal price = Convert.ToDecimal(lineSplit[3].Trim());
                decimal weight = Convert.ToDecimal(lineSplit[5].Trim());
                if (!lineSplit[7].Contains('·'))
                {
                    string meatType = (lineSplit[7].Trim());
                    string meatCategory = (lineSplit[9].Trim());
                    Storage.Append(new Meat(name, price, weight, meatType, meatCategory));
                }
                else if (!lineSplit[11].Contains('·'))
                {
                    string date = lineSplit[11].Trim();
                    string tempDay = Convert.ToString(date[0]);
                    tempDay += date[1];
                    int day = Convert.ToInt32(tempDay);

                    string tempMonth = Convert.ToString(date[3]);
                    tempMonth += date[4];
                    int month = Convert.ToInt32(tempMonth);

                    string tempYear = Convert.ToString(date[6]);
                    tempYear += date[7];
                    tempYear += date[8];
                    tempYear += date[9];
                    int year = Convert.ToInt32(tempYear);
                    Storage.Append(new Dairy(name, price, weight, new DateTime(year, month, day)));
                }
                else if (lineSplit[7].Contains('·') && lineSplit[11].Contains('·'))
                {
                    Storage.Append(new Product(name, price, weight));
                }
            }
        }
    }

    public void WriteDataToFile()
    {
        using (StreamWriter streamWriter = new(_path))
        {
            streamWriter.WriteLine("----------------------------------------------------------------------------------");
            streamWriter.WriteLine(string.Format("| {0,-10} | {1,-5:F1} | {2,-5} | {3,-10} | {4,-15} | {5,-18} |", "Назва", "Ціна", "Вага", "Сорт мяса", "Вид мяса", "Термін придатності"));
            streamWriter.WriteLine("----------------------------------------------------------------------------------");
            foreach (Product product in Storage.listProduct)
            {
                if (product is Meat)
                {
                    Meat p = product as Meat;
                    streamWriter.Write(string.Format("| {0,-10} | {1,-5:F1} | {2,-5} | {3,-10} | {4,-15} | {5,-18} |", p.Name, p.price, p.weight, p.GetMeatType(), p.GetCategory(), "··················"));
                }
                else if (product is Dairy)
                {
                    Dairy p = product as Dairy;
                    streamWriter.Write(string.Format("| {0,-10} | {1,-5:F1} | {2,-5} | {3,-10} | {4,-15} | {5,-18} |", p.Name, p.price, p.weight, "··········", "···············", p.expDate.ToString("dd/MM/yyyy")));
                }
                else
                {
                    streamWriter.Write(string.Format("| {0,-10} | {1,-5:F1} | {2,-5} | {3,-10} | {4,-15} | {5,-18} |", product.Name, product.price, product.weight, "··········", "···············", "··················"));
                }
                streamWriter.WriteLine();
            }
        }
    }
}