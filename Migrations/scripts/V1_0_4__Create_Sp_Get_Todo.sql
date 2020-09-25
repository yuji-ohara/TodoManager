create procedure [tm].[Get_Todo]
@id int = null,
@parentId int = null,
@title varchar(100) = null,
@freetext varchar(max) = null,
@done bit = null
as
begin
	select *
	from tm.Todos
	where
	(@id is null or Id = @id)
	and (@parentId is null or ParentId = @parentId)
	and (@title is null or Title like '%' + @title + '%')
	and (@freetext is null or ExtendedDescription like '%' + @freetext + '%')
	and (@done is null or Done = @done)
end