"""

this module demonstrates how to solve 汪一诺 's questions

@ZL, 20210211

"""

class MaxDivider:
    def __init__(self, num: int=698, dig: int=8):
        self._num = num
        self._dig = dig

    def calc_result(self):
        print("\n{}/_{}: ".format(self._num, self._dig))
        for i in range(1, 10):
            n = self._dig + i * (10 ** len(str(self._dig)))
            q = self._num // n
            print("{}/{} = {:2}, 商有{}位".format(self._num, n, q, len(str(q))))
        print()

def main():
    md = MaxDivider(44213, 665)
    md.calc_result()

    # md = MaxDivider(698, 8, 2)
    # md.calc_result()

if __name__ == '__main__':
    main()
