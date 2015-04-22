﻿CREATE PROCEDURE RetrieveRandomCountry
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 Code
		,[Name]
	FROM Countries
	ORDER BY NEWID();
END;