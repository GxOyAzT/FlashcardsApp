select top 4 * from fc.FlashcardModelTbl f
join fc.GroupModelTbl g on g.Id = f.GroupDbModelId
where g.UserId = '466c7fca-ad58-4e9d-b88a-e3926386735f'
and f.CorreactAnsInRow is not null
order by f.NextPracticeDate