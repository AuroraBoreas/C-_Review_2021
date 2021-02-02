#include <iostream>

using namespace std;

int main()
{
    int a = 42;
    int b = 23;

    std::cout << [&](int x, int y)->int
                 {
                    ++a;    // 43
                    --b;    // 22
                    return x + y; // 3
                 }(1, 2) << std::endl;
    std::cout << "a = " << a << ", b = " << b << std::endl;

    return 0;
}
