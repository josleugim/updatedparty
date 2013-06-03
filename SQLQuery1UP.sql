use UpdatedPartyDB
go

INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
Values('Distrito Federal', 'DF', getdate())

select * from Tstates
select * from galleries
select * from Complains
Select * from Newsletters

--update StayUPs
--Set EventDate = '2013-25-05 00:00:00.000'
--where BarID = 20
--where StayUPID = 7

--update StayUPs
--Set PromotionEvent = 'Sin promoción'
--where StayUPID = 220

--update galleries
--Set IsActived = 1
--where BarID = 14

--update Bars
--Set Email = 'imanolramirezmartinez76@gmail.com'
--where BarID = 12

Select * from Bars
where BarID > 32

--update Bars
--Set Twitter = 'https://twitter.com/La_SantaDiabla'
--where BarID = 40

--Delete from Galleries
--Where BarID = 17

--Delete from StayUPs
--Where StayUpID = 209

--Delete from Galleries
--Where GalleryID = 32

--Update Bars
--SET googlemaps = '<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com.mx/maps/ms?msa=0&amp;msid=211842175062061943958.0004dd2c6e071e0b01d99&amp;ie=UTF8&amp;t=h&amp;z=17&amp;output=embed"></iframe><br /><small>Ver <a href="https://maps.google.com.mx/maps/ms?msa=0&amp;msid=211842175062061943958.0004dd2c6e071e0b01d99&amp;ie=UTF8&amp;t=h&amp;z=17&amp;source=embed" style="color:#0000FF;text-align:left">NUN Condesa</a> en un mapa ampliado</small>'
--Where BarID = 11

Select Distinct Township, Cologne from Bars

Select * from Bars
where BarID = 11
Where Township = 'Alvaro Obregón'
OR Cologne = ''
AND(BarType = 1 OR [After] = 1)

Select *
from StayUPs
where EventDate = '2013-23-05 00:00:00.000'

select *
from Galleries
where BarId = 30

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