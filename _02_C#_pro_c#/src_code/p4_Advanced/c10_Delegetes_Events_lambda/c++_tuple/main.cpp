#include <iostream>
#include <tuple>
#include <iomanip>
#include <string>

int main()
{
    // pair, bundle 2 elements together for usage
    {
        std::pair<std::string, int> t1{"hello", 42};
        auto t2 = std::make_pair(3.14f, 0x7fff);

        std::cout << t1.first << ", " << t1.second << std::endl;
        std::cout << t2.first << ", " << std::hex << t2.second << std::endl;

    }

    // tuple: extend the concept of pair to ultimate
    {
        std::tuple<char, short, int, long, float, double, std::string> t3 {
                    'a', 12, 42, 1237890L, 3.14, 2.71828, "bonjour" };

        char ch;
        short sh;
        int i;
        long l;
        float f;
        double d;
        std::string s;

        // unbox
        std::tie(ch, sh, i, l, f, d, s) = t3;

        std::cout << ch << ", " << sh << ", " << i << ", " << l
                  << ", " << f << ", " << s << std::endl;
//        std::cout << std::tuple_size<t3>::value << std::cout;

    }

    return 0;
}


