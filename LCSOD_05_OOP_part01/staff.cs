using System;
using System.Collections.Generic;

public class Staff
{
	// data members
	private string m_name;
	private const int m_hourlyRate = 30;
	private int m_hWorked;

	// static members
	public static string msg = "love and peace";
	public static int year = 2021;
	public static decimal pi = 3.14m;

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

	public int[] generateArray(int n)
    {
		if(n < 1)
		{ throw new ArgumentException("n must be >= 1"); }

		int[] tmp = new int[n];
		Random rnd = new Random();
		for(int i=0; i < n; ++i)
        {
			tmp[i] = rnd.Next();
        }

		return tmp;
    }

	public List<int> generateList(int n)
    {
		if(n < 1)
		{ throw new ArgumentException("n Must be >= 1"); }

		List<int> tmp = new List<int>();
		Random rnd = new Random();

		for(int i=0; i < n; ++i)
        {
			tmp.Add(rnd.Next(0, 101));
        }

		return tmp;
    }

	public void printNames(params string[] names)
    {
		for(int i=0; i < names.Length; ++i)
		{ Console.Write(names[i] + " ");  }
		Console.WriteLine();
    }
}
