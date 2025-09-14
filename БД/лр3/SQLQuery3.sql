use AM_MyBase
create table Покупатель(
ID_покупателя nvarchar(10) primary key,
Имя nvarchar(20) not null,
Фамилия nvarchar(30) not null,
Отчество nvarchar(30) not null,
Телефон int,
Город nvarchar(25),
Улица nvarchar(50),
Дом nvarchar(10))