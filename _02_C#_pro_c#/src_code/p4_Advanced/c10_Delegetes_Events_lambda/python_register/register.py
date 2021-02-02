"""

this module is to demonstrate decorator functionality to achieve similar effect like delegate in C#

@ZL, 20210201

"""

registry = set()    ## using sest for fast remove and add

def register(active=True):
    def inner(func):
        print("running register(active=%s) -> inner(%s)" %(active, func))
        if active:
            registry.add(func)
        else:
            registry.discard(func)
        return func
    return inner

@register(active=False)
def f1():
    return "running f1()"

@register()
def f2():
    print("running f2()")

def f3():
    print("running f3()")