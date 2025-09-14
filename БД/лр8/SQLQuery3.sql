create view [Аудитории](id, name,type)
as select a.AUDITORIUM, a.AUDITORIUM_NAME,a.AUDITORIUM_TYPE
from AUDITORIUM a
where a.AUDITORIUM_TYPE like 'лк%'
select * from [Аудитории]
select* from AUDITORIUM

 insert [Аудитории] values ('100-1','100-1','лк')