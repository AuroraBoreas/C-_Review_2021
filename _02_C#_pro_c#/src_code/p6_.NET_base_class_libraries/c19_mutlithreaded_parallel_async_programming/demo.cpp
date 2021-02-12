#include <iostream>
#include <sstream>

using namespace std;

class MaxDivider
{
private:
    int numerator, digit;

    int GetDigitalLen(int x) const
    {
        std::stringstream ss;
        ss << x;
        return ss.str().length();
    }

public:
    MaxDivider(int num=698, int dig=8)
    : numerator(num), digit(dig){}

    void CalcResults(void) const
    {
        int den, res;

        std::cout << std::endl;
        for (int i = 1; i < 10; ++i)
        {
            den = digit + 10 * i;
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
