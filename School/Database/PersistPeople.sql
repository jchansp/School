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
			SET FirstName = Source.FirstName
				,CountryId = Source.CountryId
	WHEN NOT MATCHED
		THEN
			INSERT (
				Id
				,FirstName
				,CountryId
				)
			VALUES (
				Source.Id
				,Source.FirstName
				,Source.CountryId
				);
				--OUTPUT deleted.*
				--	,$ACTION
				--	,inserted.*
				--INTO #MyTempTable;
END;
