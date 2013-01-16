use UpdatedPartyDB
go

INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
Values('Distrito Federal', 'DF', getdate())

select * from Tstates
select * from galleries
select * from Complains

update StayUPs
Set EventDate = '2013-14-01'
--where StayUPID = 7

--update Bars
--Set Township = 'Cuauhtémoc'
--where BarID = 6

select *
from bars
Where Township = 'Benito Juárez'
AND Cologne = 'Condesa'
AND(BarType = 1 OR [After] = 1)

Select *
from StayUPs
Select *
from UserTypes
Select *
from StatusTypes

select *
from Galleries

--drop table Complains
--drop table ComplainTypes
--drop table Galleries
--drop table StayUPs
--drop table bars
--drop table TStates
--drop table NewsLetters