using System;

public class Staff
{
	// data members
	private string m_name;
	private const int m_hourlyRate = 30;
	private int m_hWorked;

	// constructors
	public Staff(string name, int workHour)
	{
		m_name = name;
		m_hWorked = workHour;
	}
	
	public Staff(string firstName, string lastName, int workHour)
    {
		m_name = $"{firstName} {lastName}";
		m_hWorked = workHour;
    }
	// no destructor?

	// getter; setter;
	public int HourWorked
	{ get; set; }
	
	public int Name
	{ get; set; }

	// display
	private void printMessage()
    {
		Console.WriteLine("Calculating Pay...");
    }

	public int calculatePay()
    {
		printMessage();
		return m_hWorked > 0 ? (m_hourlyRate * m_hWorked) : 0;
    }
	
	// overloaing
	public int calculatePay(int bonus, int allowamce)
    {
		printMessage();
		return m_hWorked > 0 ? (m_hourlyRate * m_hWorked + bonus + allowamce) : 0; 
    }


	// repr
	public override string ToString()
    {
		return ($"name of staff = {m_name}, hourlyRate = {m_hourlyRate}, hourWorked = {m_hWorked}.");
    }
}
