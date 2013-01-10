use UpdatedPartyDB
go

INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
Values('None', 'None', getdate())

select * from Tstates


update StayUPs
Set EventDate = '2013-08-01'
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