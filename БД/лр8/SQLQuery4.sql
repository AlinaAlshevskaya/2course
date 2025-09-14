create view Audotorii (id, name,type)
as select a.AUDITORIUM, a.AUDITORIUM_NAME,a.AUDITORIUM_TYPE
from AUDITORIUM a
where a.AUDITORIUM_TYPE like 'лк%' with check option;
go
select * from Audotorii

 insert Audotorii values ('200-1','200-1','лк')