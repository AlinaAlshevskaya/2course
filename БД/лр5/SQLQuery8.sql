select IDSTUDENT,NOTE
from PROGRESS
where NOTE <any (select avg(NOTE) from PROGRESS)