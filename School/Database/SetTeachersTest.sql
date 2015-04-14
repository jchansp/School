CREATE PROCEDURE SetTeachersTest
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Person Person;
	DECLARE @Teacher Teacher;

	INSERT @Person
	EXEC SetPeopleTest;

	INSERT @Teacher (PersonId)
	SELECT Id
	FROM @Person;

	EXEC SetTeachers @Teacher;
END;
