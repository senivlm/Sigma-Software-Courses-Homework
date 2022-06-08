sealed class Dairy : Product
{
    public DateTime expdate;
    private const decimal _Expired = 10, _Notexpired = 15; // Increase and decrease the cost of the product depending on its expiration date
   
    public Dairy(string n, decimal p, decimal w, DateTime e)
    {
        name = n;
        price = p;
        weight = w;
        expdate = e;

        if (DateTime.Compare(expdate, DateTime.Now) > 0) // If Dairly_products expiration date has not passed
        {
            
            price += price * (_Notexpired/100); // it price increases on {notexpired} percent
        }
        else
        {
            price -= price * (_Expired/100); // else it decreases on {expired} percent
        }
    }
  
    public void SetExpdate(int year, int month, int day)
    {
        expdate = new DateTime(year, month, day);
    }
   
    public override void ChangeValue(decimal percent)
    {
        price += price * (percent/100);
    }
}