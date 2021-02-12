"""

this module demonstrates how to solve 汪一诺 's questions

@ZL, 20210211

"""

class MaxDivider:
    def __init__(self, num: int=698, dig: int=8):
        self._num = num
        self._dig = dig

    def calc_result(self):
        print("\n{}/(){} : ".format(self._num, self._dig))
        for i in range(1, 10):
            n = self._dig + i * 10
            q = self._num // n
            print("{}/{} = {:2}, 商有{}位".format(self._num, n, q, len(str(q))))
        print()

def main():
    md = MaxDivider(798, 9)
    md.calc_result()


if __name__ == '__main__':
    main()
