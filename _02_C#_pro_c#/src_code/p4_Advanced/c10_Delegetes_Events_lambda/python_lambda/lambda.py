"""

this module demonstrates lambda expression in Python

@ZL, 20210202

"""


# normal function definition
# design pattern:

# def func_name(args, kwargs):
#     expression_body
#     return


def add(a, b, c):
    return a + b + c

# lambda expression
# design pattern:
# lambda args1, args2, ..., argN: expression_boy
f = lambda a, b, c: a + b + c


if __name__ == '__main__':
    a = 42; b = 66; c = 21
    assert add(a, b, c) == f(a, b, c), "u messed up"