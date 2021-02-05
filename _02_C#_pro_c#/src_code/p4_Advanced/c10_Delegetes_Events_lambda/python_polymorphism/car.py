"""

This module demonstrates class Car

@ZL, 20210205

"""

import logging
logging.basicConfig(level=logging.DEBUG, format="%(module)s %(asctime)s %(message)s")

class Car:
    def __init__(self, name: str, maxSp: int, curSp: int):
        self._pet_name = name
        self._max_speed = maxSp
        self._current_speed = curSp

    def __repr__(self):
        return f"Name: {self._pet_name}, max_speed: {self._max_speed}, current_speed: {self._current_speed}"

    def get_name(self): return self._pet_name
    def get_max_speed(self): return self._max_speed
    def get_current_speed(self): return self._current_speed

    def set_name(self, name: str): self._pet_name = name
    def set_max_speed(self, maxSp: int): self._max_speed = maxSp
    def set_current_speed(self, curSp: int): self._current_speed = curSp

    def turbo_boost(self): pass

class SportsCar(Car):
    def __init__(self, name: str, maxSp: int, curSp: int):
        super().__init__(name, maxSp, curSp)

    def turbo_boost(self):
        print("Fast is better!")

class MiniVan(Car):
    def __init__(self, name: str, maxSp: int, curSp: int):
        super().__init__(name, maxSp, curSp)

    def turbo_boost(self):
        print("Engine block is exploding!")

if __name__ == '__main__':
    cars = [
        Car("ZL", 200, 20),
        SportsCar("XY", 100, 15),
        MiniVan("LL", 100, 20),
        SportsCar("DD", 200, 40),
    ]

    for c in cars:
        logging.debug("type: {0}, info: {1}".format(type(c), c))
        c.turbo_boost()
        c.__class__ = Car # upcasting
        logging.debug("type: {0}, info: {1}".format(type(c), c))
        c.turbo_boost()
        print()
