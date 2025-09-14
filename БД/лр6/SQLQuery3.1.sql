select *
from (
	select case when  оличество_заказанного_товара between 0 and 5 then 'малый заказ'
	when  оличество_заказанного_товара between 6 and 10 then 'неплохой заказ'
	else 'большой заказ'
	end [note_case],
	count(*)[count]
	from «аказано group by case
	when  оличество_заказанного_товара between 0 and 5 then 'малый заказ'
	when  оличество_заказанного_товара between 6 and 10 then 'неплохой заказ'
	else 'большой заказ'
	end
	) as T
	order by case [note_case]
	when 'малый заказ' then 3
	when 'неплохой заказ' then 2
	else 1
	end