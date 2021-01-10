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
where f.GroupDbModelId = 'F34B0017-65E3-4F37-8D1B-4AB096F64046'
order by f.NextPracticeDate