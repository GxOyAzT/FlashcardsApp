use _FlashcardsAppTests
go

select * from fc.GroupModelTbl
select * from fc.FlashcardModelTbl

Select * from fc.GroupModelTbl gm 
left join fc.FlashcardModelTbl fm on gm.Id = fm.GroupDbModelId