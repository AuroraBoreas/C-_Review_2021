#include <iostream>
#include <cstdlib>
#include <stdexcept>

void message(char*), error_message(char*),
     message_up(char*), message_low(char*);

typedef void (*funcPtr)(char*);

int main()
{
    funcPtr register_[] = { message, error_message, message_up, message_low };

    char msg[] = "Hello World!";
    for(auto r : register_)
        r(msg);


    return 0;
}

void message(char* s)
{
    std::cout << s << std::endl;
}

void error_message(char* s)
{
    std::cerr << s << std::endl;
}

void message_up(char* s)
{
    char c;
    for(; *s != '\0'; ++s)
    { c = std::toupper(*s); std::cout.put(c); }
    std::cout << std::endl;
}

void message_low(char* s)
{
    char c;
    for(; *s != '\0'; ++s)
    { c = std::tolower(*s); std::cout.put(c); }
    std::cout << std::endl;
}
