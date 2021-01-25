using System;

class NormalMember: Member
{
    // data members
    private string m_remark;

    // constructors
    public NormalMember(string name, int memberID, int memberSince, string remark)
    : base(name, memberID, memberSince)
    {
        m_remark = remark;
    }

    // getter, setter
    public string remark
    {
        get
        { return m_remark; }
        set
        { m_remark = value; }
    }

    public override setAnnualFee(int annualFee)
    {
        m_annualFee = annualFee;
    }

    public override int calculateAnnualFee()
    {
        return m_annualFee + 30 * 12;
    } 
    public override void printMessage()
    {
        Console.WriteLine($"\nName: {m_name} \nMember ID: {m_memberID} \nMember Since: {m_memberSince} \nAnnual Fee: {calculateAnnualFee()}");
    }



}