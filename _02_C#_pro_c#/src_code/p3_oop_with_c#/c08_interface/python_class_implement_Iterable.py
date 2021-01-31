"""

compared with C#, user-defined class type that supports INumerable/INumerator interfaces;
Python has four ways to implement iterable;
    - create a generator using yield kw;
    - utilize a gnerator expression, using generator-expression;
    - create an iterator (defines __iter__ and __next__)
    - create a class that Python can iterate over on its own(defines __getitem__)


link: https://stackoverflow.com/questions/19151/build-a-basic-python-iterator

example as follows

"""

def uc_gen(text):
    # using generator
    for char in text.upper():
        yield char

def uc_gen_expr(text):
    # using gen-expr
    return (char for char in text.upper())

class uc_iter:
    def __init__(self, text):
        self.text = text.upper()
        self.index = 0
    
    def __iter__(self):
        return self
    
    def __next__(self):
        try:
            result = self.text[self.index]
        except IndexError:
            raise StopIteration
        self.index += 1
        return result

class uc_getitem:
    def __init__(self, text):
        self.text = text.upper()
    def __getitem__(self, index):
        return self.text[index]

if __name__ == '__main__':
    text = "ABCD"
    for it in uc_gen, uc_gen_expr, uc_iter, uc_getitem:
        for ch in it(text):
            print(ch, end=" - ")
        print()