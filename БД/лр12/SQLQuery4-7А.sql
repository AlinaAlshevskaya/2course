drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT


-- A ---
--TASK4
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
    select count(*) from PULPIT_COPY where PULPIT = 'рк';
	--------------------t1----------------
	select count(*) from PULPIT_COPY where PULPIT = 'рк';
	--------------------t2-------------------
	commit

--TASK5
	set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from PULPIT_COPY where PULPIT = 'рк'
	--------------t1--------------
	select count(*) from PULPIT_COPY where PULPIT = 'рк'
	--------------t2-----------------
	commit

--TASK6
	set transaction isolation level REPEATABLE READ 
	begin transaction 
	select count(*) from PULPIT_COPY where PULPIT = 'рк'
	--------------t1--------------
	commit
	--------------t2-----------------
	select count(*) from PULPIT_COPY where PULPIT = 'рк'

	set transaction isolation level REPEATABLE READ 
	begin transaction 
	select count(*) from PULPIT_COPY where PULPIT = 'рк'
	--------------t1--------------
	select count(*) from PULPIT_COPY where PULPIT = 'рк'
	--------------t2-----------------
	commit


--TASK7
	set transaction isolation level SERIALIZABLE
	begin transaction 
	select count(*) from PULPIT_COPY where PULPIT = 'рк'
	--------------t1--------------
	commit
	--------------t2-----------------
	select count(*) from PULPIT_COPY where PULPIT = 'рк'