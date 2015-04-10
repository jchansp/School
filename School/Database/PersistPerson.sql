CREATE PROCEDURE PersistPerson @Id UNIQUEIDENTIFIER
	,@Name VARCHAR(MAX)
	,@CountryId UNIQUEIDENTIFIER
AS
BEGIN
	IF EXISTS (
			SELECT *
			FROM People
			WHERE Id = @Id
			)
		UPDATE People
		SET [Name] = @Name
			,CountryId = @CountryId
		WHERE Id = @Id;
	ELSE
		INSERT INTO People (
			Id
			,[Name]
			,CountryId
			)
		VALUES (
			@Id
			,@Name
			,@CountryId
			);
END;
