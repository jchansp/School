CREATE PROCEDURE PersistPeopleTest
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
		,NEWID()
		,(
			SELECT TOP 1 Code
			FROM Countries
			ORDER BY NEWID()
			)
		);

	EXEC PersistPeople @Person;
END;
