#ifndef POINTCOLLECTION_H_INCLUDED
#define POINTCOLLECTION_H_INCLUDED

#include <stdexcept>

class PointCollection
{
private:
    int m_Max;
    Point* PointsCollectionPtr;
public:
    PointCollection(int max=100)
    : m_Max(max)
    { PointsCollectionPtr = new Point[m_Max]; }

    ~PointCollection() { delete PointsCollectionPtr; }

    Point& operator[](int index)
    {
        if(index < m_Max && index >= 0)
            return PointsCollectionPtr[index];
        else
            throw std::out_of_range("index out of range!");
    }

    const Point& operator[](int index) const
    {
        if(index < m_Max && index >= 0)
            return PointsCollectionPtr[index];
        else
            throw std::out_of_range("index out of range!");
    }



};

#endif // POINTCOLLECTION_H_INCLUDED
