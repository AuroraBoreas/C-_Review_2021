/*

this program is to solve a problem at primary-school-level for my niece;

@ZL, 20210211

*/

#include <iostream>
#include <iomanip>
#include <sstream>
#include <cmath>

using namespace std;

class MaxDivider
{
private:
    int numerator, digit, nod;

    int GetDigitalLen(int x) const
    {
        std::stringstream ss;
        ss << x;
        return ss.str().length();
    }

public:
    MaxDivider(int num=698, int dig=8)
    : numerator(num), digit(dig)
    {
        nod = GetDigitalLen(dig);
    }

    void CalcResults(void) const
    {
        int den, res;

        std::cout << numerator << "/ _" << den << ": " << std::endl;
        for (int i = 1; i < 10; ++i)
        {
            den = digit + i * std::pow(10, nod);
            res = numerator / den;

            std::cout << numerator << "/" << den << " = "
                      << std::setw(3) << std::setfill(' ') << res
                      << ", Quotient has " << GetDigitalLen(res) << " digit"
                      << std::endl;
        }
        std::cout << std::endl;
    }
};

int main()
{

    MaxDivider md = MaxDivider(698, 8);
    md.CalcResults();


    return 0;
}
