"""

this module demonstrates how to solve 汪一诺 's questions

@ZL, 20210211

"""

被除数 = 698
除数   = "{}8"

res = []
for i in range(1, 10):
    n = 除数.format(i)
    q = 被除数 // int(n)
    res.append(q)
    print("{}/{} = {}, 商有{}位".format(被除数, n, q, len(str(q))))
