"""

a simple module demonstrates callback mechanism in Python

@ZL, 20210201

"""


def Add(a, b):
    return a + b

def Mul(a, b):
    return a * b

def Caller(func, base, seq):
    for i in seq:
        base = func(base, i)
    return base

if __name__ == '__main__':
    res = Caller(Add, 0, [1, 2, 3, 4])
    print(res)
    res = Caller(Mul, 1, [1, 2, 3, 4])
    print(res)