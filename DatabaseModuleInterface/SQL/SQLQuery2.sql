select top 4 * from fc.FlashcardModelTbl f
join fc.GroupModelTbl g on g.Id = f.GroupDbModelId
where g.UserId = '466c7fca-ad58-4e9d-b88a-e3926386735f'
and f.CorreactAnsInRow is not null
order by f.NextPracticeDate

select * from fc.FlashcardModelTbl f
join fc.GroupModelTbl g on g.Id = f.GroupDbModelId
where g.UserId = '466c7fca-ad58-4e9d-b88a-e3926386735f'
and f.CorreactAnsInRow is not null
and f.NextPracticeDate <= GETDATE()

select * from fc.GroupModelTbl
select * from dbo.AspNetUsers


select * from fc.FlashcardModelTbl f
where f.GroupDbModelId = '1D917073-68EA-4E11-B4AE-816F30E33E72'
order by f.NextPracticeDate