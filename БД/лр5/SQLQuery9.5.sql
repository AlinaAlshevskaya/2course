select �����_������ 
from ����� 
where not exists (
    select * 
    from �������� z 
    full outer join ����� o 
    on z.�����_������ = o.�����_������
)
