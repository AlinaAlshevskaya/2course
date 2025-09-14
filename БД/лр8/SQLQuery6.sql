alter view [Количество кафедр] with schemabinding
as select p.FACULTY ,Count(*)[количество]
 from dbo.PULPIT p inner join dbo.FACULTY f on p.FACULTY = f.FACULTY
 Group by p.FACULTY
 select * from [Количество кафедр]
 alter table PULPIT drop column FACULTY