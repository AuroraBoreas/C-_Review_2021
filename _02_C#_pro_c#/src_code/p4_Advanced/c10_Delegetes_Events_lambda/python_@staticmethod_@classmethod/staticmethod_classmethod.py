"""

this module demonstrates difference btwn @staticmethod and @classmethod in Python

@ZL, 20210208

"""

import logging
logging.basicConfig(level=logging.DEBUG, format="%(asctime)s %(message)s")

class A:
    def __init__(self, a, b):
        self.a = a; self.b = b
    def __add__(self, other):
        return A(self.a + other.a, self.b + other.b)

    @staticmethod
    def hello():
        print("staticmethod hello")
        return "staticmethod hello"

    @classmethod
    def world(cls):
        print("classmethod world")
        return "classmethod world"


if __name__ == '__main__':
    a1 = A(2, 3)
    b1 = A(4, 5)
    # staticmethod?
    logging.debug("a1 obj, static method hello(): {}".format(a1.hello()))
    logging.debug("b1 obj, static method hello(): {}".format(b1.hello()))
    # classmethod?
    logging.debug("a1 obj, static method hello(): {}".format(a1.world()))
    logging.debug("b1 obj, static method hello(): {}".format(b1.world()))
    # they are pretty close to each other
    A.world()
    A.hello()

