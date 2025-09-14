select faculty.FACULTY,groups.PROFESSION,PROGRESS.SUBJECT,
avg(progress.note)[avg note]
from STUDENT left outer join PROGRESS  
on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
inner join GROUPS 
on STUDENT.IDGROUP = GROUPS.IDGROUP
inner join FACULTY 
on GROUPS.FACULTY= FACULTY.FACULTY
where faculty.FACULTY='ÒÎÂ'
group by rollup( faculty.FACULTY,groups.PROFESSION,PROGRESS.SUBJECT)