#include <iostream>

void message(char* s)
{ std::cout << s << std::endl; }

typedef void (*funcPtr)(char*);

int Add(int x, int y, funcPtr p)
{
    char s[] = "hello world";
    p(s);
    return x + y;
}

int main()
{
    char s[] = "hello";
    funcPtr p = message;
    p(s);

    int res = Add(3, 4, message);
    std::cout << res << std::endl;

    return 0;
}
