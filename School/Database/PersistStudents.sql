CREATE PROCEDURE PersistStudents @Student Student READONLY
AS
BEGIN
	SET NOCOUNT ON;

	MERGE Students AS Target
	USING @Student AS Source
		ON (Target.PersonId = Source.PersonId)
			--WHEN MATCHED
			--	THEN
			--		UPDATE
			--		SET FirstName = Source.FirstName
			--			,CountryCode = Source.CountryCode
	WHEN NOT MATCHED
		THEN
			INSERT (PersonId)
			VALUES (Source.PersonId);
				--OUTPUT deleted.*
				--	,$ACTION
				--	,inserted.*
				--INTO #MyTempTable;
END;
