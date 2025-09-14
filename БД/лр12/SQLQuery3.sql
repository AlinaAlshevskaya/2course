drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
alter table PULPIT_COPY
add constraint PK_PULPIT_COPY primary key (PULPIT);

declare @point varchar(32)

begin try
	begin tran
	delete PULPIT_COPY where FACULTY = 'ТОВ'
	set @point = 'p1'; save tran @point
	insert PULPIT_COPY values ('ПИ', 'Программная инженерия', 'ИТ')
	set @point = 'p2'; save tran @point
	insert PULPIT_COPY values ('ПИ', 'Цифровой дизайн', 'ИТ')
	set @point = 'p3'; save tran @point
	commit tran
	print 'ОК'
end try
	
begin catch
print 'Ошибка: ' + cast(error_number() as varchar(5)) + ' ' + cast(error_message() as varchar(5))

if @@TRANCOUNT > 0
	begin
		print 'Контрольная точка: ' + @point 
		rollback tran @point;
		commit tran
	end;
end catch

select * from PULPIT_COPY