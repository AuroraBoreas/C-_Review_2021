using System;

class VIPMember: Member
{
    private string m_memberShip;
    public VIPMember(string name, int memberID, int memberSince, string memberShip)
    : base(name, memberID, memberSince)
    {
        m_memberShip = memberID;
    }

    public override void setAnnualFee(int annualFee)
    {
        m_annualFee = annualFee;
    }

    public override int calculateAnnualFee()
    {
        return 1200 + 12 * m_annualFee;
    }

    public virtual void printMessage()
    {
        Console.WriteLine($"\nName: {m_name} \nMember ID: {m_memberID} \nMember Since: {m_memberSince} \nAnnual Fee: {calculateAnnualFee()}");
    }    

}