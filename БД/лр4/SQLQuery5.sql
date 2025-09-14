select * from товары t full outer join Заказано z
on z.Товар=t.Артикул
order by t.Наименование_товара


select count(*) from товары t Full outer join заказано z
on z.Товар=t.Артикул
where Артикул is null