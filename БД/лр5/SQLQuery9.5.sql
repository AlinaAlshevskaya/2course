select Номер_заказа 
from Заказ 
where not exists (
    select * 
    from Заказано z 
    full outer join Заказ o 
    on z.Номер_заказа = o.Номер_заказа
)
