drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
-- B ---
--TASK4
	begin transaction 
    delete from PULPIT_COPY where PULPIT = 'ТЛ'; 

--TASK5
	begin transaction
	delete from PULPIT_COPY where PULPIT = 'ТЛ'
	-------------------------- t1 ------------------
	rollback	-----
---------------------t2---------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'hhhhhhh' where PULPIT = 'ТЛ';
	commit


--TASK6
	------------------------t2---------------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'hhhhhh' where PULPIT = 'ТЛ';
	commit
	-------------t1----------------
	begin transaction 
    insert PULPIT_COPY values ('ТЛ', 'Транспорта леса', 'ТТЛП')
	commit
	--------------t1-------------

--TASK7
	begin transaction 
	insert PULPIT_COPY values ('ТЛ', 'Транспорта леса', 'ТТЛП')
	commit
	-------------t1----------------