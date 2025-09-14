use AM_MyBase
create table Заказ(
Номер_заказа nvarchar(10) primary key,
Покупатель nvarchar(10) foreign key references Покупатель(ID_покупателя),
Дата_сделки date not null)
