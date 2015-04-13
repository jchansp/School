CREATE PROCEDURE GetRandomCountry
AS
SELECT Code
	,[Name]
FROM Countries
ORDER BY NEWID();
