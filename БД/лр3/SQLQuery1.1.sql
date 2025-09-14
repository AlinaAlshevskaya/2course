use master
create database MYBD

create table Products( 
Product_name nvarchar(30) primary key,
Cost real
)
Drop table Products
alter table products add discription nvarchar(50) 
insert into products (product_name, cost, discription)
 values ('vase',30,'blue'),
        ('glass', 5, 'one')
update products set cost = 35 where product_name='vase'
delete from products where cost= 35
select * from products
alter table products drop column discription
drop table products
drop database MYBD
