#include <iostream>
#include <list>
#include "car.h"

using namespace std;

int main()
{
    // test class Car
    {
//        std::list<Car> myCars[] = {
//            SportsCar("ZL", 200, 10),
//            MiniVan("XY", 100, 20),
//            MiniVan("LL", 100, 30),
//            SportsCar("DD", 100, 15),
//        };

        Car myCars[] = {
            SportsCar("ZL", 200, 10),
            MiniVan("XY", 100, 20),
            MiniVan("LL", 100, 30),
            SportsCar("DD", 100, 15),
        };


        for(int i=0; i<4; ++i)
            std::cout << myCars[i].ToString() << std::endl;

        std::cout << std::endl;

    }

    return 0;
}
