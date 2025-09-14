select p1.SUBJECT,p1.note,
(select count(*) from PROGRESS p2
where p2.SUBJECT=p1.subject and p2.NOTE=p1.note)[total number]
from PROGRESS p1
group by p1.SUBJECT,p1.note
having p1.note >7 and p1.NOTE<10