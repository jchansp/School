﻿CREATE TABLE People (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
	,FirstName VARCHAR(MAX) NOT NULL
	,CountryId UNIQUEIDENTIFIER NOT NULL REFERENCES Countries(Id)
	);
