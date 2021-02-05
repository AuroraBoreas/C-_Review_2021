#ifndef CAR_H_INCLUDED
#define CAR_H_INCLUDED

#include <string>
#include <sstream>
#include <iostream>

class Car
{
private:
    std::string PetName;
    int MaxSpeed;
    int CurrentSpeed;
public:
    Car()
    { PetName = ""; MaxSpeed=0; CurrentSpeed=0; }

    Car(const std::string& name, int maxSp, int curSp)
    : PetName(name), MaxSpeed(maxSp), CurrentSpeed(curSp){}

    virtual ~Car(){}

    // getter, setter
    std::string GetName(void) const { return PetName; }
    int GetMaxSpeed(void) const { return MaxSpeed; }
    int GetCurrentSpeed(void) const { return CurrentSpeed; }
    void SetName(const std::string& name) { PetName = name; }
    void SetMaxSpeed(int m) { MaxSpeed = m; }
    void SetCurrentSpeed(int c) { CurrentSpeed = c; }
    // repr
    std::string ToString(void) const
    {
        std::stringstream ss;
        ss << "Name: " << PetName << ", "
           << "MaxSpeed: " << MaxSpeed << ", "
           << "CurrentSpeed: " << CurrentSpeed;

        return ss.str();
    }

    virtual void Turboboost(void){}
};

class SportsCar: public Car
{
public:
    SportsCar(const std::string& name, int maxSp, int curSp)
    : Car(name, maxSp, curSp){}

    ~SportsCar(){}

    void Turboboost(void) override
    {
        std::cout << "fast is better" << std::endl;
    }
};

class MiniVan: public Car
{

public:

    MiniVan(const std::string& name, int maxSp, int curSp)
    : Car(name, maxSp, curSp){}

    ~MiniVan(){}
    void Turboboost(void) override
    {
        std::cout << "Car engine block exploded" << std::endl;
    }
};


#endif // CAR_H_INCLUDED
