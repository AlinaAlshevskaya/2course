drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
-- B ---
--TASK4
	begin transaction 
    delete from PULPIT_COPY where PULPIT = '��'; 

--TASK5
	begin transaction
	delete from PULPIT_COPY where PULPIT = '��'
	-------------------------- t1 ------------------
	rollback	-----
---------------------t2---------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'hhhhhhh' where PULPIT = '��';
	commit


--TASK6
	------------------------t2---------------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'hhhhhh' where PULPIT = '��';
	commit
	-------------t1----------------
	begin transaction 
    insert PULPIT_COPY values ('��', '���������� ����', '����')
	commit
	--------------t1-------------

--TASK7
	begin transaction 
	insert PULPIT_COPY values ('��', '���������� ����', '����')
	commit
	-------------t1----------------