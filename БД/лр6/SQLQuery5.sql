select FACULTY.FACULTY_NAME,GROUPS.PROFESSION, groups.YEAR_FIRST,
round(avg(cast(progress.note as float(4))),2)[avg note] 
from FACULTY inner join GROUPS
on FACULTY.FACULTY =GROUPS.FACULTY
inner join STUDENT
on STUDENT.IDGROUP= GROUPS.IDGROUP
inner join PROGRESS
on student.IDSTUDENT=PROGRESS.IDSTUDENT
where progress.SUBJECT in('¡ƒ','Œ¿Ëœ')
group by FACULTY.FACULTY_NAME,GROUPS.PROFESSION, groups.YEAR_FIRST