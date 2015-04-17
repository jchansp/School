CREATE PROCEDURE PersistStudentsTest
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Person Person;
	DECLARE @Student Student;

	INSERT @Person
	EXEC PersistPeopleTest;

	INSERT @Student (PersonId)
	SELECT Id
	FROM @Person;

	EXEC PersistStudents @Student;
END;
