"""

this module demonstrates concept of tuple in Python 

@ZL, 20210204

"""

from collections import namedtuple
import logging
logging.basicConfig(level=logging.DEBUG, format="%(asctime)s %(message)s")

def tuple_concept_demo():
    t1 = (3.14, 2.718, 42, "hello, world")
    t2 = tuple("hello world!")
    for item in t2:
        logging.debug(item)

    # __getitem__
    _, _, _, s = t1
    logging.debug("unbox and get last item: {}".format(s))

    # __setitem__
    # t1[0] = 42  # not OK

    # iterator
    for (no, item) in enumerate(t1):
        logging.debug("item{} is : {}".format(no, item))

    car = namedtuple("car", ("petname", "MaxSpeed", "CurrentSpeed"))
    person = namedtuple("person", ("name", "sex", "age"))
    record = namedtuple("record", ("person", "car"))

    c = car("TESLA", 100, 20)
    a = person("ZL", "male", 35)
    b = person("XY", "female", 35)
    # class behavior?
    logging.debug("name: {}, sex: {}, age: {}".format(a.name, a.sex, a.age))
    logging.debug("name: {}, sex: {}, age: {}".format(b.name, b.sex, b.age))
    # tuple behavior?
    logging.debug("name: {}, sex: {}, age: {}".format(*a))
    logging.debug("name: {}, sex: {}, age: {}".format(*b))

    # namedtuple in nametuple
    rec1 = record(a, c)
    rec2 = record(b, c)

    logging.debug("person info: {} {} {}, car info: {} {} {}".format(*rec1.person, *rec1.car))
    logging.debug("person info: {} {} {}, car info: {} {} {}".format(*rec2.person, *rec2.car))


if __name__ == '__main__':
    tuple_concept_demo()