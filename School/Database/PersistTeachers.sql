CREATE PROCEDURE PersistTeachers @Teacher Teacher READONLY
AS
BEGIN
	SET NOCOUNT ON;

	MERGE Teachers AS Target
	USING @Teacher AS Source
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
