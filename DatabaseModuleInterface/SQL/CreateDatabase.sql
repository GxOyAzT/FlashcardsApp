create schema fc;
go

create table fc.GroupModelTbl (
	[Id] uniqueidentifier primary key not null,
	[Name] varchar(20) not null,
	[Description] varchar(max),
	[UserId] varchar(36) not null
);
go

create table fc.FlashcardModelTbl(
	[Id] uniqueidentifier not null,
	[NativeLanguage] varchar(100) not null,
	[ForeignLanguage] varchar(100) not null,
	[CorreactAnsInRow] int,
	[NextPracticeDate] date,
	[GroupDbModelId] uniqueidentifier foreign key references fc.GroupModelTbl([Id]) not null,
	[PracticeDirection] int not null,
	primary key ([Id], [PracticeDirection])
);
go