select *
from (
	select case when ����������_�����������_������ between 0 and 5 then '����� �����'
	when ����������_�����������_������ between 6 and 10 then '�������� �����'
	else '������� �����'
	end [note_case],
	count(*)[count]
	from �������� group by case
	when ����������_�����������_������ between 0 and 5 then '����� �����'
	when ����������_�����������_������ between 6 and 10 then '�������� �����'
	else '������� �����'
	end
	) as T
	order by case [note_case]
	when '����� �����' then 3
	when '�������� �����' then 2
	else 1
	end