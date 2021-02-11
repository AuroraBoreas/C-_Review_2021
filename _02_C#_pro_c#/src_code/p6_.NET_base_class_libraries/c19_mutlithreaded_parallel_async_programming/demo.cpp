#include <iostream>
#include <string>
#include <sstream>

using namespace std;

inline int GetDigitalLen(int x)
{
    std::stringstream ss;
    ss << x;
    return ss.str().length();
}

inline void GetResult(void)
{
    int const digit = 8;
    int den = 698;
    int nom;
    int res;

    for(int i=1; i<10; ++i)
    {
        nom = digit + 10 * i;
        res = den / nom;
        std::cout << den << "/" << nom << " = " << res << ", " << GetDigitalLen(res) << std::endl;

    }
    std::cout << std::endl;
}


int main()
{

    GetResult();


    return 0;
}
