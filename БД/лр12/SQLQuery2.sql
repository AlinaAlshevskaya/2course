drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
alter table PULPIT_COPY
add constraint PK_PULPIT_COPY primary key (PULPIT);

begin try
	begin tran
	delete PULPIT_COPY where FACULTY = 'ТОВ'
	insert PULPIT_COPY values ('ПИ', 'Програмная инженерия', 'ИТ')
	insert PULPIT_COPY values ('ПИ', 'Цифровой дизайн', 'ИТ')
	commit tran
	print 'ОК'
end try
	
begin catch
print 'Ошибка: ' + cast(error_number() as varchar(5)) + ' ' + cast(error_message() as varchar(5))

if @@TRANCOUNT > 0 rollback tran;
end catch
print cast(@@trancount as int)

select * from PULPIT_COPY