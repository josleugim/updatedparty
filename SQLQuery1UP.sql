use UpdatedPartyDB
go

INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
Values('Distrito Federal', 'DF', getdate())

select * from Tstates
select * from galleries
select * from Complains
Select * from Newsletters

--update StayUPs
--Set EventDate = '2013-12-02 00:00:00.000'
--where BarID = 20
--where StayUPID = 7

--update galleries
--Set IsActived = 1
--where BarID = 14

--update Bars
--Set Email = 'imanolramirezmartinez76@gmail.com'
--where BarID = 12

--update Bars
--Set BarName = 'CatWalk'
--where BarID = 33

--Delete from Galleries
--Where BarID = 17

--Delete from Galleries
--Where GalleryID = 32

select *
from bars
where BarID =33
Where Township = 'Alvaro Obregón'
OR Cologne = ''
AND(BarType = 1 OR [After] = 1)

Select *
from StayUPs
where EventDate = '2013-02-24 00:00:00.000'
Select *
from UserTypes
Select *
from StatusTypes

select *
from Galleries
where GalleryID = 30

--Update Galleries
--Set UrlImage = '../../Content/gallery/logo.jpg'
--where GalleryID = 30

--drop table Complains
--drop table ComplainTypes
--drop table Galleries
--drop table StayUPs
--drop table bars
--drop table TStates
--drop table NewsLetters