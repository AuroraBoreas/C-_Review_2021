"""

there is no such concept "delegate" in Python;
but Python can achieve similar effect using decorator.

this module demonstrates how to implement it.

@ZL, 20210209

"""


def percent_difference(x, y, diff=0.2)->bool:
    return abs(x - y) / abs(y) <= diff

class A:
    registration = list() # <-- using set container to hold "delegate" functions, because it has fast add/remove feature O(1)
    _engineDead = False

    def __init__(self, pet_name: str, color: str, current_speed: int, max_speed: int):
        self.pet_name = pet_name
        self.color = color
        self.current_speed = current_speed
        self.max_speed = max_speed

    def __repr__(self):
        return f"name: {self.pet_name}, color: {self.color}, current_speed: {self.current_speed}, max_speed: {self.max_speed}"

    def registration_handler(self, func_name)->None:
        self.registration.append(func_name)

    def unregistration_handler(self, func_name)->None:
        self.registration.remove(func_name)

    # define our decorator
    @classmethod
    def register(cls, active=True):
        def inner(func):
            if active:
                cls.registration.add(func)
            else:
                cls.registration.remove(func)
            return func()
        return inner

    def accelerate(self, delta: int):
        if len(self.registration) < 1:
            raise IndexError("registration list is empty")
        else:
            self.current_speed += delta
            if self._engineDead:
                self.registration[0]("Car engine is exploding..")
            else:
                if not percent_difference(self.current_speed, self.max_speed):
                    self.registration[0]("faster is better, current_speed is {0}".format(self.current_speed))
                elif percent_difference(self.current_speed, self.max_speed) and (self.current_speed <= self.max_speed):
                    self.registration[0]("be careful, buddy.., current speed is {0}".format(self.current_speed))
                else:
                    self._engineDead = True
                    self.registration[0]("Car engine is exploding..")

def func1(s: str):
    print(f"info: {s}")

def func2():
    a = 1; b = 2
    print(f"{a} + {b} = {a + b}")

if __name__ == '__main__':
    a1 = A("XY", "Pink", 20, 120)
    print(a1)
    # functions
    a1.registration_handler(func1)
    i = 1
    while (i < 10):
        a1.accelerate(20)
        i += 1
    # a1.unregistration_handler(func1)
    # i = 1
    # while (i < 10):
    #     a1.accelerate(20)
    #     i += 1


