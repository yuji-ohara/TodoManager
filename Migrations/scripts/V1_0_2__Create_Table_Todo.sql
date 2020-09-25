create table [tm].[Todos] (
	Id INT PRIMARY KEY IDENTITY,
	ParentId INT NULL,
	Title VARCHAR(100) NOT NULL,
	ExtendedDescription VARCHAR(MAX) NULL,
	DueDate DATETIME NULL,
	Done BIT NOT NULL,
	FOREIGN KEY (ParentId) REFERENCES [tm].[Todos](Id)
)