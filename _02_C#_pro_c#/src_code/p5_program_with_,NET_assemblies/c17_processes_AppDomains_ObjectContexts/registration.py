"""

this module demonstrates how to utilise decorator in Python

@ZL, 20210210


"""
registration = set()

def register(active=True):
    def dec(func):
        def inner(*args, **kwargs):
            if active:
                registration.add(func)
            else:
                registration.remove(func)
            return func(*args, **kwargs)
        return inner
    return dec

@register(active=True)
def hello(name: str) -> str:
    return f"hello {name}"

@register()
def add(*args, **kwargs):
    for i in args:
        print(i, end=" ")
    print()
    for k, v in kwargs.items():
        print(k, v)

if __name__ == '__main__':
    greet: str = hello("XY")
    add(1,2,3, a=2.7, b=3.1)

    print(len(registration))
