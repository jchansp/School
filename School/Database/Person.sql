﻿CREATE TYPE Person AS TABLE (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
	,FirstName VARCHAR(MAX) NOT NULL
	,CountryId UNIQUEIDENTIFIER NOT NULL
	);
