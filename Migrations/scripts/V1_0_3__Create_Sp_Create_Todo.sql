create procedure [tm].[Create_Todo]
@parentId int = null,
@title varchar(100),
@extendedDescription varchar(max) = null,
@dueDate datetime = null,
@done bit
as
begin
	
	insert into tm.Todos (ParentId, Title, ExtendedDescription, DueDate, Done)
	values (@parentId, @title, @extendedDescription, @dueDate, @done)
	select SCOPE_IDENTITY() Id

end