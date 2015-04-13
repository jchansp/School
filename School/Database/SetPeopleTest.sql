CREATE PROCEDURE SetPeopleTest
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Person Person;

	EXEC SetPeople @Person;
END;
