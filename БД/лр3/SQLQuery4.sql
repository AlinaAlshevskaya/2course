use AM_MyBase
create table Заказано(
Номер_заказа nvarchar(10) foreign key references Заказ(Номер_заказа),
Товар nvarchar(10),
Количество_заказанного_товара int)