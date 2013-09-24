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
--Where BarID = 6

--Update Bars
--SET googlemaps = '<iframe width="580" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?daddr=19.41313295284835,-99.16460394859314&amp;ie=UTF8&amp;t=m&amp;source=embed&amp;ll=19.413133,-99.164615&amp;spn=0.014166,0.024891&amp;z=15&amp;output=embed"></iframe><br /><small><a href="https://maps.google.com/maps?daddr=19.41313295284835,-99.16460394859314&amp;ie=UTF8&amp;t=m&amp;source=embed&amp;ll=19.413133,-99.164615&amp;spn=0.014166,0.024891&amp;z=15" style="color: yellow;text-align:left">Ver mapa más grande</a></small>'
--Where BarID = 38

--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/beer-stop/4fc82c63e4b081b29e5f49bd'
--Where BarID = 5
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/diente-de-oro/4bef271ec80dc928d79427e3'
--Where BarID = 7
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/oslo-lounge/4c80689751ada1cdc6e20910'
--Where BarID = 20
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/4f17a14ae4b0259ede09a1f5'
--Where BarID = 29
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/la-santadiabla/4c2eb2f2ed37a593a0286603'
--Where BarID = 31
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/seahorse/50ae778ce4b05090c12294f8'
--Where BarID = 33
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/la-choper%C3%ADa/4c080b4e340720a1a9838293'
--Where BarID = 36
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/la-arrogante/4fa07689e4b0e93e336ebdbb'
--Where BarID = 37
--Update Bars
--SET FoursquareVenue = 'https://foursquare.com/v/am-local/4bb43ec2bd4b9c74c18032f5'
--Where BarID = 40
--Update Bars
--SET FoursquareVenue = 'https://es.foursquare.com/v/kaya/4c804a3c51ada1cd65b70810'
--Where BarID = 41
--Update Bars
--SET FoursquareVenue = 'https://es.foursquare.com/v/mr-keller/50f4c8b8e4b0720a59df74b5'
--Where BarID = 42
--Update Bars
--SET FoursquareVenue = 'https://es.foursquare.com/v/walther/4f3f3674e4b045d4ec0c184f'
--Where BarID = 43

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