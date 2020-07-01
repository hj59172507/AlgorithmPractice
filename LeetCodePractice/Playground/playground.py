def multiple35():
    m = []
    for i in range(1, 201):
        if i % 3 == 0 or i % 5 == 0:
            m.append(i)
        print(m)
        print(len(m))


from datetime import datetime

s = '2020/6/29'

from datetime import datetime, timedelta

datetime_object = datetime.strptime(s, '%Y/%m/%d')
print(datetime_object.weekday())
print(datetime_object + timedelta(days=1))

