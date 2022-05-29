enum MeatType { first, second };
enum Category { mutton, veal, pork, chicken };

sealed class Meat : Product
{
    public MeatType meatType;
    public Category meatCategory;
    private const decimal firstPercent = 15, secondPercent = 5; // Increase the cost of the product depending on its grade (firstPercent for MeatType.first, secondPercent for MeatType.second)
   
    public Meat(string n, decimal p, decimal w, MeatType t, Category c)
    {
        name = n;
        price = p;
        weight = w;
        meatType = t;
        meatCategory = c;
        if (meatType == MeatType.first)
        {
            this.price += this.price * (firstPercent/100);
        }
        else if (meatType == MeatType.second)
        {
            this.price += this.price * (secondPercent/100);
        }
    }
   
    public void setMeatType(int i)
    {
        switch (i)
        {
            case 1: this.meatType = MeatType.first; break;
            case 2: this.meatType = MeatType.second; break;
        }
    }
   
    public string getMeatType()
    {
        switch (meatType)
        {
            case MeatType.first: return "1-й";
            case MeatType.second: return "2-й";
        }
        return "";
    }

    public void setCategory(int i)
    {
        switch (i)
        {
            case 1: this.meatCategory = Category.mutton; break;
            case 2: this.meatCategory = Category.veal; break;
            case 3: this.meatCategory = Category.pork; break;
            case 4: this.meatCategory = Category.chicken; break;
        }
    }

    public string getCategory()
    {
        switch (meatCategory)
        {
            case Category.mutton: return "Баранина";
            case Category.veal: return "Телятина";
            case Category.pork: return "Свинина";
            case Category.chicken: return "Курятина";
        }
        return "";
    }

    public override void changeValue(decimal percent)
    {
        this.price += this.price * (percent/100);
    }
}