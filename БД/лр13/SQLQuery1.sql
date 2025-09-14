drop procedure PSUBJECT
go
create procedure PSUBJECT
as begin
	declare @amount int = (select count(*) from SUBJECT)
	select SUBJECT [код],
	SUBJECT_NAME [дисциплина],
	PULPIT [кафедра] from SUBJECT
	return @amount
end;

declare @output int = 0
exec @output = PSUBJECT
print 'количество строк=' + cast(@output as varchar(5))