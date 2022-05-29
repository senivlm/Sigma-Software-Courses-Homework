sealed class Dairy_products : Product
{
    public DateTime expdate;
    private const decimal expired = 10, notexpired = 15; // Increase and decrease the cost of the product depending on its expiration date
   
    public Dairy_products(string n, decimal p, decimal w, DateTime e)
    {
        name = n;
        price = p;
        weight = w;
        expdate = e;

        if (DateTime.Compare(expdate, DateTime.Now) > 0) // If Dairly_products expiration date has not passed
        {
            
            price += price * (notexpired/100); // it price increases on {notexpired} percent
        }
        else
        {
            price -= price * (expired/100); // else it decreases on {expired} percent
        }
    }
  
    public void setExpdate(int year, int month, int day)
    {
        this.expdate = new DateTime(year, month, day);
    }
   
    public override void changeValue(decimal percent)
    {
        this.price += this.price * (percent/100);
    }
}