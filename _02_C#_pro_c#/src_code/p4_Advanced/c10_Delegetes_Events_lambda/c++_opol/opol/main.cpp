#include <iostream>
#include <iomanip>
#include <string>
#include "point.h"

using namespace std;

int main()
{
    Point p0 = Point(), p3 = Point{},
          p1,
          p2(1, 2);

    Point myPoints[] = { p0, p1, p2, p3 };
    for(int i=0; i<4; ++i)
        std::cout << "point(" << i << ") is : " << myPoints[i] << std::endl;

    std::cout << "p1 == p2 is : " << std::boolalpha << (p1 == p2) << std::endl;
    std::cout << "p2 = " + p2.ToString() << std::endl;

    std::string s1 = "hello",
                s2 = "world";

    std::cout << "s1 == s2 : " << std::boolalpha << (s1 == s2) << std::endl;
    std::cout << "-p2 is : " << (-p2).ToString() << std::endl;

    return 0;
}
