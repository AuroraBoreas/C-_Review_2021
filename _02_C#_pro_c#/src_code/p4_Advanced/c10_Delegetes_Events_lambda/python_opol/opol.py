"""

this module demonstrates opol in Python

@ZL, 20210202

"""
import logging
logging.basicConfig(level=logging.DEBUG, format="%(asctime)s %(message)s")

class Point:
    # ctor
    def __init__(self, x: int = 0, y: int = 0):
        self._x = x
        self._y = y
    # getter, setter
    def GetX(self):
        return self._x
    def GetY(self):
        return self._y
    def SetX(self, x: int):
        self._x = x
    def SetY(self, y: int):
        self._y = y
    # override repr op
    def __repr__(self):
        return f"[{self._x}, {self._y}]"
    # override relational ops
    def __eq__(self, other):
        return (self.__repr__() == other.__repr__())
    def __gt__(self, other):
        return (self.__repr__() > other.__repr__())
    # override arithmetic ops
    def __add__(self, other):
        return Point(self._x + other._x, self._y + other._y)
    def __sub__(self, other):
        return Point(self._x - other._x, self._y - other._y)
    def __mul__(self, multiplier: int):
        return Point(self._x * multiplier, self._y * multiplier)
    def __abs__(self):
        return Point(abs(self._x), abs(self._y))

class PointCollection:
    def __init__(self, seq: list):
        self._seq = seq
    def __getitem__(self, index: int):
        try:
            return self._seq[index]
        except IndexError:
            raise IndexError("IndexError: {} out of range".format(index))
    def __setitem__(self, index: int, value: int):
        try:
            self._seq[index] = value
        except IndexError:
            raise IndexError("IndexError, {} out of range".format(index))
    def __delitem__(self, index: int):
        try:
            del self._seq[index]
        except IndexError:
            raise IndexError("IndexError, {} out of range".format(index))
    def __len__(self):
        return len(self._seq)

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

    # test PointCollections
    pc = PointCollection([p1, p2, Point(), Point(12, 42), Point(8, 22)])

    for p in pc:    # <-- iterate over pc;
        logging.debug(p)

    logging.debug("first item is : {}".format(pc[0]))
    logging.debug("before change 2nd item, it is : {}".format(pc[1]))
    pc[1] = Point(3, 5)
    logging.debug("after change 2nd item, it is  : {}".format(pc[1]))
    logging.debug("length before delete 2nd item : {}".format(len(pc)))
    del pc[1]
    logging.debug("length after delete 2nd item : {}".format(len(pc)))
