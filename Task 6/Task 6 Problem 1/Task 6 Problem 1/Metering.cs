class Metering
{
    #region Variables
    public int counterIndicator;
    public DateTime takingIndicatorDate;
    #endregion

    #region Constructors
    public Metering(int c, DateTime t)
    {
        counterIndicator = c;
        takingIndicatorDate = t;
    }
    #endregion
}