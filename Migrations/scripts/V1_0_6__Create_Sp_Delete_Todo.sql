create procedure [tm].[Delete_Todo]
@id int
as
begin
	
	delete from tm.Todos
	where Id = @id

end