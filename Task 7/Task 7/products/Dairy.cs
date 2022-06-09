sealed class Dairy : Product
{
    public DateTime expDate;
    private const decimal _Expired = 10, _NotExpired = 15; // Increase and decrease the cost of the product depending on its expiration date
   
    public Dairy(string n, decimal p, decimal w, DateTime e)
    {
        Name = n;
        price = p;
        weight = w;
        expDate = e;

        if (DateTime.Compare(expDate, DateTime.Now) > 0) // If Dairy product expiration date has not passed
        {
            
            price += price * (_NotExpired/100); // it price increases on {notexpired} percent
        }
        else
        {
            price -= price * (_Expired/100); // else it decreases on {expired} percent
        }
    }
  
    public void SetexpDate(int year, int month, int day)
    {
        expDate = new DateTime(year, month, day);
    }
   
    public override void ChangeValue(decimal percent)
    {
        price += price * (percent/100);
    }
}