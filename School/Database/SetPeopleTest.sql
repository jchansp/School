CREATE PROCEDURE SetPeopleTest
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Person Person;

	INSERT @Person (
		Id
		,FirstName
		,CountryCode
		)
	VALUES (
		NEWID()
		,(
			SELECT TOP 1 FirstName
			FROM People
			ORDER BY NEWID()
			)
		,(
			SELECT TOP 1 Code
			FROM Countries
			ORDER BY NEWID()
			)
		);

	EXEC SetPeople @Person;
END;
