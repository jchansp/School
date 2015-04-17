CREATE PROCEDURE PersistTeachersTest
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Person Person;
	DECLARE @Teacher Teacher;

	INSERT @Person
	EXEC PersistPeopleTest;

	INSERT @Teacher (PersonId)
	SELECT Id
	FROM @Person;

	EXEC PersistTeachers @Teacher;
END;
