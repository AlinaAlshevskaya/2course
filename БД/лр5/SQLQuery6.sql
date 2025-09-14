select top 1
(select avg(NOTE) from PROGRESS where SUBJECT like 'нюХо')[нюХо],
(select avg(NOTE) from PROGRESS where SUBJECT like 'ясад')[яСад],
(select avg(NOTE) from PROGRESS where SUBJECT like 'ад')[ад]
from PROGRESS