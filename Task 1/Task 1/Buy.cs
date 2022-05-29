class Buy
{

    public int purchase_num;
    public int price_sum;
    public int weight_sum;

    public Buy(Product[] Products, int s, int b, int p)
    {
        purchase_num = s + b + p;
        price_sum = s*Products[0].price + b*Products[1].price + p*Products[2].price;
        weight_sum = s*Products[0].weight + b*Products[1].weight + p*Products[2].weight;
    }

}