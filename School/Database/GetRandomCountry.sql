﻿CREATE PROCEDURE GetRandomCountry
AS
SELECT Id
	,[Name]
FROM Countries
ORDER BY NEWID();
