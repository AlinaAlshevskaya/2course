Create View [���������� ������]
 as select p.FACULTY [name],Count(*)[����������]
 from PULPIT p inner join FACULTY f on p.FACULTY = f.FACULTY
 Group by p.FACULTY
select* from [���������� ������]