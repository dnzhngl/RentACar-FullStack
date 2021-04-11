DECLARE @__returnDate_0 datetime2 = '2021-04-16T00:00:00.0000000';
DECLARE @__rentDate_1 datetime2 = '2021-04-10T00:00:00.0000000';


-- Girilen tarihler de müsait olmayan arabaları ve rentalları döner.
SELECT * FROM Cars AS c
left JOIN Rentals AS r ON c.Id = r.CarId
WHERE (r.ReturnDate is null and @endDate >= r.RentDate) or (r.RentDate <= @endDate) and (@startDate <= r.ReturnDate)

-- Girilen tarihlerde müsait olan arabaları döner. // ReturnDate null girilirse tüm arabaları döner :/
Select  c.Id, c.Capacity, c.Model, c.ModelYear, c.DailyPrice, c.Description, c.IsAvailable, c.BrandId, c.CarTypeId, c.ColorId 
from Cars c
where c.Id not in (SELECT c.Id FROM Cars AS c
left JOIN Rentals AS r ON c.Id = r.CarId
WHERE (r.ReturnDate is null and @endDate >= r.RentDate) or (r.RentDate <= @endDate) and (@startDate <= r.ReturnDate))


------------------------
-- endDate null olması durumunu kontrol eder, ona göre if else içini çalıştırır. Mü
DECLARE @startDate datetime2 = '2021-04-15T00:00:00.0000000';
DECLARE @endDate datetime2 = '2021-04-17T00:00:00.0000000';
--DECLARE @endDate datetime2 = null;


if(@endDate is null)(
-- Girilen tarihlerde EndDate null ise ona göre müsait olmatan arabaları döner
	SELECT * FROM Cars
	where Cars.Id not in(
		Select c.Id From Cars as c
		inner join Rentals as r on c.Id = r.CarId
		WHERE (r.ReturnDate is null or  r.ReturnDate >= @startDate)
	)
)
else(
-- Girilen tarihler de müsait olmayan arabaları ve rentalları döner.
	SELECT * FROM Cars 
	where Cars.Id not in (
		SELECT c.Id FROM Cars AS c
		left JOIN Rentals AS r ON c.Id = r.CarId
		WHERE (r.ReturnDate is null and r.RentDate <= @endDate) or ((r.RentDate <= @endDate) and (@startDate <= r.ReturnDate)))
)