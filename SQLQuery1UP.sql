use UpdatedPartyDB
go

--INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
--Values('Distrito Federal', 'DF', getdate())
--INSERT INTO TStates (StateName, StateAbbreviation, RegisterDate)
--Values('Hidalgo', 'HGO', getdate())

select * from Tstates
select * from galleries
Where BarId = 11
And IsActived = 1
Select * from Newsletters
Select * from BusinessTypes

Select * from Bars
where BusinessTypeId in(1, 3)

--INSERT INTO BusinessTypes (TypeName)
--Values('Antro')
--INSERT INTO BusinessTypes (TypeName)
--Values('Bar')
--INSERT INTO BusinessTypes (TypeName)
--Values('After')
--INSERT INTO BusinessTypes (TypeName)
--Values('Restaurant Bar')
--INSERT INTO BusinessTypes (TypeName)
--Values('Pub')

--delete from Newsletters
--where NewsletterId = 1

--update StayUPs
--Set EventDate = '2013-25-06 00:00:00.000'
--where StayUPID = 6
--where BarID = 20

--update StayUPs
--Set PromotionEvent = 'Sin promoción'
--where StayUPID = 220

--update galleries
--Set UrlImage = '../../Content/gallery/PAR227BARGRILLCorte.JPG'
--where GalleryID = 19

--update Bars
--Set WebSite = ''
--where BarID = 16

--update Bars
--Set IsActived = 1
--where BarID = 26

--Delete from Galleries
--Where BarID = 17

--Delete from StayUPs
--Where StayUpID = 209

--Delete from Galleries
--Where GalleryID = 16

--Delete from Bars
--Where BarID = 22

--Update Bars
--SET googlemaps = '<iframe width="580" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com.mx/maps?f=q&amp;source=s_q&amp;hl=es&amp;geocode=&amp;q=bar+berlin+insurgentes+sur+df&amp;aq=&amp;sll=19.412733,-99.172731&amp;sspn=0.004301,0.006968&amp;t=h&amp;ie=UTF8&amp;hq=bar+berlin&amp;hnear=Insurgentes+Sur,+Ciudad+de+M%C3%A9xico,+Distrito+Federal&amp;ll=19.37658,-99.178219&amp;spn=0.007085,0.012445&amp;z=16&amp;output=embed"></iframe><br /><small><a href="https://maps.google.com.mx/maps?f=q&amp;source=embed&amp;hl=es&amp;geocode=&amp;q=bar+berlin+insurgentes+sur+df&amp;aq=&amp;sll=19.412733,-99.172731&amp;sspn=0.004301,0.006968&amp;t=h&amp;ie=UTF8&amp;hq=bar+berlin&amp;hnear=Insurgentes+Sur,+Ciudad+de+M%C3%A9xico,+Distrito+Federal&amp;ll=19.37658,-99.178219&amp;spn=0.007085,0.012445&amp;z=16" style="color: yellow;text-align:left">Ver mapa más grande</a></small>'
--Where BarID = 2

Select Distinct Township, Cologne from Bars

Select * from Bars
where BarID = 11
Where Township = 'Alvaro Obregón'
OR Cologne = ''
AND(BarType = 1 OR [After] = 1)

Select *
from StayUPs
where EventDate > '2013-07-07 00:00:00.000'

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