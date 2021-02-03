"""

this module demonstrates opol in Python

@ZL, 20210202

"""
import logging
logging.basicConfig(level=logging.DEBUG, format="%(asctime)s %(message)s")

class Point:
    def __init__(self, x: int = 0, y: int = 0):
        self._x = x
        self._y = y

    def GetX(self):
        return self._x
    def GetY(self):
        return self._y
    def SetX(self, x: int):
        self._x = x
    def SetY(self, y: int):
        self._y = y

    def __repr__(self):
        return f"[{self._x}, {self._y}]"

    def __eq__(self, other):
        return (self.__repr__() == other.__repr__())
    def __gt__(self, other):
        return (self.__repr__() > other.__repr__())

    def __add__(self, other):
        return Point(self._x + other._x, self._y + other._y)
    def __sub__(self, other):
        return Point(self._x - other._x, self._y - other._y)
    def __mul__(self, multiplier: int):
        return Point(self._x * multiplier, self._y * multiplier)
    def __abs__(self):
        return Point(abs(self._x), abs(self._y))

if __name__ == '__main__':
    p1 = Point()
    p2 = Point(3, 2)
    logging.debug("p1 = {}".format(p1))
    logging.debug("p2 = {}".format(p2))
    logging.debug("p1 == p2     : {}".format(p1 == p2))
    logging.debug("p1 < p2      : {}".format(p1 < p2))
    logging.debug("p1 + p2      : {}".format(p1 + p2))
    logging.debug("p1 - p2      : {}".format(p1 - p2))
    logging.debug("p2 * -3      : {}".format(p2 * -3))
    logging.debug("abs(p2 * -3) : {}".format(abs(p2 * -3)))
