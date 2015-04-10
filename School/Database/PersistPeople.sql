CREATE PROCEDURE PersistPeople @Person Person READONLY
AS
BEGIN
	SET NOCOUNT ON;

	MERGE People AS Target
	USING @Person AS Source
		ON (Target.Id = Source.Id)
	WHEN MATCHED
		THEN
			UPDATE
			SET [Name] = Source.[Name]
				,CountryId = Source.CountryId
	WHEN NOT MATCHED
		THEN
			INSERT (
				Id
				,[Name]
				,CountryId
				)
			VALUES (
				Source.Id
				,Source.[Name]
				,Source.CountryId
				);
				--OUTPUT deleted.*
				--	,$ACTION
				--	,inserted.*
				--INTO #MyTempTable;
END;
