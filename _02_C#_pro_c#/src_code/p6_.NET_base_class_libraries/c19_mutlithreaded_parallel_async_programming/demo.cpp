/*

this program is to solve a problem at primary-school-level for my niece;

@ZL, 20210211

*/

#include <iostream>
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
    MaxDivider(int num=698, int dig=8, int numOfDigits=2)
    : numerator(num), digit(dig), nod(numOfDigits){}

    void CalcResults(void) const
    {
        int den, res;

        std::cout << std::endl;
        for (int i = 1; i < 10; ++i)
        {
            den = digit + i * std::pow(10, nod-1);
            res = numerator / den;

            std::cout << numerator << "/" << den << " = " << res << ", " << GetDigitalLen(res) << std::endl;
        }
        std::cout << std::endl;
    }
};

int main()
{

    MaxDivider md = MaxDivider();
    md.CalcResults();


    return 0;
}
