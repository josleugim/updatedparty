use UpdatedPartyDB
go

INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
Values('Distrito Federal', 'DF', getdate())

select * from Tstates
select * from galleries
select * from Complains
Select * from Newsletters

--update StayUPs
--Set PromotionEvent = 'Dj set a partir de las 8:00 pm'
--where BarID = 20
--where StayUPID = 7

--update Bars
--Set BarName = 'El Trappist'
--where BarID = 14

--update Bars
--Set Email = 'imanolramirezmartinez76@gmail.com'
--where BarID = 12

--update Bars
--Set Township = 'Cuauhtémoc'
--where BarID = 6

--Delete from Bars
--Where BarID = 17

--Delete from StayUPs
--Where BarID = 22

select *
from bars
order by Email
where BarID = 4
Where Township = 'Alvaro Obregón'
OR Cologne = ''
AND(BarType = 1 OR [After] = 1)

Select *
from StayUPs
where EventDate = '2013-01-30 00:00:00.000'
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