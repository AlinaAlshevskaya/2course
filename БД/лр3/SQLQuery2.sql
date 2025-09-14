use AM_MyBase;
Create table Товары(
Артикул nvarchar(10) primary key,
Наименование_товара nvarchar(50) not null,
Цена real not null,
Количество_на_складе int,
Описание_товара nvarchar(50))
