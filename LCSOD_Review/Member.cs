using System;

class Member
{
    private string m_name;
    private int m_memberID;
    private int m_annualFee;
    private int m_memberSince;

    // constructors
    public Member(string name, int memberID, int memberSince)
    {
        m_name = name;
        m_memberID = memberID;
        m_memberSince = memberSince;
    }

    public void setAnnualFee()
    {
        m_annualFee = 0;
    }
    public virtual int calculateAnnualFee()
    {
        return m_annualFee;
    }

    public virtual void printMessage()
    {
        Console.WriteLine($"\nName: {m_name} \nMember ID: {m_memberID} \nMember Since: {m_memberSince} \nAnnual Fee: {calculateAnnualFee()}");
    }

}