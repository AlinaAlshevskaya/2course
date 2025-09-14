select AUDITORIUM_TYPE.AUDITORIUM_TYPENAME,
max(Auditorium_capacity)[max cpacity],
min(Auditorium_capacity)[min capacity],
AVG(auditorium_capacity)[avg capacity],
sum(AUDITORIUM_CAPACITY)[sum capacity],
count(*)[total number]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM.AUDITORIUM_TYPE=AUDITORIUM_TYPE.AUDITORIUM_TYPE
group by AUDITORIUM_TYPENAME