create database FlashcardsApp

use FlashcardsApp
go

create schema fc;
go

drop table fc.FlashcardModelTbl;
go

drop table fc.GroupModelTbl;
go

drop table fc.UserModelTbl;
go

create table fc.UserModelTbl(
	[Id] uniqueidentifier primary key not null,
	[Nick] varchar(20) not null,
	[Email] varchar(50) not null,
	[Password] varchar(30) not null,
	[IsAccountConfirmed] bit not null
)
go

create table fc.GroupModelTbl (
	[Id] uniqueidentifier primary key not null,
	[Name] varchar(20) not null,
	[Description] varchar(max),
	[UserDbModelId] uniqueidentifier foreign key references fc.UserModelTbl([Id]) not null
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

select * from fc.UserModelTbl
select * from fc.GroupModelTbl
select * from fc.FlashcardModelTbl

Select * from fc.UserModelTbl um
left join fc.GroupModelTbl gm on um.Id = gm.UserDbModelId
left join fc.FlashcardModelTbl fm on gm.Id = fm.GroupDbModelId