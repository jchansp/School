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
				,CountryCode = Source.CountryCode
	WHEN NOT MATCHED
		THEN
			INSERT (
				Id
				,FirstName
				,CountryCode
				)
			VALUES (
				Source.Id
				,Source.FirstName
				,Source.CountryCode
				);
				--OUTPUT deleted.*
				--	,$ACTION
				--	,inserted.*
				--INTO #MyTempTable;
END;
