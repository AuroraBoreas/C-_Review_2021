using System;
using System.Collections.Generic;

public class Staff
{
    // data members
    private string m_name;
    private int m_hourlyRate;
    private int m_hWorked;

    // constructors
    public Staff()
    {
        Console.WriteLine("default constructor");
        m_name = "noname";
        m_hourlyRate = 0;
        m_hWorked = 0;
    }

    public Staff(string name, int hWorked)
    {
        m_name = name;
        m_hWorked = hWorked;
        m_hourlyRate = 30;
    }

    public Staff(string firstName, string lastName, int hWorked)
    {
        m_name = $"{firstName} {lastName}";
        m_hourlyRate = 30;
        m_hWorked = hWorked;
    }

    // destructors -> N/A
    
    // getter, setter
    public string Name
    {
        get
        {
            return m_name;
        }
        set
        {
            m_name = Value;
        }
    }

    public int HourlyRate
    { get; set; }

    public int HourWorked
    {
        get
        { return m_hWorked; }
        set
        { m_hWorked = Value; }
        
    }

    // repr
    public override string ToString()
    {
        return $"\nName: {m_name} \nHourlyRate: {m_hourlyRate} \nHourWorked: {m_hWorked}";
    }

    // demo: static members
    public static string msg = "hello world";
    public static decimal pi = 3.1415926m;
    public static int myNumber = 42;

    // demo: generate array
    public int[] generateArray(int n)
    {
        if(n < 1)
        { throw new ArgumentException("n must be >= 1"); }

        Random rnd = new Random();
        int min = 1, max = 101;

        int[] tmp = new int[n];
        for(int i=0; i<n; ++i)
        {
            tmp[i] = rnd.Next(min, max);
        }

        return tmp;
    }

    public List<int> generateList(int n)
    {
        if(n < 1)
        { throw new ArgumentException("n must be >= 1"); }

        Random rnd = new Random();
        int min = 1, max = 101;
        List<int> tmp = new List<int>();
        for(int i=0; i<n; ++i)
        {
            tmp.Add(rnd.Next(min, max));
        }
        
        return tmp;
    }

    // demo: generate list
}