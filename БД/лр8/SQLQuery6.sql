alter view [���������� ������] with schemabinding
as select p.FACULTY ,Count(*)[����������]
 from dbo.PULPIT p inner join dbo.FACULTY f on p.FACULTY = f.FACULTY
 Group by p.FACULTY
 select * from [���������� ������]
 alter table PULPIT drop column FACULTY