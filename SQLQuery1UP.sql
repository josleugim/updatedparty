use UpdatedPartyDB
go

--INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
--Values('Distrito Federal', 'DF', getdate())
--INSERT INTO UserTypes (UserTypeName, RegisterDate)
--Values('Bar', getdate())

select * from Tstates
select * from galleries
Select * from UserTypes

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
--drop table SocialMedias
--drop table StayUPs
--drop table bars
--drop table StatusTypes
--drop table TStates
--drop table UserTypes