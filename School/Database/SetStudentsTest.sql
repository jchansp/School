CREATE PROCEDURE SetStudentsTest
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Person Person;
	DECLARE @Student Student;

	INSERT @Person
	EXEC SetPeopleTest;

	INSERT @Student (PersonId)
	SELECT Id
	FROM @Person;

	EXEC SetStudents @Student;
END;
