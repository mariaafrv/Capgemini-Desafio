using System;
public class Advertisement
{
    #region Variables
    private string _adName;
    private string _client;
    private DateTime _startDate;
    private DateTime _endDate;
    private float _dailyInvestment;
    #endregion

    #region Accessors
    public DateTime EndDate { get { return _endDate; } }
    public String AdName { get { return _adName; } }
    public DateTime StartDate { get { return _startDate; } }
    public float DailyInvestment { get { return _dailyInvestment; } }
    public string Client {get{return _client;}}
    #endregion
    public Advertisement (string adName, string client, DateTime startDate, DateTime endDate, float dailyInvestment)
    {
        _adName = adName;
        _client = client;
        _startDate = startDate;
        _endDate = endDate;
        _dailyInvestment = dailyInvestment; 
        PrintAD();
    }

    public void PrintAD()
    {
        Console.WriteLine("O nome do anúncio é: "+ _adName +
         "\r\nO dono do anúncio é: " + _client + 
         "\r\nA data de inicio da postagem é: " + _startDate +
         "\r\nA data de fim da postagem é: " + _endDate +
         "\r\nO investimento diário deste anúncio é de R$ " + _dailyInvestment);
    }
}