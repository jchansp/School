﻿CREATE TYPE Country AS TABLE
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] VARCHAR(255) NOT NULL UNIQUE
);