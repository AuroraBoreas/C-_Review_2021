#ifndef POINT_H_INCLUDED
#define POINT_H_INCLUDED

#include <iostream>
#include <string>
#include <sstream>
class Point
{
private:
    int X;
    int Y;

public:
    // ctors
    Point(int x=0, int y=0)
    : X(x), Y(y){}
    // dstors
    ~Point(){}

    // getter, setter
    int GetX(void) const { return X; }
    int GetY(void) const { return Y; }
    void SetX(int x) { X = x; }
    void SetY(int y) { Y = y; }

    // repr
    friend std::ostream& operator<<(std::ostream& os, const Point& p)
    {
        os << "[" << p.X << ", " << p.Y << "]";
        return os;
    }

    // ... ad hoc
    std::string ToString() const
    {
        std::stringstream ss;
        ss << "[" << X << ", " << Y << "]";
        return ss.str();
    }

    // comparison, version 0
//    bool operator==(const Point& p) const
//    { return (X==p.X && Y==p.Y); }
//    bool operator!=(const Point& p) const
//    { return (X!=p.X && Y!=p.Y); }
//    bool operator<(const Point& p) const
//    { return (X<p.X && Y<p.Y); }
    // comparison, version 1
    bool Equals(const Point& p) const
    { return (this->ToString() == p.ToString()); }
    bool operator==(const Point& p) const
    { return (this->ToString() == p.ToString()); }
    bool operator!=(const Point& p) const
    { return (this->ToString() != p.ToString()); }
    bool operator<(const Point& p) const
    { return (this->ToString() < p.ToString()); }
    bool operator>(const Point& p) const
    { return (this->ToString() > p.ToString()); }
    // unary
    Point operator-() const
    {
        return Point(X * -1, Y * -1);
    }

};

#endif // POINT_H_INCLUDED
