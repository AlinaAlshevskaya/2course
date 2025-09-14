select IDSTUDENT,NOTE
from PROGRESS
where NOTE >=all (select Note from PROGRESS)