create procedure [tm].[Update_Todo]
@id int,
@parentId int = null,
@title varchar(100),
@extendedDescription varchar(max) = null,
@dueDate datetime = null,
@done bit
as
begin
	
	update tm.Todos
	set
		ParentId = @parentId,
		Title = @title,
		ExtendedDescription = @extendedDescription,
		DueDate = @dueDate,
		Done = @done
	where
		Id = @id
	
	select @id Id

end