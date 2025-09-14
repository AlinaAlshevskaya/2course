Create View [Количество кафедр]
 as select p.FACULTY [name],Count(*)[количество]
 from PULPIT p inner join FACULTY f on p.FACULTY = f.FACULTY
 Group by p.FACULTY
select* from [Количество кафедр]